namespace MVCApplication.Models
{
    public class Ingrediant
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<DishIngredeint> DishIngredeints { get; set; }
    }
}
