namespace FirstProject.Models
{
    public class Plan
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
