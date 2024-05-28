using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticSizeController : ControllerBase
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
            return Ok (result);
        }
        [HttpPost("Search-Product-Size")]
        public IActionResult SearchProductSize([FromBody] SearchSizeReq searchSizeReq)
        {
            var res = new SingleRsp();
            res.Data = statisticSizeSvc.SearchProductSize(searchSizeReq);
            return Ok(res);
        }
    }
}
