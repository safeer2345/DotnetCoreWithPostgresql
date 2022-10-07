using FirstProject.Models;

namespace FirstProject.PlanData
{
    public class PlanDataImplementation : PlanDataInterface
    {
        private List<Plan> plans = new List<Plan>()
        {
            new Plan()
            {
                Id = Guid.NewGuid(),
                Name = "Gold",
                Price = 1000,
                CreatedAt = DateTime.Now
            },

             new Plan()
            {
                Id = Guid.NewGuid(),
                Name = "Silver",
                Price = 500,
                CreatedAt = DateTime.Now
            },

              new Plan()
            {
                Id = Guid.NewGuid(),
                Name = "Bronze",
                Price = 100,
                CreatedAt = DateTime.Now
            }
        };


        public Plan AddPlan(Plan plan)
        {
            plan.Id = Guid.NewGuid();
            plans.Add(plan);
            return plan;
        }

        public void DeletePlan(Plan plan)
        {
            plans.Remove(plan);
        }

        public List<Plan> GePlans()
        {
            return plans;
        }

        public Plan GetPlan(Guid planId)
        {
           return plans.SingleOrDefault(x => x.Id == planId);
        }

        public Plan UpdatePlan(Plan plan)
        {
           var existingPlan = GetPlan(plan.Id);
            existingPlan.Name = plan.Name;
            existingPlan.Price = plan.Price;
            existingPlan.CreatedAt = DateTime.Now;  

            return existingPlan;
        }
    }
}
