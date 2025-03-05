using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TechService.Models;

namespace TechService.Context;

public partial class User21Context : DbContext
{
    public User21Context()
    {
    }

    public User21Context(DbContextOptions<User21Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }

    public virtual DbSet<Malfunction> Malfunctions { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<ReportMaterial> ReportMaterials { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestSpecialist> RequestSpecialists { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=45.67.56.214; Port=5465; Username=user21; Password=ee16lojZ; Database=user21");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("equipment_pk");

            entity.ToTable("equipment", "techservice");

            entity.HasIndex(e => e.SerialNumber, "equipment_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EquipmentTypeId).HasColumnName("equipment_type_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.SerialNumber)
                .HasColumnType("character varying")
                .HasColumnName("serial_number");

            entity.HasOne(d => d.EquipmentType).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.EquipmentTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("equipment_equipment_type_fk");
        });

        modelBuilder.Entity<EquipmentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("equipment_type_pk");

            entity.ToTable("equipment_type", "techservice");

            entity.HasIndex(e => e.Name, "equipment_type_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Malfunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("malfunction_type_pk");

            entity.ToTable("malfunction", "techservice");

            entity.HasIndex(e => e.Name, "malfunction_type_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_pk");

            entity.ToTable("material", "techservice");

            entity.HasIndex(e => e.Name, "material_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("priority_pk");

            entity.ToTable("priority", "techservice");

            entity.HasIndex(e => e.Name, "priority_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("report_pk");

            entity.ToTable("report", "techservice");

            entity.HasIndex(e => e.RequestId, "report_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.Request).WithOne(p => p.Report)
                .HasForeignKey<Report>(d => d.RequestId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("report_request_fk");
        });

        modelBuilder.Entity<ReportMaterial>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("report_material", "techservice");

            entity.HasIndex(e => new { e.ReportId, e.MaterialId }, "report_material_unique").IsUnique();

            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.ReportId).HasColumnName("report_id");

            entity.HasOne(d => d.Material).WithMany()
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("report_material_material_fk");

            entity.HasOne(d => d.Report).WithMany()
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("report_material_report_fk");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("request_pk");

            entity.ToTable("request", "techservice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.MalfunctionId).HasColumnName("malfunction_id");
            entity.Property(e => e.PriorityId).HasColumnName("priority_id");
            entity.Property(e => e.ProblemDescription).HasColumnName("problem_description");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("request_user_fk");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Requests)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("request_equipment_fk");

            entity.HasOne(d => d.Malfunction).WithMany(p => p.Requests)
                .HasForeignKey(d => d.MalfunctionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("request_malfunction_fk");

            entity.HasOne(d => d.Priority).WithMany(p => p.Requests)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("request_priority_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("request_status_fk");
        });

        modelBuilder.Entity<RequestSpecialist>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("request_specialist", "techservice");

            entity.HasIndex(e => new { e.RequestId, e.SpecialistId }, "request_specialist_unique").IsUnique();

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.SpecialistId).HasColumnName("specialist_id");

            entity.HasOne(d => d.Request).WithMany()
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("request_specialist_request_fk");

            entity.HasOne(d => d.Specialist).WithMany()
                .HasForeignKey(d => d.SpecialistId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("request_specialist_user_fk");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("role_pk");

            entity.ToTable("role", "techservice");

            entity.HasIndex(e => e.Name, "role_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_type_pk");

            entity.ToTable("status", "techservice");

            entity.HasIndex(e => e.Name, "status_type_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user", "techservice");

            entity.HasIndex(e => e.Login, "user_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("user_role_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
