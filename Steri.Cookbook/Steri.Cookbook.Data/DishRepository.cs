using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Steri.Cookbook.Data
{
    public class DishRepository
    {
        public IEnumerable<Model.Dish> Get(Model.DishFilterInformation dishFilterInformation)
        {
            using (var ctx = new CookbookContext())
            {

                IQueryable<Model.Dish> dishes = ctx.Dishes;
                if (!string.IsNullOrEmpty(dishFilterInformation.OrderBy) && dishFilterInformation.OrderBy == "Id")
                {
                    dishes = dishes.OrderBy(d => d.Id);
                }
                else if (!string.IsNullOrEmpty(dishFilterInformation.OrderBy) && dishFilterInformation.OrderBy == "Name")
                {
                    dishes = dishes.OrderBy(d => d.Name);
                }
                else if (!string.IsNullOrEmpty(dishFilterInformation.OrderBy) && dishFilterInformation.OrderBy == "Description")
                {
                    dishes = dishes.OrderBy(d => d.Description);
                }

                if (!string.IsNullOrEmpty(dishFilterInformation.FilterText))
                {
                    dishes = dishes.Where(d => d.Name.Contains(dishFilterInformation.FilterText) || d.Description.Contains(dishFilterInformation.FilterText));
                }

                return dishes.ToArray();
            }
        }
    }
}
