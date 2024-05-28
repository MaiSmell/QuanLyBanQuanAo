using QLBH.Common.BLL;
using QLBH.DAL.Models;
using QLBH.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Common.Rsp;

namespace QLBH.BLL
{
    public class StatisticSizeSvc : GenericSvc<StatisticSizeRep, SanPhamSize>
    {
        private StatisticSizeSvc statisticSizeRep;

        public SingleRsp ThongkeSize()
        {
            var res = new SingleRsp();
            var ds = statisticSizeRep.ThongkeSize();
            res.Data = ds;
            
            return res;
        }
    }
}
