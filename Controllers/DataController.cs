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
using eYummy.Models.ViewModels;
using eYummy.Models.ModalModels;
using eYummy.Models.ReviewCommentModels;

namespace eYummy.Controllers
{
    public class DataController : Controller 
    {

        private ICategoryRepository                 iCategoryRepo;
        private IRecipeRepository                   iRecipeRepo;
        private IRecipeModalRepository              iRecipeModalRepo;
        private IModalDetailRepository              iModalDetailRepo;
        private IIngredientDetailRepository         iIngredientDetailRepo;
        private IRecipeIngredientRepository         iRecipeIngredientRepo;
        private IRecipeReviewCommentRepository      iRecipeReviewCommentRepo;
        private IReviewCommentDetailRepository      iReviewCommentDetailRepo;

        //This variable is to upload file with fileToUpdate
        private IHostingEnvironment ihostingEnvironment;

        public IFormFile fileToUpload;

        public static string url = "/assets/img/RecipeList/";
        public string fileName = "";

        public RecipesListViewModel rlv = new RecipesListViewModel();


        public DataController(IHostingEnvironment ihostingEnvironment,
            ICategoryRepository categoryRepository,
            IRecipeRepository recipeRepository,
            IIngredientDetailRepository ingredientDetailRepository,
            IRecipeModalRepository recipeModalRepository,
            IModalDetailRepository modalDetailRepository,
            IRecipeIngredientRepository recipeIngredientRepository,
            IRecipeReviewCommentRepository recipeReviewCommentRepository,
            IReviewCommentDetailRepository  reviewCommentDetailRepository
            )
        {
            this.ihostingEnvironment            =   ihostingEnvironment;
            this.iCategoryRepo                  =   categoryRepository;
            this.iRecipeRepo                    =   recipeRepository;
            this.iIngredientDetailRepo          =   ingredientDetailRepository;
            this.iModalDetailRepo               =   modalDetailRepository;
            this.iRecipeModalRepo               =   recipeModalRepository;
            this.iRecipeIngredientRepo          =   recipeIngredientRepository;
            this.iRecipeReviewCommentRepo       =   recipeReviewCommentRepository;
            this.iReviewCommentDetailRepo       =   reviewCommentDetailRepository;

        }

        [HttpGet]
        public ViewResult Insert()
        {
            Console.WriteLine("Insert ......  it is ready for get categories .......");
            return View(GetCategories());
        }


        public ViewResult List(int recipePage = 1)
        {
            
            rlv.Recipes             =   iRecipeRepo.Recipes;
            rlv.Categories          =   iCategoryRepo.Categories;
            rlv.ModalDetails        =   iModalDetailRepo.ModalDetails;
            rlv.RecipeModals        =   iRecipeModalRepo.RecipeModals;
            rlv.RecipeIngredients   =   iRecipeIngredientRepo.RecipeIngredients;
            rlv.IngredientDetails   =   iIngredientDetailRepo.IngredientDetails;

            return View("RecipeList", rlv);
        }

        [HttpPost]
        
