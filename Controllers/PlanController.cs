using FirstProject.Models;
using FirstProject.PlanData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    [ApiController]
    public class PlanController : ControllerBase
    {
        private PlanDataInterface _planDataInterface;
        public PlanController(PlanDataInterface planDataInterface)
        {
            _planDataInterface = planDataInterface;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPlans()
        {
            return Ok(_planDataInterface.GePlans());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPlan(Guid id)
        {
            var plan = _planDataInterface.GetPlan(id);
            if (plan != null)
            {
                return Ok(plan);
            }

            return NotFound($"Plan with id: {id} was not found");
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public IActionResult AddPlan(Plan plan)
        {
            var _plan = _planDataInterface.AddPlan(plan);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + _plan.Id, _plan);
        }

        [HttpDelete]
        [Route("/api/[controller]/{id}")]
        public IActionResult DeletePlan(Guid id)
        {
            var plan = _planDataInterface.GetPlan(id);

            if (plan != null)
            {
                _planDataInterface.DeletePlan(plan);

                return Ok();
            }

            return NotFound($"Plan with id: {id} was not found");
        }

        [HttpPut]
        [Route("/api/[controller]/{id}")]
        public IActionResult UpdatePlan(Guid id, Plan plan)
        {
            var _plan = _planDataInterface.GetPlan(id);

            if (_plan != null)
            {
                var _planResponse = _planDataInterface.UpdatePlan(plan);

                return Ok(_planResponse);
            }

            return NotFound($"Plan with id: {id} was not found");
        }
    }
}
