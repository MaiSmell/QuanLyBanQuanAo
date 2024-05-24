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
    public class OrderRep: GenericRep<QLBHContext, DonHang>
    {
        //lay ra don hang theo id
        public override DonHang Read(int id)
        {
            var res = All.FirstOrDefault(o => o.MaDh == id);
            return res;
        }
        //xoa don hang theo id
        public int Remove (int id)
        {
            var m = base.All.First (i => i.MaDh == id);
            m = base.Delete(m);
            return m.MaDh;
        }
        //thêm đơn hàng
        //public SingleRsp CreateOrder(DonHang order)
        //{
        //    var res = new SingleRsp();
        //    using (var context = new QLBHContext())
        //    {
        //        using (var tran = context.Database.BeginTransaction())
        //        {
        //            try
        //            {
        //                var p = context.DonHangs.Add(order);
        //                context.SaveChanges();
        //                tran.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                tran.Rollback();
        //                res.SetError(ex.StackTrace);
        //            }
        //        }
        //    }
        //    return res;
        //}
        public SingleRsp CreateOrder(DonHang order)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DonHangs.Add(order);
                        int result =  context.SaveChanges();
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

        public SingleRsp DeleteOrder(DonHang order)
        {
            var res = new SingleRsp();
            using (var context = new QLBHContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DonHangs.Remove(order);
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

        
    }
}
