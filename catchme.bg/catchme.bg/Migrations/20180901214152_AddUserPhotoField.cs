using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace catchme.bg.Migrations
{
    public partial class AddUserPhotoField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "UserPhoto",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPhoto",
                table: "AspNetUsers");
        }
    }
}
