using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmsWebCatalog.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Years = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfReleasing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    DirectorID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_Directors_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Films_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmsActors",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsActors", x => new { x.FilmId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_FilmsActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsActors_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName", "Years" },
                values: new object[,]
                {
                    { 1, "6/1/1996", "Tom", "Holland", 27 },
                    { 2, "9/1/1996", "Zendaya", "Coleman", 27 },
                    { 3, "6/27/1975", "Tobey", "Maguire", 48 },
                    { 4, "8/20/1983", "Andrew", "Garfield", 40 },
                    { 5, "10/9/1996", "Jacob", "Batalon", 27 },
                    { 6, "9/12/1997", "Sydney", "Sweeney", 26 },
                    { 7, "10/4/1989", "Dakota", "Johnson", 34 },
                    { 8, "6/4/1996", "Maria", "Bakalova", 27 },
                    { 9, "6/21/1979", "Chriss", "Pratt", 44 },
                    { 10, "4/4/1965", "Robert", "Downey Jr.", 58 },
                    { 11, "3/28/1981", "Julia", "Stiles", 42 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "271e8e92-e164-4e61-85de-0f458c323990", 0, "bf9b46a1-22ad-453c-adb8-3c5d85af4e39", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAED1ZV5K6gFOo5HyHxwcezyMJU6070D2DuhK9osUXG/5Sz5/KHqlh8koWVXgxgb31Ew==", null, false, "00709ec1-2849-40a3-bf38-0538d65f681a", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, "11/7/1954", "Gil Junger" },
                    { 2, "6/28/1981", "Jon Watts" },
                    { 3, "11/7/1978", "Will Gluck" },
                    { 4, "3/10/1970", "Ivaylo Penchev" },
                    { 5, "7/18/1971", "Joe Russo" },
                    { 6, "9/10/1968", "Guy Ritchie" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "action" },
                    { 2, "comedy" },
                    { 3, "mystery" },
                    { 4, "thriller" },
                    { 5, "drama" },
                    { 6, "romance" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "DateOfReleasing", "DirectorID", "GenreID", "Rating", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, "12/17/2021", 2, 1, 8.1999999999999993, "Spider-Man: No Way Home", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 2, "12/22/2023", 3, 2, 6.2999999999999998, "Anyone But You", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 3, "2/14/2024", 2, 1, 3.7000000000000002, "Madame Web", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 4, "6/4/2021", 4, 2, 7.7999999999999998, "Last Call", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 5, "5/5/2023", 1, 1, 7.9000000000000004, "Guardians of the Galaxy Vol. 3", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 6, "4/27/2018", 5, 5, 8.4000000000000004, "Avengers: Infinity War", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 7, "1/1/2010", 6, 3, 7.5999999999999996, "Sherlok Holmes", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 8, "3/31/1999", 1, 2, 7.2999999999999998, "10 things I hate you about you", "271e8e92-e164-4e61-85de-0f458c323990" },
                    { 9, "7/21/2023", 2, 5, 8.4000000000000004, "Oppenheimer", "271e8e92-e164-4e61-85de-0f458c323990" }
                });

            migrationBuilder.InsertData(
                table: "FilmsActors",
                columns: new[] { "ActorId", "FilmId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 4 },
                    { 8, 5 },
                    { 9, 5 },
                    { 1, 6 },
                    { 9, 6 },
                    { 10, 6 },
                    { 10, 7 },
                    { 11, 8 },
                    { 10, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_DirectorID",
                table: "Films",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Films_GenreID",
                table: "Films",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Films_UserID",
                table: "Films",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsActors_ActorId",
                table: "FilmsActors",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmsActors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "271e8e92-e164-4e61-85de-0f458c323990");
        }
    }
}
