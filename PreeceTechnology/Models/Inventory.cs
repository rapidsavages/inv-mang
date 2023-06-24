namespace PreeceTechnology.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int InStock { get; set; }
        public int NeedStock { get; set; }

        public string DepartmentId { get; set; } //Foreign key will be DepartmentId 
        public Department? Department { get; set; }

        public int CalculateStock()
        {
            return NeedStock + InStock;
        }
    }
}
