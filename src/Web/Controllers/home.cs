using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Home.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        
        [HttpGet("[action]")]
        public  ActionResult<int> GetVersion()
        {
            try
            {
              
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured", ex);
            }
        }
    }
}
