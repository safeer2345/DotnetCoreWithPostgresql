using FirstProject.Data;
using FirstProject.Models;
using System.Numerics;

namespace FirstProject.PlanData
{
    public class SqlPlanData : PlanDataInterface
    {
        private PlanDataContext _planDataContext;
        public SqlPlanData (PlanDataContext planDataContext)
        {
            _planDataContext = planDataContext;
        }
        public Plan AddPlan(Plan plan)
        {
            plan.Id = Guid.NewGuid(); 
            _planDataContext.Plans.Add(plan);
            _planDataContext.SaveChanges();
            return plan;
        }

        public void DeletePlan(Plan plan)
        {
            _planDataContext.Plans.Remove(plan);
        }

        public List<Plan> GePlans()
        {
            return _planDataContext.Plans.ToList();
        }

        public Plan GetPlan(Guid planId)
        {
            // _planDataContext.Plans.SingleOrDefault(x => x.Id == planId);
            var plan = _planDataContext.Plans.Find(planId);
            return plan;
        }

        public Plan UpdatePlan(Plan plan)
        {
            var existingPlan = GetPlan(plan.Id);
            if (existingPlan != null)
            {
                existingPlan.Name = plan.Name;
                existingPlan.Price = plan.Price;
           
                _planDataContext.Plans.Update(existingPlan);
                _planDataContext.SaveChanges ();
            }
            return plan;
        }
    }
}
