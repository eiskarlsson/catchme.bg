﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using catchme.bg.Data;

namespace catchme.bg.Migrations.Catchme
{
    [DbContext(typeof(CatchmeContext))]
    partial class CatchmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("catchme.bg.Areas.Identity.Data.CatchmebgUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.Property<byte[]>("UserPhoto");

                    b.HasKey("Id");

                    b.ToTable("CatchmebgUser");
                });

            modelBuilder.Entity("catchme.bg.Models.Age", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Age");
                });

            modelBuilder.Entity("catchme.bg.Models.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionID");

                    b.Property<int>("SelectedAnswer");

                    b.Property<string>("UserName");

                    b.HasKey("ID");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("catchme.bg.Models.BodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("BodyType");
                });

            modelBuilder.Entity("catchme.bg.Models.Children", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("catchme.bg.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("catchme.bg.Models.Drinks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("catchme.bg.Models.Drugs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("catchme.bg.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("catchme.bg.Models.Ethnicity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Ethnicity");
                });

            modelBuilder.Entity("catchme.bg.Models.EyeColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EyeColor");
                });

            modelBuilder.Entity("catchme.bg.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("catchme.bg.Models.HairColor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("HairColor");
                });

            modelBuilder.Entity("catchme.bg.Models.Height", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Height");
                });

            modelBuilder.Entity("catchme.bg.Models.Languages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("catchme.bg.Models.LookingFor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LookingFor");
                });

            modelBuilder.Entity("catchme.bg.Models.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatus");
                });

            modelBuilder.Entity("catchme.bg.Models.MessageDetail", b =>
                {
                    b.Property<long>("MessageDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message");

                    b.Property<string>("UserName");

                    b.HasKey("MessageDetailId");

                    b.ToTable("MessageDetails");
                });

            modelBuilder.Entity("catchme.bg.Models.Pets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("catchme.bg.Models.PrivateMessageDetail", b =>
                {
                    b.Property<long>("PrivateMessageDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PrivateMessageDetailId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message");

                    b.Property<string>("UserNameFrom")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.Property<string>("UserNameTo")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true);

                    b.HasKey("PrivateMessageDetailId");

                    b.ToTable("PrivateMessageDetails");
                });

            modelBuilder.Entity("catchme.bg.Models.Profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateLastChange");

                    b.Property<string>("Details");

                    b.Property<string>("EducationDescription");

                    b.Property<string>("Job");

                    b.Property<string>("JobDescription");

                    b.Property<string>("ProfileUserId");

                    b.Property<int?>("SelectedAge")
                        .IsRequired();

                    b.Property<int?>("SelectedBodyType")
                        .IsRequired();

                    b.Property<int?>("SelectedChildren")
                        .IsRequired();

                    b.Property<int?>("SelectedDiet")
                        .IsRequired();

                    b.Property<int?>("SelectedDrinks")
                        .IsRequired();

                    b.Property<int?>("SelectedDrugs")
                        .IsRequired();

                    b.Property<int?>("SelectedEducation")
                        .IsRequired();

                    b.Property<int?>("SelectedEthnicity")
                        .IsRequired();

                    b.Property<int?>("SelectedEyeColor")
                        .IsRequired();

                    b.Property<int?>("SelectedGender")
                        .IsRequired();

                    b.Property<int?>("SelectedHairColor")
                        .IsRequired();

                    b.Property<int?>("SelectedHeight")
                        .IsRequired();

                    b.Property<int?>("SelectedLanguages")
                        .IsRequired();

                    b.Property<int?>("SelectedLookingFor")
                        .IsRequired();

                    b.Property<int?>("SelectedMaritalStatus")
                        .IsRequired();

                    b.Property<int?>("SelectedPets")
                        .IsRequired();

                    b.Property<int?>("SelectedReligion")
                        .IsRequired();

                    b.Property<int?>("SelectedSmokes")
                        .IsRequired();

                    b.Property<int?>("SelectedWeight")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ProfileUserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("catchme.bg.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText1");

                    b.Property<string>("AnswerText2");

                    b.Property<string>("Language");

                    b.Property<int>("QuestionID");

                    b.Property<string>("QuestionText");

                    b.HasKey("ID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("catchme.bg.Models.Religion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Religion");
                });

            modelBuilder.Entity("catchme.bg.Models.Smokes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Smokes");
                });

            modelBuilder.Entity("catchme.bg.Models.Weight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Weight");
                });

            modelBuilder.Entity("catchme.bg.Models.Profile", b =>
                {
                    b.HasOne("catchme.bg.Areas.Identity.Data.CatchmebgUser", "ProfileUser")
                        .WithMany()
                        .HasForeignKey("ProfileUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
