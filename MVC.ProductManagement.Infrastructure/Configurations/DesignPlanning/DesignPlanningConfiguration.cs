using DesignPlanning.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPlanning.DataAccess;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("DesignPlanningEmployees");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName).HasMaxLength(150).IsRequired();
        builder.Property(x => x.DailyCapacityHours).HasPrecision(5, 2).HasDefaultValue(8);
        builder.HasMany(x => x.Expertises).WithOne(x => x.Employee).HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class EmployeeExpertiseConfiguration : IEntityTypeConfiguration<EmployeeExpertise>
{
    public void Configure(EntityTypeBuilder<EmployeeExpertise> builder)
    {
        builder.ToTable("DesignPlanningEmployeeExpertises");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ExpertiseName).HasMaxLength(120).IsRequired();
        builder.HasIndex(x => new { x.EmployeeId, x.ExpertiseName }).IsUnique();
    }
}

public class ProjectTypeConfiguration : IEntityTypeConfiguration<ProjectType>
{
    public void Configure(EntityTypeBuilder<ProjectType> builder)
    {
        builder.ToTable("DesignPlanningProjectTypes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(120).IsRequired();
        builder.HasIndex(x => x.Name).IsUnique();
    }
}

public class TaskTemplateConfiguration : IEntityTypeConfiguration<TaskTemplate>
{
    public void Configure(EntityTypeBuilder<TaskTemplate> builder)
    {
        builder.ToTable("DesignPlanningTaskTemplates");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ResponsibleRole).HasMaxLength(120).IsRequired();
        builder.Property(x => x.TaskName).HasMaxLength(300).IsRequired();
        builder.Property(x => x.DurationValue).HasPrecision(8, 2);
        builder.HasIndex(x => new { x.ProjectTypeId, x.SequenceNo });
        builder.HasOne(x => x.ProjectType).WithMany(x => x.TaskTemplates).HasForeignKey(x => x.ProjectTypeId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("DesignPlanningProjects");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ProjectCode).HasMaxLength(60).IsRequired();
        builder.Property(x => x.ProjectName).HasMaxLength(180).IsRequired();
        builder.HasIndex(x => x.ProjectCode).IsUnique();
        builder.HasOne(x => x.ProjectType).WithMany(x => x.Projects).HasForeignKey(x => x.ProjectTypeId).OnDelete(DeleteBehavior.Restrict);
    }
}

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.ToTable("DesignPlanningProjectTasks");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ResponsibleRole).HasMaxLength(120).IsRequired();
        builder.Property(x => x.TaskName).HasMaxLength(300).IsRequired();
        builder.Property(x => x.DurationValue).HasPrecision(8, 2);
        builder.HasIndex(x => new { x.ProjectId, x.SequenceNo });
        builder.HasOne(x => x.Project).WithMany(x => x.Tasks).HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.TaskTemplate).WithMany(x => x.ProjectTasks).HasForeignKey(x => x.TaskTemplateId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.AssignedEmployee).WithMany(x => x.AssignedTasks).HasForeignKey(x => x.AssignedEmployeeId).OnDelete(DeleteBehavior.SetNull);
    }
}
