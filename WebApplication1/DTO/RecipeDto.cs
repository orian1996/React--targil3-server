using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTO
{
    public class RecipeDto
    {
        public int Id;
        public string Name;
        public string Image;
        public Nullable<int> Time;
        public string CookingMethod;
        public List<Ingredient> IngredientIds;
    }
}