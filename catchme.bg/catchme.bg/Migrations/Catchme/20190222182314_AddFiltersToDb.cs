using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations.Catchme
{
    public partial class AddFiltersToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BodyTypeFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypeFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChildrenFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildrenFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DietFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DrinksFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinksFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DrugsFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugsFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EducationFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EthnicityFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EthnicityFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EyeColorFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyeColorFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GenderFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HairColorFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairColorFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HeightFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeightFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LanguagesFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagesFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LookingForFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookingForFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatusFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatusFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReligionFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SmokesFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmokesFilter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WeightFilter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilterUserId = table.Column<string>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Selected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightFilter", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgeFilter");

            migrationBuilder.DropTable(
                name: "BodyTypeFilter");

            migrationBuilder.DropTable(
                name: "ChildrenFilter");

            migrationBuilder.DropTable(
                name: "DietFilter");

            migrationBuilder.DropTable(
                name: "DrinksFilter");

            migrationBuilder.DropTable(
                name: "DrugsFilter");

            migrationBuilder.DropTable(
                name: "EducationFilter");

            migrationBuilder.DropTable(
                name: "EthnicityFilter");

            migrationBuilder.DropTable(
                name: "EyeColorFilter");

            migrationBuilder.DropTable(
                name: "GenderFilter");

            migrationBuilder.DropTable(
                name: "HairColorFilter");

            migrationBuilder.DropTable(
                name: "HeightFilter");

            migrationBuilder.DropTable(
                name: "LanguagesFilter");

            migrationBuilder.DropTable(
                name: "LookingForFilter");

            migrationBuilder.DropTable(
                name: "MaritalStatusFilter");

            migrationBuilder.DropTable(
                name: "ReligionFilter");

            migrationBuilder.DropTable(
                name: "SmokesFilter");

            migrationBuilder.DropTable(
                name: "WeightFilter");
        }
    }
}
