using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sislte.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Act1 = table.Column<int>(type: "integer", nullable: false),
                    Act2 = table.Column<int>(type: "integer", nullable: false),
                    Att = table.Column<int>(type: "integer", nullable: false),
                    Iw = table.Column<int>(type: "integer", nullable: false),
                    Final = table.Column<int>(type: "integer", nullable: false),
                    Sum = table.Column<int>(type: "integer", nullable: false),
                    Mark = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    AvatarURL = table.Column<string>(type: "text", nullable: true),
                    Program = table.Column<string>(type: "text", nullable: true),
                    Gpa = table.Column<double>(type: "double precision", nullable: true),
                    CoursesCount = table.Column<int>(type: "integer", nullable: true),
                    FriendsCount = table.Column<int>(type: "integer", nullable: true),
                    Education = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Skills = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
