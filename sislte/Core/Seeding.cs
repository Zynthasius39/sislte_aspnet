using Microsoft.EntityFrameworkCore;
using sislte.Models;

namespace sislte.Core;

public class Seeding
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
            new
            {
                Id = 1,
                Email = "a@a.az",
                Password = "$2a$11$/fnIBRXxHuq8k18X4RmkfuY.eut31s.ZyyVn/Qe/M8DAw73CkLOjK",
                AvatarURL = "/avatars/default.jpg",
                Role = Role.Student,
            }
        );

        modelBuilder.Entity<DetailedStudent>().HasData(
            new
            {
                Id = 1,
                StudentId = 1,
                AdvisorId = 1,
                FullName = "",
                BirthDate = DateOnly.FromDateTime(new DateTime(1999, 09, 10)),
                EntranceDate = DateOnly.FromDateTime(new DateTime(2020, 05, 01)),
                GraduateDate = DateOnly.FromDateTime(new DateTime(2024, 05, 01)),
                EarnedCredits = 30,
                Education = "",
                Phone = "",
                EmergencyPhone = "",
                Gpa = 3.97,
                Loans = 0.000,
                Location = "",
            }
        );

        modelBuilder.Entity<Transcript>().HasData(
            new
            {
                Id = 1,
                DetailedStudentId = 1,
            }
        );

        modelBuilder.Entity<StudentCourseProgram>().HasData(
            new
            {
                Id = 1,
                TranscriptId = 1,
                Code = "IT1",
                Name = "Information Technologies",
                Lang = "EN",
            }
        );

        modelBuilder.Entity<Advisor>().HasData(
            new
            {
                Id = 1,
                StudentCourseProgram = 1,
                Email = "",
                Password = "",
                FullName = "",
            }
        );

        var count = 1;
        var coursePrograms = new List<CourseProgram>
        {
            new CourseProgram
            {
                Id = count++,
                Name = "Economics",
                Code = "ES",
                Lang = "AZ",
            },
            new CourseProgram
            {
                Id = count++,
                Name = "Computer Engineering",
                Code = "CE",
                Lang = "EN",
            },
            new CourseProgram
            {
                Id = count++,
                Name = "Computer Science",
                Code = "CS",
                Lang = "EN",
            },
            new CourseProgram
            {
                Id = count++,
                Name = "Information Technology",
                Code = "IT",
                Lang = "AZ",
            },
            new CourseProgram
            {
                Id = count++,
                Name = "Information Technology",
                Code = "IT",
                Lang = "EN",
            },
        };
        modelBuilder.Entity<CourseProgram>().HasData(coursePrograms);
        var courses = new List<Course>
        {
            // AE Courses
            new Course { Code = "IT 113", Name = "Information management", Theory = 1, Ects = 3 },
            new Course { Code = "IT 115", Name = "Information technologies", Theory = 1, Ects = 3 },
            new Course { Code = "IT 188", Name = "Computer-aided design", Theory = 2, Ects = 7 },
            new Course { Code = "IT 205", Name = "Object oriented programming", Theory = 2, Ects = 7 },
            new Course { Code = "IT 252", Name = "Basics of programming- 2", Theory = 2, Ects = 5 },
            new Course { Code = "IT 338", Name = "Internet Technologies", Theory = 2, Ects = 6 },
            new Course { Code = "IT 383", Name = "Computer modeling", Theory = 2, Ects = 7 },
            new Course { Code = "IT 385", Name = "Management in information systems", Theory = 2, Ects = 7 },
            new Course { Code = "IT 386", Name = "Web programming", Theory = 2, Ects = 6 },
            new Course { Code = "IT 387", Name = "Introduction to multi-platform programming", Theory = 2, Ects = 7 },
            new Course { Code = "IT 388", Name = "Modern programming languages- 2", Theory = 2, Ects = 7 },
            new Course { Code = "IT 390", Name = "Mobile application design", Theory = 2, Ects = 7 },
            new Course { Code = "IT 437", Name = "Machine Learning", Theory = 2, Ects = 6 },
            new Course { Code = "IT 451", Name = "Data Mining and Storing", Theory = 2, Ects = 6 },
            new Course { Code = "IT 485", Name = "Database programming", Theory = 2, Ects = 6 },
            new Course { Code = "IT 487", Name = "Data analytics and information management", Theory = 2, Ects = 6 },
            new Course { Code = "MINF 273", Name = "Mathematical programming", Theory = 2, Ects = 7 },

            // NAE Courses
            new Course
            {
                Code = "BA 108", Name = "Principles of Entrepreneurship and Introduction to Business", Theory = 1,
                Ects = 3
            },
            new Course { Code = "BA 111", Name = "Fundamentals of Management", Theory = 1, Ects = 9 },
            new Course { Code = "ECON 163", Name = "Engineering Economics", Theory = 1, Ects = 9 },
            new Course
            {
                Code = "ENG 010", Name = "English for business and academic communication (reading and writing)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "ENG 020", Name = "English for business and academic communication (listening and speaking)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "ENG 030", Name = "English for business and academic communication (for academic purposes)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "GER 010", Name = "German business and academic communication (reading and writing)", Theory = 0,
                Ects = 5
            },
            new Course
            {
                Code = "GER 020", Name = "German for business and academic communication (listening and speaking)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "GER 030", Name = "German for business and academic communication (for academic purposes)",
                Theory = 0, Ects = 5
            },
            new Course
            {
                Code = "LAW 110", Name = "Constitution of Republic of Azerbaijan and Fundamentals of Law", Theory = 1,
                Ects = 3
            },
            new Course { Code = "MATH 285", Name = "Numerical analysis", Theory = 2, Ects = 5 },
            new Course { Code = "MINF 167", Name = "Logic", Theory = 1, Ects = 3 },
            new Course { Code = "PA 139", Name = "Politology", Theory = 1, Ects = 3 },
            new Course { Code = "PHIL 159", Name = "Philosophy", Theory = 1, Ects = 3 },
            new Course { Code = "SOC 110", Name = "Sociology", Theory = 1, Ects = 3 },
            new Course { Code = "SOC 150", Name = "Introduction to Multiculturalism", Theory = 1, Ects = 3 },
            new Course { Code = "SOC 180", Name = "Ethics and aesthetics", Theory = 1, Ects = 3 },
        };
        count = 1;
        var coursesSeed = new List<Course>();
        foreach (var course in courses)
        {
            coursesSeed.Add(new Course
            {
                Id = count++,
                Code = course.Code,
                Ects = course.Ects,
                Name = course.Name,
                Theory = course.Theory,
            });
        }

        modelBuilder.Entity<Course>().HasData(coursesSeed);

        var coursesCourseProgramsSeed = new List<Course_CourseProgram>
        {
            new Course_CourseProgram { Id = 1, CourseProgramId = 2, CourseId = 17 },
            new Course_CourseProgram { Id = 2, CourseProgramId = 5, CourseId = 3 },
            new Course_CourseProgram { Id = 3, CourseProgramId = 1, CourseId = 29 },
            new Course_CourseProgram { Id = 4, CourseProgramId = 3, CourseId = 8 },
            new Course_CourseProgram { Id = 5, CourseProgramId = 4, CourseId = 12 },
            new Course_CourseProgram { Id = 6, CourseProgramId = 1, CourseId = 21 },
            new Course_CourseProgram { Id = 7, CourseProgramId = 3, CourseId = 5 },
            new Course_CourseProgram { Id = 8, CourseProgramId = 5, CourseId = 33 },
            new Course_CourseProgram { Id = 9, CourseProgramId = 2, CourseId = 1 },
            new Course_CourseProgram { Id = 10, CourseProgramId = 4, CourseId = 26 }
        };
        modelBuilder.Entity<Course_CourseProgram>().HasData(coursesCourseProgramsSeed);

        var startDate = DateTime.Now;
        modelBuilder.Entity<StudentSemester>().HasData(
            [
                new StudentSemester
                {
                    Id = 1,
                    StudentCourseProgramId = 1,
                    StartDate = DateOnly.FromDateTime(startDate.AddMonths(6)),
                    EndDate = DateOnly.FromDateTime(startDate.AddMonths(12)),
                },
                new StudentSemester
                {
                    Id = 2,
                    StudentCourseProgramId = 1,
                    StartDate = DateOnly.FromDateTime(startDate.AddMonths(18)),
                    EndDate = DateOnly.FromDateTime(startDate.AddMonths(24)),
                },
                new StudentSemester
                {
                    Id = 3,
                    StudentCourseProgramId = 1,
                    StartDate = DateOnly.FromDateTime(startDate.AddMonths(30)),
                    EndDate = DateOnly.FromDateTime(startDate.AddMonths(36)),
                },
                new StudentSemester
                {
                    Id = 5,
                    StudentCourseProgramId = 1,
                    StartDate = DateOnly.FromDateTime(startDate.AddMonths(42)),
                    EndDate = DateOnly.FromDateTime(startDate.AddMonths(48)),
                },
            ]
        );

        var gradeSeeds = new List<Grade>
        {
            new Grade
            {
                Id = 1,
                StudentSemesterId = 1,
                CourseId = 1,
                Act1 = 14,
                Act2 = 13,
                Att = 9,
                Iw = 10,
                Final = 48,
                Sum = 94,
                Mark = "A"
            },
            new Grade
            {
                Id = 2,
                StudentSemesterId = 1,
                CourseId = 2,
                Act1 = 12,
                Act2 = 14,
                Att = 10,
                Iw = 9,
                Final = 45,
                Sum = 90,
                Mark = "A"
            },
            new Grade
            {
                Id = 3,
                StudentSemesterId = 1,
                CourseId = 3,
                Act1 = 11,
                Act2 = 13,
                Att = 8,
                Iw = 9,
                Final = 40,
                Sum = 81,
                Mark = "B"
            },
            new Grade
            {
                Id = 4,
                StudentSemesterId = 1,
                CourseId = 4,
                Act1 = 10,
                Act2 = 12,
                Att = 7,
                Iw = 9,
                Final = 38,
                Sum = 76,
                Mark = "C"
            },
            new Grade
            {
                Id = 5,
                StudentSemesterId = 1,
                CourseId = 5,
                Act1 = 9,
                Act2 = 11,
                Att = 8,
                Iw = 8,
                Final = 34,
                Sum = 70,
                Mark = "C"
            }
        };
        modelBuilder.Entity<Grade>().HasData(gradeSeeds);

        var announces = new List<Announce>
        {
            new Announce
            {
                Id = 1, Title = "System Maintenance", Message = "The system will be down for maintenance this weekend.",
                Date = new DateOnly(2025, 6, 7)
            },
            new Announce
            {
                Id = 2, Title = "Exam Schedule Released", Message = "Final exam schedule is now available.",
                Date = new DateOnly(2025, 6, 3)
            },
            new Announce
            {
                Id = 3, Title = "Library Update", Message = "New digital resources have been added to the library.",
                Date = new DateOnly(2025, 5, 28)
            },
            new Announce
            {
                Id = 4, Title = "Holiday Notice",
                Message = "The university will be closed on June 15 for National Day.", Date = new DateOnly(2025, 6, 15)
            },
            new Announce
            {
                Id = 5, Title = "Graduation Ceremony", Message = "Graduation ceremony will be held on July 5 at 10 AM.",
                Date = new DateOnly(2025, 7, 5)
            },
            new Announce
            {
                Id = 6, Title = "New Cafeteria Menu", Message = "Check out the updated cafeteria menu for this month.",
                Date = new DateOnly(2025, 6, 1)
            },
            new Announce
            {
                Id = 7, Title = "Course Registration", Message = "Fall semester course registration opens next Monday.",
                Date = new DateOnly(2025, 6, 10)
            },
            new Announce
            {
                Id = 8, Title = "IT Support Downtime",
                Message = "IT helpdesk will be unavailable on June 4 from 2–4 PM.", Date = new DateOnly(2025, 6, 4)
            },
            new Announce
            {
                Id = 9, Title = "Survey Reminder", Message = "Please complete the end-of-term feedback survey.",
                Date = new DateOnly(2025, 6, 2)
            },
            new Announce
            {
                Id = 10, Title = "New Internship Opportunities",
                Message = "Visit the career center for summer internship listings.", Date = new DateOnly(2025, 6, 5)
            }
        };
        modelBuilder.Entity<Announce>().HasData(
            announces);
    }
}