using eYummy.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using eYummy.Models.RecipeModels;
using eYummy.Models.CategoryModels;
using eYummy.Models.IngredientModels;

namespace eYummy.Controllers
{
    public class DataController : Controller 
    {

        private ICategoryRepository iCategoryRepo;
        private IRecipeRepository iRecipeRepo;
        private IIngredientDetailRepository iIngredientDetailRepo;

        //This variable is to upload file with fileToUpdate
        private IHostingEnvironment ihostingEnvironment;

        public IFormFile fileToUpload;

        string url = "/assets/img/RecipeList/";

        public DataController(IHostingEnvironment ihostingEnvironment,
            ICategoryRepository categoryRepository,
            IRecipeRepository recipeRepository,
            IIngredientDetailRepository ingredientDetailRepository)
        {
            this.ihostingEnvironment    = ihostingEnvironment;
            this.iCategoryRepo          = categoryRepository;
            this.iRecipeRepo            = recipeRepository;
            this.iIngredientDetailRepo  = ingredientDetailRepository;
        }

        [HttpGet]
        public ViewResult Insert()
        {
            return View(GetCategories());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Insert(Recipe recipe, IngredientDetail ingredientDetail)
        {
            //Console.WriteLine("recipe.ModalId = " + recipe.ModalId);

            Console.WriteLine("Files : \n" + Request.Form.Files);
            Console.WriteLine("Files : \n" + Request.Form.Files.ElementAt(0).FileName.ToString());
            


            /**
            Console.WriteLine("recipe.FileToUpload = " + recipe.FileToUpload);
            Console.WriteLine("uploadFile.FileName = " + uploadFile.FileName);
            Console.WriteLine("recipe.DataTarget = " + recipe.DataTarget);
            */

            if (ModelState.IsValid)
            {

                /**
                 * The Start of Upload File 
                 */

                long size = 0;

                string fileName = Request.Form.Files.ElementAt(0).FileName.ToString();

                foreach (var file in Request.Form.Files)
                {
                    var filename = ContentDispositionHeaderValue
                                    .Parse(file.ContentDisposition)
                                    .FileName
                                    .Trim('"');
                    

                    filename = this.ihostingEnvironment.WebRootPath + url + fileName;
                    var urlfilename = this.ihostingEnvironment.WebRootPath + url + fileName;
                    Console.WriteLine("\n fileName : " + fileName);
                    Console.WriteLine("\n urlfilename : " + urlfilename);
                    size += file.Length;
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }

                //The end of Upload File

                if(iRecipeRepo.Recipes.Where(r => r.RecipeId == recipe.RecipeId).Count() == 0 )
                {
                    recipe.FileToUpload = url + fileName;
                    iRecipeRepo.AddRecipe(recipe);
                    iIngredientDetailRepo.AddIngredientDetail(ingredientDetail);
                    return View("RecipeList");
                }
                else
                {
                    return View("Insert", recipe);
                }
                
            }
            else
            {
                return View("Insert");
            }
        }

        private RecipeModel GetCategories()
        {
            RecipeModel recipeModel = new RecipeModel();
            recipeModel.AllCategories = iCategoryRepo.Categories.ToList<Category>();
            return recipeModel;
        }
    }
}
