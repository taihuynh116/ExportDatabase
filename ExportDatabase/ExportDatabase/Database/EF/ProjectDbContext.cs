namespace ExportDatabase.Database.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ExportDatabase.Constant;

    public partial class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
            : base(ConstantValue.ConnectionString)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<ParameterBinding> ParameterBindings { get; set; }
        public virtual DbSet<ParameterName> ParameterNames { get; set; }
        public virtual DbSet<ParameterValue> ParameterValues { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Elements)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IDCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.ParameterBindings)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IDCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Element>()
                .Property(e => e.GUID)
                .IsUnicode(false);

            modelBuilder.Entity<Element>()
                .HasMany(e => e.ParameterValues)
                .WithRequired(e => e.Element)
                .HasForeignKey(e => e.IDElement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParameterBinding>()
                .HasMany(e => e.ParameterValues)
                .WithRequired(e => e.ParameterBinding)
                .HasForeignKey(e => e.IDParameterBinding)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ParameterName>()
                .HasMany(e => e.ParameterBindings)
                .WithRequired(e => e.ParameterName)
                .HasForeignKey(e => e.IDParameterName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Elements)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.IDProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.ParameterBindings)
                .WithRequired(e => e.Task)
                .HasForeignKey(e => e.IDTask)
                .WillCascadeOnDelete(false);
        }
    }
}
