using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eYummy.Models;
using eYummy.Models.RecipeModels;
using eYummy.Models.IngredientModels;
using eYummy.Models.ReviewCommentModels;
using eYummy.Models.ViewModels;
using eYummy.Models.CategoryModels;

namespace eYummy.Controllers
{
    public class RecipeController : Controller
    {
        private IQueryable<Recipe> Recipes;
        private IQueryable<IngredientDetail> IngredientDetails;
        private IQueryable<RecipeIngredient> RecipeIngredients;
        private IQueryable<ReviewCommentDetail> ReviewCommentDetails;
        private IQueryable<RecipeReviewComment> RecipeReviewComments;
        private IQueryable<Category> Categories;
        



        private UserDetailModel userDetailModel;
        

        public RecipeController(IRecipeRepository recipeRepository, 
                                IIngredientDetailRepository ingredientDetailRepository,
                                IRecipeIngredientRepository recipeIngredientRepository,
                                IReviewCommentDetailRepository  reviewCommentDetailRepository,
                                IRecipeReviewCommentRepository recipeReviewCommentRepository
                                )
        {
            Recipes                 =   recipeRepository.Recipes;
            IngredientDetails       =   ingredientDetailRepository.IngredientDetails;
            RecipeIngredients       =   recipeIngredientRepository.RecipeIngredients;
            ReviewCommentDetails    =   reviewCommentDetailRepository.ReviewCommentDetails;
            RecipeReviewComments    =   recipeReviewCommentRepository.RecipeReviewComments;

        }
        public IActionResult Index()
        {
            return View();
        }
        


        public ViewResult Display()
        {
            return View(Recipes);
        }
        [HttpGet]
        public ViewResult UserDetail(string id)
        {
            Console.WriteLine("\n UserDetail .............. " + id);
            
            userDetailModel = new UserDetailModel();
            userDetailModel.AllRecipes = Recipes.ToList<Recipe>();
            userDetailModel.AllIngredientDetails = IngredientDetails.ToList<IngredientDetail>();
            userDetailModel.AllRecipeIngredients = RecipeIngredients.ToList<RecipeIngredient>();
            userDetailModel.AllReviewCommentDetails = ReviewCommentDetails.ToList<ReviewCommentDetail>();
            userDetailModel.AllRecipeReviewComments = RecipeReviewComments.ToList<RecipeReviewComment>();

            userDetailModel.Recipe              = Recipes.FirstOrDefault(r => r.RecipeId.ToString() == id);

            return View(userDetailModel);
        }



        public ViewResult FindRecipe(string searchCategoryName, string searchString)
        {
            if (String.IsNullOrEmpty(searchCategoryName) && String.IsNullOrEmpty(searchString))
            {
                return View("../Recipe/Display", new RecipesListViewModel
                {
                    RecipeCollection = Recipes
                    .OrderBy(r => r.RecipeId)
                });
            }

            else
            {
                var stringSearch = !String.IsNullOrEmpty(searchString);
                var categorySearch = !String.IsNullOrEmpty(searchCategoryName);

                var recipesSearched = Recipes;
                var categoriesSearched = Categories;
                List<Category> ResultCategories = new List<Category>();
                List<Recipe> ResultRecipes = new List<Recipe>();



                if (stringSearch)
                {
                    var keywords = searchString.Split(" ").ToList();

                    if (keywords.Count() != 0)
                    {
                        foreach (var keyword in keywords)
                        {
                            ResultRecipes.AddRange(recipesSearched.
                            Where(r => r.RecipeTitle.ToLower().Contains(keyword.ToLower())                            
                            ));
                        }

                    }
                }

                if (categorySearch)
                {
                    /**
                    ResultRecipes.AddRange(
                        recipesSearched.Where(r => r.CategoryName.ToLower().Contains(searchCategoryId.ToLower())));
                    */
                    ResultCategories.AddRange(
                        categoriesSearched.Where(c => c.CategoryName.ToLower().Contains(searchCategoryName.ToLower())));
                }

                ResultRecipes = new HashSet<Recipe>(ResultRecipes).ToList();
                //ResultRecipes = ResultRecipes.Distinct().ToList();

                return View("../Recipe/Display", new RecipesListViewModel
                {
                    RecipeCollection = ResultRecipes
                    .OrderBy(r => r.RecipeId),

                    Categories = ResultCategories
                    .OrderBy(c => c.CategoryName)

                });
            }

        }
    }
}