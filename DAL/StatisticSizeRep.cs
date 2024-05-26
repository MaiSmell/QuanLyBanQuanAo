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
    public class StatisticSizeRep : GenericRep<QLBHContext, SanPhamSize>
    {
        private readonly QLBHContext da;
        public StatisticSizeRep()
        {
            da = new QLBHContext();
        }
        //public decimal ThongkeSize(int Soluongtonkho )
        //{
        //    var total = da.SanPhamSizes
        //        .GroupBy(s => s.Size)
        //        .Select(s => new { s.Key, Soluongtonkho = s.Count() }).ToList();
        //    return total;
            

        //}
    }
}
