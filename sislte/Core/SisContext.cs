using Microsoft.EntityFrameworkCore;
using sislte.Models;

namespace sislte.Core;

public class SisContext(DbContextOptions<SisContext> options) : DbContext(options)
{
    public DbSet<Advisor> Advisors { get; set; }
    public DbSet<Announce> Announces { get; set; }
    public DbSet<AttendanceEntry> AttendanceEntries { get; set; }
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Scholarship> Scholarships { get; set; }
    public DbSet<Skill> Skills { get; set; }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<DetailedStudent> DetailedStudents { get; set; }
    public DbSet<Transcript> Transcripts { get; set; }
    public DbSet<StudentCourseProgram> StudentCoursePrograms { get; set; }
    public DbSet<StudentSemester> Semesters { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseProgram> CoursePrograms { get; set; }
    public DbSet<Grade> Grades { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseProgram>()
            .HasMany(e => e.Courses)
            .WithMany()
            .UsingEntity<Course_CourseProgram>();
    
        modelBuilder.Entity<Student>()
            .HasOne(e => e.DetailedStudent)
            .WithOne(e => e.Student)
            .HasForeignKey<DetailedStudent>(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
        
        modelBuilder.Entity<DetailedStudent>()
            .HasOne(e => e.Transcript)
            .WithOne(e => e.DetailedStudent)
            .HasForeignKey<Transcript>(e => e.DetailedStudentId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<DetailedStudent>()
            .HasOne(e => e.Advisor)
            .WithMany(e => e.AdvisedStudents)
            .IsRequired();
        modelBuilder.Entity<DetailedStudent>()
            .HasOne(e => e.Scholarship)
            .WithMany()
            .IsRequired(false);
        modelBuilder.Entity<DetailedStudent>()
            .HasMany(e => e.JoinedClubs)
            .WithOne()
            .IsRequired();
        modelBuilder.Entity<DetailedStudent>()
            .HasMany(e => e.Skills)
            .WithOne()
            .IsRequired();
        
        modelBuilder.Entity<Transcript>()
            .HasOne(e => e.StudentCourseProgram)
            .WithOne(e => e.Transcript)
            .HasForeignKey<StudentCourseProgram>(e => e.TranscriptId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<StudentCourseProgram>()
            .HasMany(e => e.StudentSemesters)
            .WithOne(e => e.StudentCourseProgram)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<StudentSemester>()
            .HasMany(e => e.Grades)
            .WithOne(e => e.StudentSemester)
            .HasForeignKey(e => e.StudentSemesterId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<Grade>()
            .HasOne(e => e.Course)
            .WithOne()
            .HasForeignKey<Grade>(e => e.CourseId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
        modelBuilder.Entity<Grade>()
            .HasMany(e => e.AttendanceEntries)
            .WithOne(e => e.Grade)
            .HasForeignKey(e => e.GradeId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        Seeding.Seed(modelBuilder);
    }
}