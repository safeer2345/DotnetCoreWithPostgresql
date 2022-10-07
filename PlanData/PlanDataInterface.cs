using FirstProject.Models;

namespace FirstProject.PlanData
{
    public interface PlanDataInterface
    {
        List<Plan> GePlans();

        Plan GetPlan(Guid planId);

        Plan AddPlan(Plan plan);

        Plan UpdatePlan(Plan plan);

        void DeletePlan(Plan plan);
    }
}
