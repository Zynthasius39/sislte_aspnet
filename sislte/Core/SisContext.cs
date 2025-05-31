using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using sislte.Models;

namespace sislte.Core;

public class SisContext(DbContextOptions<SisContext> options) : DbContext(options)
{
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Student> Students { get; set; }
}