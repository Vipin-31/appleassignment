using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;

namespace apple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppleController : Controller
    {
        [HttpGet]
        public JsonResult Get(string date)
        {
            DataAccess DA = new DataAccess();
            return Json(DA.GetAppleDatas(date));
        }
    }
}
