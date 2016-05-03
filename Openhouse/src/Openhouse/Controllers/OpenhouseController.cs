using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Openhouse.Queries;
using Openhouse.Commands;
using Openhouse.RequestModels;
using Openhouse.ResponseModels;

namespace Openhouse.Controllers
{
    [Route("[controller]")]
    public class OpenhouseController : Controller
    {
        readonly Settings _settings;

        public OpenhouseController(Settings settings)
        {
            _settings = settings;
        }

        JsonResult CommandResult(OpenhouseCommand.OpenhouseCommandResult coomandResult)
        {
            return Json(new
            {
                result = coomandResult.Result,
                data = coomandResult?.EffectedOpenhouse
            });
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(new
            {
                result = 0,
                data = new OpenhouseQuery().GetOpenhouses()
            });
        }

     
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(new
            {
                result = 0,
                data = new OpenhouseQuery().GetOpenhouse(id)
            });
        }

      
        [HttpPost]
        public JsonResult Post([FromBody]OpenhousePost openhouse)
        {
            return CommandResult(new OpenhouseCommand(_settings).AddOpenhouse(openhouse));   
        }

    
        [HttpPut]
        public JsonResult Put([FromBody]OpenhousePut openhouse)
        {
            return CommandResult(new OpenhouseCommand(_settings).UpdateOpenhouse(openhouse));
        }

      
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            return CommandResult(new OpenhouseCommand(_settings).DeleteOpenhouse(id));
        }

      
    }
}
