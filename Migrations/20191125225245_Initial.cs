using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace eYummy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryDesc = table.Column<string>(nullable: true),
                    CategoryImg = table.Column<string>(nullable: true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "IngredientDetails",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IngredientString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientDetails", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "ModalDetails",
                columns: table => new
                {
                    ModalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataTarget = table.Column<string>(nullable: true),
                    ModalName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModalDetails", x => x.ModalId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<int>(nullable: false),
                    CookTime = table.Column<int>(nullable: false),
                    DateTimeUpdate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FileToUpload = table.Column<string>(nullable: true),
                    Prep = table.Column<string>(nullable: true),
                    RecipeTitle = table.Column<string>(nullable: true),
                    Servings = table.Column<string>(nullable: true),
                    ServingsMax = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    Yield = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "ReviewCommentDetails",
                columns: table => new
                {
                    ReviewCommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rate = table.Column<int>(nullable: false),
                    ReviewComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewCommentDetails", x => x.ReviewCommentId);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_IngredientDetails_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "IngredientDetails",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeModals",
                columns: table => new
                {
                    ModalId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeModals", x => new { x.ModalId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeModals_ModalDetails_ModalId",
                        column: x => x.ModalId,
                        principalTable: "ModalDetails",
                        principalColumn: "ModalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeModals_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeReviewComments",
                columns: table => new
                {
                    ReviewCommentId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeReviewComments", x => new { x.ReviewCommentId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeReviewComments_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeReviewComments_ReviewCommentDetails_ReviewCommentId",
                        column: x => x.ReviewCommentId,
                        principalTable: "ReviewCommentDetails",
                        principalColumn: "ReviewCommentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeModals_RecipeId",
                table: "RecipeModals",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeReviewComments_RecipeId",
                table: "RecipeReviewComments",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeModals");

            migrationBuilder.DropTable(
                name: "RecipeReviewComments");

            migrationBuilder.DropTable(
                name: "IngredientDetails");

            migrationBuilder.DropTable(
                name: "ModalDetails");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "ReviewCommentDetails");
        }
    }
}
