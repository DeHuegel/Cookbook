using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Steri.Cookbook.Api.Controllers
{    
    [Route("api/Dish")]
    public class DishController : Controller
    {
        private readonly Data.DishRepository dishRepository = new Data.DishRepository();

        [HttpPost]
        public IEnumerable<Model.Dish> Get([FromBody]Model.DishFilterInformation dishFilterInformation)
        {
            return this.dishRepository.Get(dishFilterInformation);
        }
    }
}