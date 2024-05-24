﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;

namespace QuanLyBanQuanAo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }
        //lấy ds san pham
        [HttpPost("get-all-product")]
        public IActionResult getAllProduct()
        {
            var res = new SingleRsp();
            res.Data = productSvc.All;
            return Ok(res);
        }
        [HttpPost("Get-by-id")]
        public IActionResult GetProductByID([FromBody] SimpleReq req)
        {

            return Ok(productSvc.Read(req.Keyword));
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq productReq)
        {
          
            return Ok(productSvc.CreateProduct(productReq));
        }


        // dieu chinh lai..
        [HttpPut ("Update-Product")]
        public IActionResult UpdateProduct(string keyWord, [FromBody] ProductReq productReq)
        {
            if (keyWord == productReq.MaSp)
            {
                return BadRequest("Không tồn tại sản phẩm ");
            }
            var res = new SingleRsp();
            res = productSvc.UpdateProduct(productReq);
            return Ok(res);
            
        }
        [HttpDelete("Delete-Product")]
        public IActionResult DeleteProduct([FromBody] SimpleReq req)
        {
           
            return Ok(productSvc.DeleteProduct(req.Keyword));
        }
    }
}
