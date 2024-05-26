using Microsoft.EntityFrameworkCore;
using QLBH.Common.DAL;
using QLBH.Common.Rsp;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{
    public class OrderDetailRep : GenericRep<QLBHContext, ChiTietDh>
    {
        public override ChiTietDh Read(int id)
        {

            var res = All.FirstOrDefault(o => o.MaDh == id);

            return res;
        }
        public SingleRsp CreateOrderDetail(ChiTietDh orderDetail)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ChiTietDhs.Add(orderDetail);
                        int result = context.SaveChanges();
                        tran.Commit();
                        res.SetData("201", result);
                    }
                    catch (DbUpdateException dbEx)
                    {
                        tran.Rollback();
                        var innerException = dbEx.InnerException?.Message ?? dbEx.Message;
                        res.SetError($"Database update exception: {innerException}");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();

                        res.SetError($"Exception: {ex}");
                    }
                }
            }
            return res;
        }

        public SingleRsp DeleteOrderDetail(ChiTietDh orderDetail)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ChiTietDhs.Remove(orderDetail);
                        context.SaveChanges();
                        tran.Commit();

                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);

                    }
                }
            }
            return res;
        }

        public SingleRsp UpdateOrderDetail(ChiTietDh orderDetail)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.ChiTietDhs.Update(orderDetail);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Cập nhật thành công");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Cập nhật thất bại ");
                    }
                }
            }
            return res;
        }


    }
}
