using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace sislte.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Announces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lang = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Theory = table.Column<int>(type: "integer", nullable: false),
                    Ects = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scholarships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scholarships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    AvatarURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course_CourseProgram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    CourseProgramId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course_CourseProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_CourseProgram_CoursePrograms_CourseProgramId",
                        column: x => x.CourseProgramId,
                        principalTable: "CoursePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Course_CourseProgram_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailedStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    FullName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    EmergencyPhone = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Education = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    EarnedCredits = table.Column<int>(type: "integer", nullable: false),
                    Gpa = table.Column<double>(type: "double precision", nullable: false),
                    Loans = table.Column<double>(type: "double precision", nullable: false),
                    AdvisorId = table.Column<int>(type: "integer", nullable: false),
                    ScholarshipId = table.Column<int>(type: "integer", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EntranceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GraduateDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedStudents_Advisors_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedStudents_Scholarships_ScholarshipId",
                        column: x => x.ScholarshipId,
                        principalTable: "Scholarships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DetailedStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DetailedStudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clubs_DetailedStudents_DetailedStudentId",
                        column: x => x.DetailedStudentId,
                        principalTable: "DetailedStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    DetailedStudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_DetailedStudents_DetailedStudentId",
                        column: x => x.DetailedStudentId,
                        principalTable: "DetailedStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transcripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DetailedStudentId = table.Column<int>(type: "integer", nullable: false),
                    Gpa = table.Column<double>(type: "double precision", nullable: true),
                    Tatc = table.Column<int>(type: "integer", nullable: true),
                    Tacc = table.Column<int>(type: "integer", nullable: true),
                    Sac = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcripts_DetailedStudents_DetailedStudentId",
                        column: x => x.DetailedStudentId,
                        principalTable: "DetailedStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCoursePrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TranscriptId = table.Column<int>(type: "integer", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lang = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCoursePrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCoursePrograms_Transcripts_TranscriptId",
                        column: x => x.TranscriptId,
                        principalTable: "Transcripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentCourseProgramId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Semesters_StudentCoursePrograms_StudentCourseProgramId",
                        column: x => x.StudentCourseProgramId,
                        principalTable: "StudentCoursePrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    StudentSemesterId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Grades_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Semesters_StudentSemesterId",
                        column: x => x.StudentSemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GradeId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Presence = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceEntries_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Advisors",
                columns: new[] { "Id", "Email", "FullName", "Password" },
                values: new object[] { 1, "", "", "" });

            migrationBuilder.InsertData(
                table: "Announces",
                columns: new[] { "Id", "Date", "Message", "Title" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 6, 7), "The system will be down for maintenance this weekend.", "System Maintenance" },
                    { 2, new DateOnly(2025, 6, 3), "Final exam schedule is now available.", "Exam Schedule Released" },
                    { 3, new DateOnly(2025, 5, 28), "New digital resources have been added to the library.", "Library Update" },
                    { 4, new DateOnly(2025, 6, 15), "The university will be closed on June 15 for National Day.", "Holiday Notice" },
                    { 5, new DateOnly(2025, 7, 5), "Graduation ceremony will be held on July 5 at 10 AM.", "Graduation Ceremony" },
                    { 6, new DateOnly(2025, 6, 1), "Check out the updated cafeteria menu for this month.", "New Cafeteria Menu" },
                    { 7, new DateOnly(2025, 6, 10), "Fall semester course registration opens next Monday.", "Course Registration" },
                    { 8, new DateOnly(2025, 6, 4), "IT helpdesk will be unavailable on June 4 from 2–4 PM.", "IT Support Downtime" },
                    { 9, new DateOnly(2025, 6, 2), "Please complete the end-of-term feedback survey.", "Survey Reminder" },
                    { 10, new DateOnly(2025, 6, 5), "Visit the career center for summer internship listings.", "New Internship Opportunities" }
                });

            migrationBuilder.InsertData(
                table: "CoursePrograms",
                columns: new[] { "Id", "Code", "Lang", "Name" },
                values: new object[,]
                {
                    { 1, "ES", "AZ", "Economics" },
                    { 2, "CE", "EN", "Computer Engineering" },
                    { 3, "CS", "EN", "Computer Science" },
                    { 4, "IT", "AZ", "Information Technology" },
                    { 5, "IT", "EN", "Information Technology" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "Ects", "Name", "Theory" },
                values: new object[,]
                {
                    { 1, "IT 113", 3, "Information management", 1 },
                    { 2, "IT 115", 3, "Information technologies", 1 },
                    { 3, "IT 188", 7, "Computer-aided design", 2 },
                    { 4, "IT 205", 7, "Object oriented programming", 2 },
                    { 5, "IT 252", 5, "Basics of programming- 2", 2 },
                    { 6, "IT 338", 6, "Internet Technologies", 2 },
                    { 7, "IT 383", 7, "Computer modeling", 2 },
                    { 8, "IT 385", 7, "Management in information systems", 2 },
                    { 9, "IT 386", 6, "Web programming", 2 },
                    { 10, "IT 387", 7, "Introduction to multi-platform programming", 2 },
                    { 11, "IT 388", 7, "Modern programming languages- 2", 2 },
                    { 12, "IT 390", 7, "Mobile application design", 2 },
                    { 13, "IT 437", 6, "Machine Learning", 2 },
                    { 14, "IT 451", 6, "Data Mining and Storing", 2 },
                    { 15, "IT 485", 6, "Database programming", 2 },
                    { 16, "IT 487", 6, "Data analytics and information management", 2 },
                    { 17, "MINF 273", 7, "Mathematical programming", 2 },
                    { 18, "BA 108", 3, "Principles of Entrepreneurship and Introduction to Business", 1 },
                    { 19, "BA 111", 9, "Fundamentals of Management", 1 },
                    { 20, "ECON 163", 9, "Engineering Economics", 1 },
                    { 21, "ENG 010", 5, "English for business and academic communication (reading and writing)", 0 },
                    { 22, "ENG 020", 5, "English for business and academic communication (listening and speaking)", 0 },
                    { 23, "ENG 030", 5, "English for business and academic communication (for academic purposes)", 0 },
                    { 24, "GER 010", 5, "German business and academic communication (reading and writing)", 0 },
                    { 25, "GER 020", 5, "German for business and academic communication (listening and speaking)", 0 },
                    { 26, "GER 030", 5, "German for business and academic communication (for academic purposes)", 0 },
                    { 27, "LAW 110", 3, "Constitution of Republic of Azerbaijan and Fundamentals of Law", 1 },
                    { 28, "MATH 285", 5, "Numerical analysis", 2 },
                    { 29, "MINF 167", 3, "Logic", 1 },
                    { 30, "PA 139", 3, "Politology", 1 },
                    { 31, "PHIL 159", 3, "Philosophy", 1 },
                    { 32, "SOC 110", 3, "Sociology", 1 },
                    { 33, "SOC 150", 3, "Introduction to Multiculturalism", 1 },
                    { 34, "SOC 180", 3, "Ethics and aesthetics", 1 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AvatarURL", "Email", "Password", "Role" },
                values: new object[] { 1, "/avatars/default.jpg", "a@a.az", "$2a$11$/fnIBRXxHuq8k18X4RmkfuY.eut31s.ZyyVn/Qe/M8DAw73CkLOjK", 2 });

            migrationBuilder.InsertData(
                table: "Course_CourseProgram",
                columns: new[] { "Id", "CourseId", "CourseProgramId" },
                values: new object[,]
                {
                    { 1, 17, 2 },
                    { 2, 3, 5 },
                    { 3, 29, 1 },
                    { 4, 8, 3 },
                    { 5, 12, 4 },
                    { 6, 21, 1 },
                    { 7, 5, 3 },
                    { 8, 33, 5 },
                    { 9, 1, 2 },
                    { 10, 26, 4 }
                });

            migrationBuilder.InsertData(
                table: "DetailedStudents",
                columns: new[] { "Id", "AdvisorId", "BirthDate", "EarnedCredits", "Education", "EmergencyPhone", "EntranceDate", "FullName", "Gpa", "GraduateDate", "Loans", "Location", "Notes", "Phone", "ScholarshipId", "StudentId" },
                values: new object[] { 1, 1, new DateOnly(1999, 9, 10), 30, "", "", new DateOnly(2020, 5, 1), "", 3.9700000000000002, new DateOnly(2024, 5, 1), 0.0, "", null, "", null, 1 });

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "Id", "DetailedStudentId", "Gpa", "Sac", "Tacc", "Tatc" },
                values: new object[] { 1, 1, null, null, null, null });

            migrationBuilder.InsertData(
                table: "StudentCoursePrograms",
                columns: new[] { "Id", "Code", "Lang", "Name", "TranscriptId" },
                values: new object[] { 1, "IT1", "EN", "Information Technologies", 1 });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "EndDate", "StartDate", "StudentCourseProgramId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2026, 6, 3), new DateOnly(2025, 12, 3), 1 },
                    { 2, new DateOnly(2027, 6, 3), new DateOnly(2026, 12, 3), 1 },
                    { 3, new DateOnly(2028, 6, 3), new DateOnly(2027, 12, 3), 1 },
                    { 5, new DateOnly(2029, 6, 3), new DateOnly(2028, 12, 3), 1 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Act1", "Act2", "Att", "CourseId", "Final", "Iw", "Mark", "StudentSemesterId", "Sum" },
                values: new object[,]
                {
                    { 1, 14, 13, 9, 1, 48, 10, "A", 1, 94 },
                    { 2, 12, 14, 10, 2, 45, 9, "A", 1, 90 },
                    { 3, 11, 13, 8, 3, 40, 9, "B", 1, 81 },
                    { 4, 10, 12, 7, 4, 38, 9, "C", 1, 76 },
                    { 5, 9, 11, 8, 5, 34, 8, "C", 1, 70 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceEntries_GradeId",
                table: "AttendanceEntries",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_DetailedStudentId",
                table: "Clubs",
                column: "DetailedStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseProgram_CourseId",
                table: "Course_CourseProgram",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_CourseProgram_CourseProgramId",
                table: "Course_CourseProgram",
                column: "CourseProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedStudents_AdvisorId",
                table: "DetailedStudents",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedStudents_ScholarshipId",
                table: "DetailedStudents",
                column: "ScholarshipId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedStudents_StudentId",
                table: "DetailedStudents",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentSemesterId",
                table: "Grades",
                column: "StudentSemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Semesters_StudentCourseProgramId",
                table: "Semesters",
                column: "StudentCourseProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_DetailedStudentId",
                table: "Skills",
                column: "DetailedStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCoursePrograms_TranscriptId",
                table: "StudentCoursePrograms",
                column: "TranscriptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_DetailedStudentId",
                table: "Transcripts",
                column: "DetailedStudentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announces");

            migrationBuilder.DropTable(
                name: "AttendanceEntries");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Course_CourseProgram");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "CoursePrograms");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "StudentCoursePrograms");

            migrationBuilder.DropTable(
                name: "Transcripts");

            migrationBuilder.DropTable(
                name: "DetailedStudents");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.DropTable(
                name: "Scholarships");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