        public IActionResult EditRecipe(RecipesListViewModel recipesListViewModel, string[] UpdateIngredientString)
        {

            recipesListViewModel.Recipe.DateTimeUpdate = DateTime.Now;
            Console.WriteLine("recipe IngredientString = " + recipesListViewModel.IngredientString);


            Console.WriteLine("rlview recipeId = " + recipesListViewModel.Recipe.RecipeId);
            Console.WriteLine("rlview RecipeTitle = " + recipesListViewModel.Recipe.RecipeTitle);
            Console.WriteLine("rlview CategoryId = " + recipesListViewModel.Recipe.CategoryId);

            
            Console.WriteLine("rlview Description = " + recipesListViewModel.Recipe.Description);

            Console.WriteLine("rlview Servings = " + recipesListViewModel.Recipe.Servings);
            Console.WriteLine("rlview ServingsMax = " + recipesListViewModel.Recipe.ServingsMax);
            Console.WriteLine("rlview Total = " + recipesListViewModel.Recipe.Total);
            Console.WriteLine("rlview Yield = " + recipesListViewModel.Recipe.Yield);
            Console.WriteLine("rlview CookTime = " + recipesListViewModel.Recipe.CookTime);
            Console.WriteLine("rlview Prep = " + recipesListViewModel.Recipe.Prep);
            Console.WriteLine("rlview DateTimeUpdate = " + recipesListViewModel.Recipe.DateTimeUpdate);
            Console.WriteLine("rlview DateTimeUpdate = " + recipesListViewModel.UpdateIngredientString);

            foreach (IngredientDetail ingredientDetail in recipesListViewModel.UpdateIngredientDetail)
            {
                Console.WriteLine(ingredientDetail.IngredientId);
                Console.WriteLine(ingredientDetail.IngredientString);
                
            }

            foreach (KeyValuePair<int, string> item in recipesListViewModel.UpdateIngredientDetailDic)
            {
                Console.WriteLine("item key = " + item.Key + ", item Value" + item.Value);
            }


            if (ModelState.IsValid)
            {

                if (iRecipeRepo.Recipes.Where(r => r.RecipeId == recipesListViewModel.Recipe.RecipeId).Count() == 0)
                {

                    recipesListViewModel.Recipe.FileToUpload = getFileUrlName();
                    Console.WriteLine("rlview FileToUpload = " + recipesListViewModel.Recipe.FileToUpload);

                    //Insert new recipe in recipe table
                    //iRecipeRepo.UpdateRecipe(recipesListViewModel.Recipe);
                    //IDictionary<int, string> updateRecipeIngredients = recipesListViewModel.UpdateRecipeIngredients;

                    foreach(var updateIngredientString in recipesListViewModel.UpdateIngredientString)
                    {
                        Console.WriteLine("Value: {0} to update IngredientDetail changed by user ", updateIngredientString);
                    }
                    /*
                    //get these values (Keys and Values) by Access Elements using for Loop from the dictionary of UpdateRecipeIngredients class
                    foreach (KeyValuePair<int, string> item in updateRecipeIngredients)
                    {
                        Console.WriteLine("Key: {0}, Value: {1} to update RecipeIngredients", item.Key, item.Value);
                    }
                    */
                    /**
                    foreach (IngredientDetail ingredientDetail in recipesListViewModel.UpdateIngredientDetails)
                    {
                        Console.WriteLine("IngredientId value in EditRecipe() = " + ingredientDetail.IngredientId);
                        Console.WriteLine("ingredientString value in EditRecipe() = " + ingredientDetail.IngredientString);
                    }
                    */
                    /**
                    foreach (string ingredientString in recipesListViewModel.IngredientString)
                    {

                        if (string.IsNullOrEmpty(ingredientString))
                        {
                            Console.WriteLine("There is a empty or null in the ingredient detail by the user input (ingredientString is null) in the recipe Id ["
                                + recipesListViewModel.Recipe.RecipeId + "]");
                        }
                        else
                        {

                            IngredientDetail ingredientDetail = new IngredientDetail();

                            ingredientDetail.IngredientId = ingredientString;
                            ingredientDetail.IngredientString = ingredientString;
                            Console.WriteLine("ingredientString value in EditRecipe() = " + ingredientString);
                            iIngredientDetailRepo.UpdateIngredientDetail(ingredientDetail);
                            // Insert Ingredients of New Recipe in RecipeIngredient Table as Bridge Table for many to many relations 
                            // Between Recipe and IngredientDetail Table (Ingredient Informations)
                            //iRecipeIngredientRepo.UpdaeteRecipeIngredient(
                            //    recipesListViewModel.Recipe.RecipeId, ingredientDetail);


                        }
                    }
                    */


                }
                    return View("RecipeList", recipesListViewModel);
            }
            else
            {
                return View("RecipeList", recipesListViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ViewResult Insert(RecipeModel recipeModel, string[] IngredientString)
        public ViewResult Insert(RecipeModel recipeModel)
        {
            if (ModelState.IsValid)
            {
                recipeModel.Recipe.DateTimeUpdate = DateTime.Now;

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

                    size += file.Length;
                    using (FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }

                //The end of Upload File

                if (iRecipeRepo.Recipes.Where(r => r.RecipeId == recipeModel.Recipe.RecipeId).Count() == 0)
                {
                    recipeModel.Recipe.FileToUpload = url + fileName;
                    
                    //Insert new recipe in recipe table
                    iRecipeRepo.AddRecipe(recipeModel.Recipe);

                    /**
                     * It is being generated loop to create ingredientDetail and RecipeIngredient table 
                     * at the same time as much as the number of Ingredients by user
                     */
                    
                    foreach (string ingredientString in recipeModel.IngredientString)
                    {

                        if(string.IsNullOrEmpty(ingredientString))
                        {
                            Console.WriteLine("There is a empty or null in the ingredient detail by the user input (ingredientString is null) in the recipe Id ["
                                + recipeModel.Recipe.RecipeId + "]");
                        }
                        else
                        {
                            IngredientDetail ingredientDetail = new IngredientDetail();
                            ingredientDetail.IngredientString = ingredientString;
                            //Insert Ingredients details (IngredientString) of New Recipe in IngredientDetail Table 
                            iIngredientDetailRepo.AddIngredientDetail(ingredientDetail);
                            // Insert Ingredients of New Recipe in RecipeIngredient Table as Bridge Table for many to many relations 
                            // Between Recipe and IngredientDetail Table (Ingredient Informations)
                            iRecipeIngredientRepo.AddRecipeIngredient(
                                recipeModel.Recipe.RecipeId, ingredientDetail);
                        }
                    }


                    // Insert data (Model ID : 1, 2, 3 by the relationship Modal of new recipe) in RecipeModal Table as bridge table between recipe and Model (Model Id: 1, 2, 3)
                    //to display View/Edit/Delete Button in "Data/List.cshtml"

                    recipeModel.AllModalDetails = iModalDetailRepo.ModalDetails.ToList<ModalDetail>();

                    foreach(ModalDetail modalDetail in recipeModel.AllModalDetails)
                    {
                        iRecipeModalRepo.AllRecipeModal(recipeModel.Recipe.RecipeId, modalDetail); 
                    }

                    return View("../Recipe/Display", new SearchRecipeModel
                    {
                        RecipeCollection = iRecipeRepo.Recipes
                    });

                }
                else
                {
                    return View("Insert", recipeModel);
                }

            }
            else
            {
                return View("Insert", recipeModel);
            }


        }
        

        private RecipeModel GetCategories()
        {
            RecipeModel recipeModel = new RecipeModel();
            recipeModel.AllCategories = iCategoryRepo.Categories.ToList<Category>();
            return recipeModel;
        }

        [HttpGet]
        public ViewResult DeleteRecipe(string id)
        {
            Console.WriteLine("Delete Recipe ....... ID : [" + id + "]");
            // Before this controller goes to RecipeLIst view, rlv model can toss to the view.
            rlv.Recipes                 =   iRecipeRepo.Recipes;
            rlv.Categories              =   iCategoryRepo.Categories;
            rlv.ModalDetails            =   iModalDetailRepo.ModalDetails;
            rlv.RecipeModals            =   iRecipeModalRepo.RecipeModals;
            rlv.RecipeIngredients       =   iRecipeIngredientRepo.RecipeIngredients;
            rlv.IngredientDetails       =   iIngredientDetailRepo.IngredientDetails;
            rlv.RecipeReviewComments    =   iRecipeReviewCommentRepo.RecipeReviewComments;
            rlv.ReviewCommentDetails    =   iReviewCommentDetailRepo.ReviewCommentDetails; 

            //Before the Neuavenue system is removed recipe, from bridge table
            //The system will has to indicate which ReviewComment belong to the recipe Id.


            // In order to remove IngredientStrings in IngredientDetail which belongs to IngredientId
            int recipeId = Convert.ToInt32(id);


            List<RecipeIngredient> recipeIngredients = rlv.RecipeIngredients.Where(ri => ri.RecipeId == recipeId).ToList<RecipeIngredient>();
            
            foreach (RecipeIngredient recipeIngredient in recipeIngredients)
            {
                iRecipeIngredientRepo.DeleteRecipeIngredient(recipeIngredient);
                IngredientDetail ingredientDetail = rlv.IngredientDetails.First<IngredientDetail>(
                    ind => ind.IngredientId == recipeIngredient.IngredientId);
                iIngredientDetailRepo.DeleteIngredientDetail(ingredientDetail);
                
            }

            //remove the data in RecipeModal which are the data (1, 2, 3 by recipeId) which has to be deleted.
            List<RecipeModal> recipeModals = rlv.RecipeModals.Where(rm => rm.RecipeId == recipeId).ToList<RecipeModal>();

            foreach (RecipeModal recipeModal in recipeModals)
            {
                Console.WriteLine("ModalId in recipeModal: " + recipeModal.ModalId);
                Console.WriteLine("RecipeId in recipeModal: " + recipeModal.RecipeId);
                iRecipeModalRepo.DeleteRecipeModal(recipeModal);
            }

            //Remove the data in RecipeReviewComment and ReviewCommentDetail by recipeId which has to be deleted.
            List<RecipeReviewComment> recipeReviewComments = rlv.RecipeReviewComments.Where(
                rrc => rrc.RecipeId == recipeId).ToList<RecipeReviewComment>();
            foreach(RecipeReviewComment recipeReviewComment in recipeReviewComments)
            {
                iRecipeReviewCommentRepo.DeleteRecipeReviewComment(recipeReviewComment);

                ReviewCommentDetail reviewCommentDetail = rlv.ReviewCommentDetails.First<ReviewCommentDetail>(
                    rcd => rcd.ReviewCommentId == recipeReviewComment.ReviewCommentId);
                iReviewCommentDetailRepo.DeleteReviewCommentDetail(reviewCommentDetail);
            }
            
            //Remove Recipe by its RecipeId.
            Recipe DeleteRecipe = iRecipeRepo.Recipes.First<Recipe>(r => r.RecipeId.ToString() == id);
            iRecipeRepo.DeleteRecipe(DeleteRecipe);
            
            return View("RecipeList", rlv);

        }

        public string getFileUrlName()
        {
            long size = 0;
            fileName = Request.Form.Files.ElementAt(0).FileName.ToString();

            foreach (var file in Request.Form.Files)
            {
                var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');
                filename = this.ihostingEnvironment.WebRootPath + url + fileName;
                var urlfilename = this.ihostingEnvironment.WebRootPath + url + fileName;

                size += file.Length;
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }

            return url + fileName;

        }
    }
}
