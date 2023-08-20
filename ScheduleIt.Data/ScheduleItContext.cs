using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ScheduleIt.Data.Models;

namespace ScheduleIt.Data;

public class ScheduleItContext : DbContext
{
    public DbSet<Company?> Companies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role?> Roles { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<EmployeeSkillMapping> EmployeeSkillMappings { get; set; }
    public DbSet<RoleSkillMapping> RoleSkillMappings { get; set; }
    public DbSet<ShiftType> ShiftTypes { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<EmployeeShift> EmployeeShifts { get; set; }
    
    public ScheduleItContext(DbContextOptions<ScheduleItContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Company-Employee relationship
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId);

        // Role-Employee relationship
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Role)
            .WithMany(r => r.Employees)
            .HasForeignKey(e => e.RoleId);

        // Employee-EmployeeSkillMapping relationship
        modelBuilder.Entity<EmployeeSkillMapping>()
            .HasOne(es => es.Employee)
            .WithMany(e => e.Skills)
            .HasForeignKey(es => es.EmployeeId);

        modelBuilder.Entity<EmployeeSkillMapping>()
            .HasOne(es => es.Skill)
            .WithMany(s => s.EmployeeSkills)
            .HasForeignKey(es => es.SkillId);

        // Role-RoleSkillMapping relationship
        modelBuilder.Entity<RoleSkillMapping>()
            .HasOne(rs => rs.Role)
            .WithMany(r => r.RoleSkills)
            .HasForeignKey(rs => rs.RoleId);

        modelBuilder.Entity<RoleSkillMapping>()
            .HasOne(rs => rs.Skill)
            .WithMany(s => s.RoleSkills)
            .HasForeignKey(rs => rs.SkillId);

        // ShiftType-Shift relationship
        modelBuilder.Entity<Shift>()
            .HasOne(s => s.ShiftType)
            .WithMany(st => st.Shifts)
            .HasForeignKey(s => s.ShiftTypeId);

        // Schedule-Shift relationship
        modelBuilder.Entity<Shift>()
            .HasOne(s => s.Schedule)
            .WithMany(sc => sc.Shifts)
            .HasForeignKey(s => s.ScheduleId);

        // EmployeeShift-Employee relationship
        modelBuilder.Entity<EmployeeShift>()
            .HasOne(es => es.Employee)
            .WithMany(e => e.EmployeeShifts)
            .HasForeignKey(es => es.EmployeeId);

        // EmployeeShift-Shift relationship
        modelBuilder.Entity<EmployeeShift>()
            .HasOne(es => es.Shift)
            .WithMany(s => s.EmployeeShifts)
            .HasForeignKey(es => es.ShiftId);
    }
}