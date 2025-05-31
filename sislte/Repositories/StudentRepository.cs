using sislte.Core;
using sislte.Models;
using sislte.ViewModels;

namespace sislte.Repository;

public class StudentRepository(SisContext context) : IStudentRepository
{
    private readonly SisContext _context = context;

    public static readonly List<Skill> SkillsExample = new List<Skill>()
    {
        new Skill
        {
            Name = "C#",
            Description = "Object-oriented programming language developed by Microsoft.",
            Type = "Programming Language",
            Category = "Software Development"
        },
        new Skill
        {
            Name = "ASP.NET Core",
            Description = "A cross-platform framework for building web applications and APIs.",
            Type = "Web Framework",
            Category = "Web Development"
        },
        new Skill
        {
            Name = "SQL",
            Description = "Language used for managing and querying relational databases.",
            Type = "Query Language",
            Category = "Database Management"
        },
        new Skill
        {
            Name = "HTML/CSS",
            Description = "Standard markup and styling languages for building web pages.",
            Type = "Frontend",
            Category = "Web Development"
        },
        new Skill
        {
            Name = "JavaScript",
            Description = "High-level scripting language used to create dynamic web content.",
            Type = "Scripting Language",
            Category = "Frontend Development"
        },
        new Skill
        {
            Name = "Git",
            Description = "Distributed version control system for tracking changes in source code.",
            Type = "Tool",
            Category = "Version Control"
        },
        new Skill
        {
            Name = "Azure",
            Description = "Microsoft's cloud computing platform and services.",
            Type = "Cloud Platform",
            Category = "Cloud Computing"
        },
        new Skill
        {
            Name = "Docker",
            Description = "Tool designed to make it easier to create, deploy, and run applications using containers.",
            Type = "Containerization",
            Category = "DevOps"
        },
        new Skill
        {
            Name = "PowerShell",
            Description = "Task automation and configuration management framework.",
            Type = "Scripting",
            Category = "System Administration"
        },
        new Skill
        {
            Name = "Linux",
            Description = "Open-source operating system used for servers and development.",
            Type = "Operating System",
            Category = "System Administration"
        }
    };

    public static readonly Student StudentExample = new Student()
    {
        FullName = "Sekiro",
        AvatarURL = "/assets/img/studphoto.jpg",
        Program = "Internet Technologies",
        Gpa = 3.74,
        CoursesCount = 30,
        FriendsCount = 68,
        Education = "B.S. in Information Technologies from Baku Engineering University ",
        Location = "Sumgait, Azerbaijan",
        Skills = string.Join(", ", SkillsExample.Select(s => s.Name)),
        Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam fermentum enim neque."
    };

    public static readonly List<DetailedInfo> DetailedInfosExample = new List<DetailedInfo>()
    {
        new DetailedInfo("Full Name", "Sekiro Wolf Owl"),
        new DetailedInfo("Student ID", "202312345"),
        new DetailedInfo("Email", "jane.doe@example.edu"),
        new DetailedInfo("Phone Number", "+1 (555) 123-4567"),
        new DetailedInfo("Date of Birth", "2003-05-12"),
        new DetailedInfo("Enrollment Status", "Active"),
        new DetailedInfo("Program", "Bachelor of Science in Computer Science"),
        new DetailedInfo("Year of Study", "3rd Year"),
        new DetailedInfo("GPA", "3.75"),
        new DetailedInfo("Credits Earned", "90"),
        new DetailedInfo("Expected Graduation Date", "May 2026"),
        new DetailedInfo("Advisor", "Dr. Alan Smith"),
        new DetailedInfo("Loans", "Yes"),
        new DetailedInfo("Scholarship Status", "Awarded (Merit-Based)"),
        new DetailedInfo("Tuition Balance", "$1,500"),
        new DetailedInfo("Courses Enrolled",
            "CS301: Algorithms, CS320: Web Development, MATH210: Linear Algebra, ENG205: Technical Writing"),
        new DetailedInfo("Attendance Rate", "92%"),
        new DetailedInfo("Library Fines", "$0"),
        new DetailedInfo("Internship Placement", "In Progress"),
        new DetailedInfo("Clubs Joined", "Women in Tech, Robotics Club"),
        new DetailedInfo("Emergency Contact", "Mary Doe, +1 (555) 987-6543")
    };

    public StudentHomeViewModel Get()
    {
        return new StudentHomeViewModel
        {
            Student = StudentExample,
            DetailedInfos = DetailedInfosExample
        };
    }

    public EditAboutMeViewModel GetEditAboutMe()
    {
        return new EditAboutMeViewModel
        {
            Student = StudentExample,
        };
    }

    public void Add(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public Student? GetById(int id)
    {
        return _context.Students.FirstOrDefault(s => s.Id == id);
    }

    public Student? GetByEmail(string email)
    {
        return _context.Students.FirstOrDefault(s => s.Email == email);
    }
}