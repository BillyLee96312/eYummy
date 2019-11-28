using eYummy.Models.CategoryModels;
using eYummy.Models.IngredientModels;
using eYummy.Models.ModalModels;
using eYummy.Models.RecipeModels;
using eYummy.Models.ReviewCommentModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eYummy.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService
                <ApplicationDbContext>();

            context.Database.Migrate();



            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Meal Type"
                    },
                    new Category
                    {
                        CategoryName = "Ingredient"
                    },
                    new Category
                    {
                        CategoryName = "Diet and Health"
                    },
                    new Category
                    {
                        CategoryName = "Seasonal"
                    },
                    new Category
                    {
                        CategoryName = "Dish Type"
                    },
                    new Category
                    {
                        CategoryName = "World Cuisine"
                    },
                    new Category
                    {
                        CategoryName = "Special Collections"
                    },
                    new Category
                    {
                        
                        CategoryName = "Cooking Style"
                    }

                    );
                context.SaveChanges();
            }

            if (!context.ModalDetails.Any())
            {
                context.ModalDetails.AddRange(

                    new ModalDetail
                    {
                        ModalName = "EditModal",
                        DataTarget = "#EditModal"
                    },
                    new ModalDetail
                    {
                        ModalName = "DeleteModal",
                        DataTarget = "#DeleteModal"
                    },
                    new ModalDetail
                    {
                        ModalName = "ViewModal",
                        DataTarget = "#ViewModal"
                    }

                    );
                context.SaveChanges();
            }

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {

                        RecipeTitle = "Baked Stuffed Brie with Cranberries & Walnuts",
                        Description = "One of the most common mistakes people make when serving cheese " +
                        "is not letting it come to room temperature first, so that all the flavors can be fully realized. " +
                        "This beautiful baked stuffed brie takes that principle to the next level",
                        CategoryId = 1,
                        Yield = "Baked Brie",
                        FileToUpload = "3081928.jpg"
                    },
                    new Recipe
                    {

                        RecipeTitle = "Berries and Cream",
                        Description = "A delicious parfait. If you prefer, you can replace the blueberries with raspberries. " +
                        "Preparation time: 10 minutes. " +
                        "This recipe is from The WEBB Cooks, articles and recipes by Robyn Webb, " +
                        "courtesy of the American Diabetes Association",
                        CategoryId = 3,
                        Yield = "Desserts",
                        FileToUpload = "677720.jpg"
                    },
                    new Recipe
                    {

                        RecipeTitle = "Upside-Down Barbeque Meatloaf",
                        Description = "When I've made 'barbeque meatloaf' before I've simply used " +
                        "the standard spoon-the-glaze-on-top-of-the-loaf-and-bake-it method. " +
                        "This time I wanted to line the loaf pan with some of the sauce, press the meat in",
                        CategoryId = 2,
                        Yield = "Beef Meatloaf",
                        FileToUpload = "1411644.jpg"
                    }

                    );
                context.SaveChanges();
            }




            if (!context.IngredientDetails.Any())
            {
                context.IngredientDetails.AddRange(

                    new IngredientDetail
                    {
                        IngredientString = "Recipe 1 Ingredient 1"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 1 Ingredient 2"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 1 Ingredient 3"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 2 Ingredient 4"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 2 Ingredient 5"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 2 Ingredient 6"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 3 Ingredient 7"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 3 Ingredient 8"
                    },
                    new IngredientDetail
                    {
                        IngredientString = "Recipe 3 Ingredient 9"
                    }


                    );
                context.SaveChanges();
            }


            if (!context.RecipeModals.Any())
            {
                context.RecipeModals.AddRange(

                    new RecipeModal
                    {
                        RecipeId = 1,
                        ModalId = 1,
                    },
                    new RecipeModal
                    {
                        RecipeId = 1,
                        ModalId = 2,
                    },
                    new RecipeModal
                    {
                        RecipeId = 1,
                        ModalId = 3,
                    },
                    new RecipeModal
                    {

                        RecipeId = 2,
                        ModalId = 1,
                    },
                    new RecipeModal
                    {
                        RecipeId = 2,
                        ModalId = 2,
                    },
                    new RecipeModal
                    {
                        RecipeId = 2,
                        ModalId = 3,
                    },
                    new RecipeModal
                    {

                        RecipeId = 3,
                        ModalId = 1,
                    },
                    new RecipeModal
                    {
                        RecipeId = 3,
                        ModalId = 2,
                    },
                    new RecipeModal
                    {
                        RecipeId = 3,
                        ModalId = 3,
                    }

                    );
                context.SaveChanges();
            }


            
            if (!context.RecipeIngredients.Any())
            {
                context.RecipeIngredients.AddRange(

                    new RecipeIngredient
                    {
                        RecipeId = 1,
                        IngredientId = 1,
                    },
                    new RecipeIngredient
                    {
                        RecipeId = 1,
                        IngredientId = 2,
                    },
                    new RecipeIngredient
                    {
                        RecipeId = 1,
                        IngredientId = 3,
                    },
                    new RecipeIngredient
                    {

                        RecipeId = 2,
                        IngredientId = 1,
                    },
                    new RecipeIngredient
                    {
                        RecipeId = 2,
                        IngredientId = 2,
                    },
                    new RecipeIngredient
                    {
                        RecipeId = 2,
                        IngredientId = 5,
                    },
                    new RecipeIngredient
                    {

                        RecipeId = 3,
                        IngredientId = 4,
                    },
                    new RecipeIngredient
                    {
                        RecipeId = 3,
                        IngredientId = 5,
                    },
                    new RecipeIngredient
                    {
                        RecipeId = 3,
                        IngredientId = 1,
                    }

                    );
                context.SaveChanges();
            }

            
            


        }
    }
}
