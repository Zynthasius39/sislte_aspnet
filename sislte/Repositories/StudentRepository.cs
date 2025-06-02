using Microsoft.EntityFrameworkCore;
using sislte.Core;
using sislte.Models;
using sislte.ViewModels;

namespace sislte.Repository;

public class StudentRepository(SisContext context) : IStudentRepository
{
    public void Add(Student student)
    {
        context.Students.Add(student);
        context.SaveChanges();
    }

    public Student? GetById(int id)
    {
        return context.Students.FirstOrDefault(s => s.Id == id);
    }

    public Student? GetByEmail(string email)
    {
        return context.Students
            .Include(s => s.DetailedStudent)
            .FirstOrDefault(s => s.Email == email);
    }

    public void Update(Student student)
    {
        context.Students.Update(student);
        context.SaveChanges();
    }

    public void UpdateDetailed(DetailedStudent detailedStudent)
    {
        context.DetailedStudents.Update(detailedStudent);
        context.SaveChanges();
    }
}