using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eYummy.Models;
using eYummy.Models.CategoryModels;
using eYummy.Models.IngredientModels;
using eYummy.Models.ModalModels;
using eYummy.Models.ReviewCommentModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eYummy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public IConfiguration Configuration { get; } 

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:eYummyRecipes:ConnectionString"]));
            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
            services.AddTransient<IRecipeModalRepository, EFRecipeModalRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddTransient<IModalDetailRepository, EFModalDetailRepository>();
            services.AddTransient<IRecipeIngredientRepository, EFRecipeIngredientRepository>();
            services.AddTransient<IIngredientDetailRepository, EFIngredientDetailRepository>();
            services.AddTransient<IRecipeReviewCommentRepository, EFRecipeReviewCommentRepository>();
            services.AddTransient<IReviewCommentDetailRepository, EFReviewCommentDetailRepository>();
            services.AddMvc();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            /**
            app.UseMvc(routes => {
                routes.MapRoute( 
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
            */
            SeedData.EnsurePopulated(app); 
        }
    }
}
