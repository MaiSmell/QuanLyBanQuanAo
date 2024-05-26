using QLBH.Common.BLL;
using QLBH.DAL.Models;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBH.BLL
{
    public class StatisticlRevenueSvc : GenericSvc<StatisticlRevenueRep, DonHang>
    {
        private StatisticlRevenueRep statisticRep;

        public StatisticlRevenueSvc()
        {
            statisticRep = new StatisticlRevenueRep(); //tạo mới đối tượng DLL

        }
        
        public SingleRsp TongDoanhThuTheoNam( int year)
        {
            var res = new SingleRsp();
            var totalRevenue = statisticRep.TongDoanhThuTheoNam(year);
            var result = new
            {
                Year = year,
                TongDoanhThu = totalRevenue
            };
            res.Data= result;
            return res;
        }
        public SingleRsp TongDoanhThuTheoThangCuaNam(int month, int year )
        {
            var res = new SingleRsp();
            var total = statisticRep.TongDoanhThuTheoThangCuaNam(month);
            
            if (month < 1 || month > 12)
            {
                
                throw new ArgumentException("Tháng không hợp lệ");
            }
            var result = new
            {
                Year = year,
                Month = month,
                TongDoanhThu = total
            };
            res.Data = result;
            return res;
        }

    }
}

