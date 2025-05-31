using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sislte.Models;

public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Code { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Theory { get; set; }
    [Required]
    public int Ects { get; set; }
    [Required]
    public int Grade { get; set; }
    [Required]
    public string Mark { get; set; } = "";

    public static List<Course> GetExampleCourses()
    {
        return
        [
            // AE Courses
            new Course { Code = "IT 113", Name = "Information management", Theory = 1, Ects = 3, Mark = "B", Grade = 82 },
            new Course { Code = "IT 115", Name = "Information technologies", Theory = 1, Ects = 3, Mark = "A", Grade = 95 },
            new Course { Code = "IT 188", Name = "Computer-aided design", Theory = 2, Ects = 7, Mark = "B+", Grade = 88 },
            new Course { Code = "IT 205", Name = "Object oriented programming", Theory = 2, Ects = 7, Mark = "A-", Grade = 90 },
            new Course { Code = "IT 252", Name = "Basics of programming- 2", Theory = 2, Ects = 5, Mark = "B", Grade = 80 },
            new Course { Code = "IT 338", Name = "Internet Technologies", Theory = 2, Ects = 6, Mark = "B-", Grade = 78 },
            new Course { Code = "IT 383", Name = "Computer modeling", Theory = 2, Ects = 7, Mark = "C+", Grade = 74 },
            new Course { Code = "IT 385", Name = "Management in information systems", Theory = 2, Ects = 7, Mark = "A", Grade = 91 },
            new Course { Code = "IT 386", Name = "Web programming", Theory = 2, Ects = 6, Mark = "B+", Grade = 85 },
            new Course { Code = "IT 387", Name = "Introduction to multi-platform programming", Theory = 2, Ects = 7, Mark = "A", Grade = 94 },
            new Course { Code = "IT 388", Name = "Modern programming languages- 2", Theory = 2, Ects = 7, Mark = "A-", Grade = 89 },
            new Course { Code = "IT 390", Name = "Mobile application design", Theory = 2, Ects = 7, Mark = "B+", Grade = 87 },
            new Course { Code = "IT 437", Name = "Machine Learning", Theory = 2, Ects = 6, Mark = "A", Grade = 93 },
            new Course { Code = "IT 451", Name = "Data Mining and Storing", Theory = 2, Ects = 6, Mark = "A-", Grade = 90 },
            new Course { Code = "IT 485", Name = "Database programming", Theory = 2, Ects = 6, Mark = "B", Grade = 81 },
            new Course { Code = "IT 487", Name = "Data analytics and information management", Theory = 2, Ects = 6, Mark = "B+", Grade = 86 },
            new Course { Code = "MINF 273", Name = "Mathematical programming", Theory = 2, Ects = 7, Mark = "B-", Grade = 77 },

            // NAE Courses
            new Course { Code = "BA 108", Name = "Principles of Entrepreneurship and Introduction to Business", Theory = 1, Ects = 3, Mark = "C+", Grade = 73 },
            new Course { Code = "BA 111", Name = "Fundamentals of Management", Theory = 1, Ects = 9, Mark = "A", Grade = 96 },
            new Course { Code = "ECON 163", Name = "Engineering Economics", Theory = 1, Ects = 9, Mark = "B", Grade = 84 },
            new Course { Code = "ENG 010", Name = "English for business and academic communication (reading and writing)", Theory = 0, Ects = 5, Mark = "A-", Grade = 90 },
            new Course { Code = "ENG 020", Name = "English for business and academic communication (listening and speaking)", Theory = 0, Ects = 5, Mark = "B+", Grade = 85 },
            new Course { Code = "ENG 030", Name = "English for business and academic communication (for academic purposes)", Theory = 0, Ects = 5, Mark = "A", Grade = 93 },
            new Course { Code = "GER 010", Name = "German business and academic communication (reading and writing)", Theory = 0, Ects = 5, Mark = "B", Grade = 82 },
            new Course { Code = "GER 020", Name = "German for business and academic communication (listening and speaking)", Theory = 0, Ects = 5, Mark = "B-", Grade = 78 },
            new Course { Code = "GER 030", Name = "German for business and academic communication (for academic purposes)", Theory = 0, Ects = 5, Mark = "C+", Grade = 74 },
            new Course { Code = "LAW 110", Name = "Constitution of Republic of Azerbaijan and Fundamentals of Law", Theory = 1, Ects = 3, Mark = "B+", Grade = 87 },
            new Course { Code = "MATH 285", Name = "Numerical analysis", Theory = 2, Ects = 5, Mark = "B", Grade = 80 },
            new Course { Code = "MINF 167", Name = "Logic", Theory = 1, Ects = 3, Mark = "B+", Grade = 86 },
            new Course { Code = "PA 139", Name = "Politology", Theory = 1, Ects = 3, Mark = "C", Grade = 70 },
            new Course { Code = "PHIL 159", Name = "Philosophy", Theory = 1, Ects = 3, Mark = "B-", Grade = 77 },
            new Course { Code = "SOC 110", Name = "Sociology", Theory = 1, Ects = 3, Mark = "C+", Grade = 72 },
            new Course { Code = "SOC 150", Name = "Introduction to Multiculturalism", Theory = 1, Ects = 3, Mark = "A", Grade = 92 },
            new Course { Code = "SOC 180", Name = "Ethics and aesthetics", Theory = 1, Ects = 3, Mark = "B", Grade = 83 }
        ];
    }
}