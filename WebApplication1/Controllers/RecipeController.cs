using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DTO;
using System.Web.Http.Cors;
using System.Security.Cryptography.X509Certificates;



namespace WebApplication1.Controllers
{

    public class RecipeController : ApiController
    {
        // GET: api/Recipe
        public List<RecipeDto> Get()
        {
            KitchenDbContext db = new KitchenDbContext();

            var recipes = db.Recipes.Select(x => new RecipeDto
            {
                Id = x.Id,
                Name = x.Name,
                Time = x.Time,
                CookingMethod = x.CookingMethod,
                Image = x.Image,
            }).ToList();
            return recipes;
        }


        // POST: api/Recipe

        public IHttpActionResult Post([FromBody] Recipe value)
        {
            KitchenDbContext db = new KitchenDbContext();

            Recipe recipe = new Recipe();

            recipe.Name = value.Name;
            recipe.CookingMethod = value.CookingMethod;
            recipe.Time = value.Time;
            recipe.Image = value.Image;
          
            List<Ingredient> ings = new List<Ingredient>();
            foreach (Ingredient item in value.Ingredients)
            {
                ings.Add(db.Ingredients.FirstOrDefault(y => y.Id == item.Id));
            }
            try
            {
                recipe.Ingredients = ings;
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return Created(new Uri(Request.RequestUri.AbsoluteUri), value);
                //return Ok(recipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
