﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using catchme.bg.Data;

namespace catchme.bg.Migrations.Catchme
{
    [DbContext(typeof(CatchmeContext))]
    [Migration("20181207132922_CreateQuestionsSchemaAddLanguage")]
    partial class CreateQuestionsSchemaAddLanguage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("catchme.bg.Models.Question", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnswerText1");

                    b.Property<string>("AnswerText2");

                    b.Property<string>("Language");

                    b.Property<string>("QuestionText");

                    b.HasKey("ID");

                    b.ToTable("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}