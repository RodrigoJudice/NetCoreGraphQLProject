using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
    public class MenuRepository : IMenuRepository
    {
        private GraphQLDbContext dbContext;

        public MenuRepository(GraphQLDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Menu AddMenu(Menu menu)
        {
            dbContext.Menus.Add(menu);
            dbContext.SaveChanges();
            return menu;
        }

        public void DeleteMenu(int id)
        {
            var menuResult = dbContext.Menus.Find(id);
            if (menuResult != null)
            {
                dbContext.Remove(menuResult);
                dbContext.SaveChanges();
            }
        }

        public List<Menu> GetAllMenu()
        {
            return dbContext.Menus.ToList();
        }

        public Menu? GetMenuById(int id)
        {
            return dbContext.Menus.Find(id);
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var menuResult = dbContext.Menus.Find(id);
            if (menuResult != null)
            {
                menuResult.Price = menu.Price;
                menuResult.Name = menu.Name;
                menuResult.Description = menu.Description;
                dbContext.Menus.Update(menuResult);
                dbContext.SaveChanges();
            }

            return menu;
        }
    }
}
