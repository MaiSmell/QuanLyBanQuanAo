using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;

namespace QuanLyBanQuanAo.Web.Controllers
{
    public class StatisticSizeController
    {
        
        private StatisticSizeSvc statisticSizeSvc;
        
        public StatisticSizeController()
        {

            statisticSizeSvc = new StatisticSizeSvc();
        }
        [HttpPost("Sl-TonKho")]
        public IActionResult ThongkeSize()
        {
            var result = statisticSizeSvc.ThongkeSize();
            return new OkObjectResult(result);
        }
    }
}
