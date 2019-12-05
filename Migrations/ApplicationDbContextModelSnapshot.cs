﻿// <auto-generated />
using eYummy.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace eYummy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("eYummy.Models.CategoryModels.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDesc");

                    b.Property<string>("CategoryImg");

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("eYummy.Models.IngredientModels.IngredientDetail", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IngredientString");

                    b.HasKey("IngredientId");

                    b.ToTable("IngredientDetails");
                });

            modelBuilder.Entity("eYummy.Models.IngredientModels.RecipeIngredient", b =>
                {
                    b.Property<int>("IngredientId");

                    b.Property<int>("RecipeId");

                    b.HasKey("IngredientId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeIngredients");
                });

            modelBuilder.Entity("eYummy.Models.ModalModels.ModalDetail", b =>
                {
                    b.Property<int>("ModalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataTarget");

                    b.Property<string>("ModalName");

                    b.HasKey("ModalId");

                    b.ToTable("ModalDetails");
                });

            modelBuilder.Entity("eYummy.Models.ModalModels.RecipeModal", b =>
                {
                    b.Property<int>("ModalId");

                    b.Property<int>("RecipeId");

                    b.HasKey("ModalId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeModals");
                });

            modelBuilder.Entity("eYummy.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<int>("CookTime");

                    b.Property<DateTime>("DateTimeUpdate");

                    b.Property<string>("Description");

                    b.Property<string>("FileToUpload");

                    b.Property<string>("Prep");

                    b.Property<string>("RecipeTitle");

                    b.Property<string>("Servings");

                    b.Property<int>("ServingsMax");

                    b.Property<int>("Total");

                    b.Property<string>("Yield");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("eYummy.Models.ReviewCommentModels.RecipeReviewComment", b =>
                {
                    b.Property<int>("ReviewCommentId");

                    b.Property<int>("RecipeId");

                    b.HasKey("ReviewCommentId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeReviewComments");
                });

            modelBuilder.Entity("eYummy.Models.ReviewCommentModels.ReviewCommentDetail", b =>
                {
                    b.Property<int>("ReviewCommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnonymousId");

                    b.Property<int>("Rate");

                    b.Property<string>("ReviewComment");

                    b.Property<DateTime>("ReviewDateTime");

                    b.HasKey("ReviewCommentId");

                    b.ToTable("ReviewCommentDetails");
                });

            modelBuilder.Entity("eYummy.Models.IngredientModels.RecipeIngredient", b =>
                {
                    b.HasOne("eYummy.Models.IngredientModels.IngredientDetail", "IngredientDetail")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eYummy.Models.Recipe", "Recipe")
                        .WithMany("RecipeIngredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eYummy.Models.ModalModels.RecipeModal", b =>
                {
                    b.HasOne("eYummy.Models.ModalModels.ModalDetail", "ModalDetail")
                        .WithMany("RecipeModals")
                        .HasForeignKey("ModalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eYummy.Models.Recipe", "Recipe")
                        .WithMany("RecipeModals")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("eYummy.Models.ReviewCommentModels.RecipeReviewComment", b =>
                {
                    b.HasOne("eYummy.Models.Recipe", "Recipe")
                        .WithMany("RecipeReviewComments")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("eYummy.Models.ReviewCommentModels.ReviewCommentDetail", "ReviewCommentDetail")
                        .WithMany("RecipeReviewComments")
                        .HasForeignKey("ReviewCommentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
