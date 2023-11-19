namespace GraphQLProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();

    }
}
