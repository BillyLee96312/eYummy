using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using eYummy.Models.CategoryModels;
using eYummy.Models.RecipeModels;
using eYummy.Models.ModalModels;
using eYummy.Models.IngredientModels;
using eYummy.Models.ReviewCommentModels;

namespace eYummy.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
                    : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeModal> RecipeModals { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ModalDetail> ModalDetails { get; set; }

        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

        public DbSet<IngredientDetail> IngredientDetails { get; set; }

        public DbSet<RecipeReviewComment> RecipeReviewComments { get; set; }
        public DbSet<ReviewCommentDetail> ReviewCommentDetails { get; set; }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //RecipeIngredient Foreign Key builder
            modelBuilder.Entity<RecipeIngredient>().HasKey(u => new
            {
                u.IngredientId, u.RecipeId
            });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.IngredientDetail)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);
            
            modelBuilder.Entity<RecipeModal>().HasKey(m => new
            {
                m.ModalId, m.RecipeId
            });

            modelBuilder.Entity<RecipeModal>()
                .HasOne(rm => rm.Recipe)
                .WithMany(r => r.RecipeModals)
                .HasForeignKey(rm => rm.RecipeId);
            modelBuilder.Entity<RecipeModal>()
                .HasOne(rm => rm.ModalDetail)
                .WithMany(d => d.RecipeModals)
                .HasForeignKey(rm => rm.ModalId);

            modelBuilder.Entity<RecipeReviewComment>().HasKey(rc => new
            {
                rc.ReviewCommentId,
                rc.RecipeId
            });
            
            modelBuilder.Entity<RecipeReviewComment>()
                .HasOne(rc => rc.Recipe)
                .WithMany(r => r.RecipeReviewComments)
                .HasForeignKey(rc => rc.RecipeId);
            modelBuilder.Entity<RecipeReviewComment>()
                .HasOne(rc => rc.ReviewCommentDetail)
                .WithMany(d => d.RecipeReviewComments)
                .HasForeignKey(rc => rc.ReviewCommentId);

        }


    }
}
