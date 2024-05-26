using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {

        private StatisticlRevenueSvc statisticSvc;
        private StatisticSizeSvc statisticSvc2;
        public StatisticController()
        {
            statisticSvc = new StatisticlRevenueSvc();
            statisticSvc2 = new StatisticSizeSvc();
        }
        
        [HttpPost("Cal-Total-by-Year")]
        public IActionResult CalTotalByYear(int year)
        {
            var res = statisticSvc.TongDoanhThuTheoNam(year);
            return Ok(res);
        }
        
        [HttpPost("Cal-Total-by-Month")]
        public IActionResult CalTotalByMonth(int month, int year)
        {
            var res = statisticSvc.TongDoanhThuTheoThangCuaNam(month,year);
            return Ok(res);
        }
    }
}
