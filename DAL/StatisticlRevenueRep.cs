using Microsoft.EntityFrameworkCore;
using QLBH.Common.DAL;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH.DAL
{

    public class StatisticlRevenueRep : GenericRep<QLBHContext, DonHang>
    {
        private readonly QLBHContext da;

        public StatisticlRevenueRep()
        {
            da = new QLBHContext();
        }

        public decimal TongDoanhThuTheoNam(int year)
        {
            var total = da.DonHangs
                 .Where(s => s.NgayDatHang.Value.Year == year)
                  .Join(da.ChiTietDhs, d => d.MaDh, c => c.MaDh, (d, c) => (decimal)(c.SoLuong * c.DonGia))
                 .Sum();
            return total;

        }
        public decimal TongDoanhThuTheoThangCuaNam(int month)
        {

            int currentYear = DateTime.Now.Year;
            DateTime startDate = new DateTime(currentYear, month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            var total = da.DonHangs
                .Where(s => s.NgayDatHang >= startDate && s.NgayDatHang <= endDate)
                .Join(da.ChiTietDhs, d => d.MaDh, c => c.MaDh, (d, c) => (decimal)(c.SoLuong * c.DonGia))
                .Sum();
            return total;
        }
    }
}
