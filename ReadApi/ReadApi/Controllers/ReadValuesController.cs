using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadApi.Data;
using ReadApi.Services;

namespace ReadApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadValuesController : ControllerBase
    {

        private readonly IReadService _readService;
        public List<Product> Products;
        public ReadValuesController(IReadService read)
        {
            _readService = read;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Product> GetById(int Id)
        {
            var result = await Task.FromResult(_readService.Get<Product>($"Select * from [production].[products] where product_id = {Id}", null, commandType: CommandType.Text));
            return result;
        }

        [HttpGet]
        [Route("api/{num}")]
        public async Task<List<Product>> GetAll(int num)
        {
            var result = await Task.FromResult(_readService.GetAll<Product>($"Select * from [production].[products] where gender_id={num}", null, commandType: CommandType.Text));
            return result;
        }
    }
}

