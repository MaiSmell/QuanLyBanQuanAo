using Microsoft.EntityFrameworkCore;
using QLBH.Common.DAL;
using QLBH.Common.Req;
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
        public List<SanPhamSizeReq> ThongkeSize()
        {
            var ds = da.SanPhamSizes
                             .GroupBy(s => s.Size)
                             .Select(s => new SanPhamSizeReq
                             {
                                 Size = s.Key,
                                 SoLuongTonKho   = s.Count()
                             })
                             .ToList();
            return ds;
        }
    }
}
