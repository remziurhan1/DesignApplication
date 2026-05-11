using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class designplanningmvp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'DesignPlanningProjectTasks', N'U') IS NOT NULL RETURN;

CREATE TABLE DesignPlanningEmployees (
    Id uniqueidentifier NOT NULL CONSTRAINT PK_DesignPlanningEmployees PRIMARY KEY,
    FullName nvarchar(150) NOT NULL,
    DailyCapacityHours decimal(5,2) NOT NULL CONSTRAINT DF_DesignPlanningEmployees_DailyCapacityHours DEFAULT 8,
    IsActive bit NOT NULL
);

CREATE TABLE DesignPlanningProjectTypes (
    Id uniqueidentifier NOT NULL CONSTRAINT PK_DesignPlanningProjectTypes PRIMARY KEY,
    Name nvarchar(120) NOT NULL
);
CREATE UNIQUE INDEX IX_DesignPlanningProjectTypes_Name ON DesignPlanningProjectTypes(Name);

CREATE TABLE DesignPlanningEmployeeExpertises (
    Id uniqueidentifier NOT NULL CONSTRAINT PK_DesignPlanningEmployeeExpertises PRIMARY KEY,
    EmployeeId uniqueidentifier NOT NULL,
    ExpertiseName nvarchar(120) NOT NULL,
    Priority int NOT NULL,
    CONSTRAINT FK_DesignPlanningEmployeeExpertises_DesignPlanningEmployees_EmployeeId FOREIGN KEY(EmployeeId) REFERENCES DesignPlanningEmployees(Id) ON DELETE CASCADE
);
CREATE UNIQUE INDEX IX_DesignPlanningEmployeeExpertises_EmployeeId_ExpertiseName ON DesignPlanningEmployeeExpertises(EmployeeId, ExpertiseName);

CREATE TABLE DesignPlanningTaskTemplates (
    Id uniqueidentifier NOT NULL CONSTRAINT PK_DesignPlanningTaskTemplates PRIMARY KEY,
    ProjectTypeId uniqueidentifier NOT NULL,
    SequenceNo int NOT NULL,
    ResponsibleRole nvarchar(120) NOT NULL,
    TaskName nvarchar(300) NOT NULL,
    DurationValue decimal(8,2) NOT NULL,
    DurationUnit int NOT NULL,
    IsPassive bit NOT NULL,
    IsActive bit NOT NULL,
    CONSTRAINT FK_DesignPlanningTaskTemplates_DesignPlanningProjectTypes_ProjectTypeId FOREIGN KEY(ProjectTypeId) REFERENCES DesignPlanningProjectTypes(Id) ON DELETE CASCADE
);
CREATE INDEX IX_DesignPlanningTaskTemplates_ProjectTypeId_SequenceNo ON DesignPlanningTaskTemplates(ProjectTypeId, SequenceNo);

CREATE TABLE DesignPlanningProjects (
    Id uniqueidentifier NOT NULL CONSTRAINT PK_DesignPlanningProjects PRIMARY KEY,
    ProjectCode nvarchar(60) NOT NULL,
    ProjectName nvarchar(180) NOT NULL,
    ProjectTypeId uniqueidentifier NOT NULL,
    StartDate datetime2 NOT NULL,
    Priority int NOT NULL,
    Status int NOT NULL,
    CONSTRAINT FK_DesignPlanningProjects_DesignPlanningProjectTypes_ProjectTypeId FOREIGN KEY(ProjectTypeId) REFERENCES DesignPlanningProjectTypes(Id)
);
CREATE UNIQUE INDEX IX_DesignPlanningProjects_ProjectCode ON DesignPlanningProjects(ProjectCode);
CREATE INDEX IX_DesignPlanningProjects_ProjectTypeId ON DesignPlanningProjects(ProjectTypeId);

CREATE TABLE DesignPlanningProjectTasks (
    Id uniqueidentifier NOT NULL CONSTRAINT PK_DesignPlanningProjectTasks PRIMARY KEY,
    ProjectId uniqueidentifier NOT NULL,
    TaskTemplateId uniqueidentifier NOT NULL,
    AssignedEmployeeId uniqueidentifier NULL,
    SequenceNo int NOT NULL,
    ResponsibleRole nvarchar(120) NOT NULL,
    TaskName nvarchar(300) NOT NULL,
    DurationValue decimal(8,2) NOT NULL,
    DurationUnit int NOT NULL,
    IsPassive bit NOT NULL,
    PlannedStart datetime2 NOT NULL,
    PlannedEnd datetime2 NOT NULL,
    ActualStart datetime2 NULL,
    ActualEnd datetime2 NULL,
    Status int NOT NULL,
    CONSTRAINT FK_DesignPlanningProjectTasks_DesignPlanningProjects_ProjectId FOREIGN KEY(ProjectId) REFERENCES DesignPlanningProjects(Id) ON DELETE CASCADE,
    CONSTRAINT FK_DesignPlanningProjectTasks_DesignPlanningTaskTemplates_TaskTemplateId FOREIGN KEY(TaskTemplateId) REFERENCES DesignPlanningTaskTemplates(Id),
    CONSTRAINT FK_DesignPlanningProjectTasks_DesignPlanningEmployees_AssignedEmployeeId FOREIGN KEY(AssignedEmployeeId) REFERENCES DesignPlanningEmployees(Id) ON DELETE SET NULL
);
CREATE INDEX IX_DesignPlanningProjectTasks_ProjectId_SequenceNo ON DesignPlanningProjectTasks(ProjectId, SequenceNo);
CREATE INDEX IX_DesignPlanningProjectTasks_TaskTemplateId ON DesignPlanningProjectTasks(TaskTemplateId);
CREATE INDEX IX_DesignPlanningProjectTasks_AssignedEmployeeId ON DesignPlanningProjectTasks(AssignedEmployeeId);

INSERT INTO DesignPlanningEmployees (Id, FullName, DailyCapacityHours, IsActive) VALUES
('11111111-1111-1111-1111-111111111111', N'Remzi Urhan', 8, 1),
('11111111-1111-1111-1111-111111111112', N'Büşra Ateş', 8, 1),
('11111111-1111-1111-1111-111111111113', N'Erdoğan Elgin', 8, 1),
('11111111-1111-1111-1111-111111111114', N'Muhammed Şimşek', 8, 1),
('11111111-1111-1111-1111-111111111115', N'Ayhan Şahin', 8, 1),
('11111111-1111-1111-1111-111111111116', N'Mustafa Çakal', 8, 1);

INSERT INTO DesignPlanningProjectTypes (Id, Name) VALUES
('22222222-2222-2222-2222-222222222221', N'Tek Cidarlı Depolama'),
('22222222-2222-2222-2222-222222222222', N'Çift Cidarlı Depolama'),
('22222222-2222-2222-2222-222222222223', N'Tek Cidarlı Transport'),
('22222222-2222-2222-2222-222222222224', N'Çift Cidarlı Transport');

INSERT INTO DesignPlanningEmployeeExpertises (Id, EmployeeId, ExpertiseName, Priority) VALUES
('31111111-1111-1111-1111-111111111111', '11111111-1111-1111-1111-111111111111', N'Teklif Hazırlama', 1),
('31111111-1111-1111-1111-111111111112', '11111111-1111-1111-1111-111111111112', N'Tek Cidarlı Depolama', 1),
('31111111-1111-1111-1111-111111111113', '11111111-1111-1111-1111-111111111112', N'Tek Cidarlı Transport', 1),
('31111111-1111-1111-1111-111111111114', '11111111-1111-1111-1111-111111111113', N'Çift Cidarlı Depolama', 1),
('31111111-1111-1111-1111-111111111115', '11111111-1111-1111-1111-111111111113', N'Çift Cidarlı Transport', 1),
('31111111-1111-1111-1111-111111111116', '11111111-1111-1111-1111-111111111114', N'Tek Cidarlı Depolama', 1),
('31111111-1111-1111-1111-111111111117', '11111111-1111-1111-1111-111111111114', N'Çift Cidarlı Depolama', 1),
('31111111-1111-1111-1111-111111111118', '11111111-1111-1111-1111-111111111115', N'Teknik Ressam', 1),
('31111111-1111-1111-1111-111111111119', '11111111-1111-1111-1111-111111111116', N'Teknik Ressam', 1);

INSERT INTO DesignPlanningTaskTemplates (Id, ProjectTypeId, SequenceNo, ResponsibleRole, TaskName, DurationValue, DurationUnit, IsPassive, IsActive) VALUES
('40000000-0000-0000-2221-000000000001','22222222-2222-2222-2222-222222222221',1,N'Teklif Hazırlama',N'GAD RESMİ ÇİZİMİ',2,1,0,1),
('40000000-0000-0000-2221-000000000002','22222222-2222-2222-2222-222222222221',2,N'Teklif Hazırlama',N'GAD RESMİ ÇİZİM ONAYI',2,1,0,1),
('40000000-0000-0000-2221-000000000003','22222222-2222-2222-2222-222222222221',3,N'Teklif Hazırlama',N'Hesaplamalar',1,1,0,1),
('40000000-0000-0000-2221-000000000004','22222222-2222-2222-2222-222222222221',4,N'Dizayn Mühendisi',N'TUV Tip Onay Süreci',1,3,1,1),
('40000000-0000-0000-2221-000000000005','22222222-2222-2222-2222-222222222221',5,N'Dizayn Mühendisi',N'Genel Tip Onay Resmi',6,1,0,1),
('40000000-0000-0000-2221-000000000006','22222222-2222-2222-2222-222222222221',6,N'Dizayn Mühendisi',N'TANK MONTAJ TASARIMI',4,1,0,1),
('40000000-0000-0000-2221-000000000007','22222222-2222-2222-2222-222222222221',7,N'Teknik Ressam',N'TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI',2,1,0,1),
('40000000-0000-0000-2222-000000000001','22222222-2222-2222-2222-222222222222',1,N'Teklif Hazırlama',N'Hesaplamalar',2,1,0,1),
('40000000-0000-0000-2222-000000000002','22222222-2222-2222-2222-222222222222',2,N'Teklif Hazırlama',N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA',2,1,0,1),
('40000000-0000-0000-2222-000000000003','22222222-2222-2222-2222-222222222222',3,N'Teklif Hazırlama',N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA',1,1,0,1),
('40000000-0000-0000-2222-000000000004','22222222-2222-2222-2222-222222222222',4,N'Teklif Hazırlama',N'P&ID HAZIRLAMA',1,1,0,1),
('40000000-0000-0000-2222-000000000005','22222222-2222-2222-2222-222222222222',5,N'Teklif Hazırlama',N'GAD RESMİ ÇİZİMİ',1,1,0,1),
('40000000-0000-0000-2222-000000000006','22222222-2222-2222-2222-222222222222',6,N'Teklif Hazırlama',N'GAD RESMİ ÇİZİM ONAYI',1,3,1,1),
('40000000-0000-0000-2222-000000000007','22222222-2222-2222-2222-222222222222',7,N'Dizayn Mühendisi',N'Genel Tip Onay Resmi',6,1,0,1),
('40000000-0000-0000-2222-000000000008','22222222-2222-2222-2222-222222222222',8,N'Dizayn Mühendisi',N'TUV Tip Onay Süreci',1,3,1,1),
('40000000-0000-0000-2222-000000000009','22222222-2222-2222-2222-222222222222',9,N'Dizayn Mühendisi',N'İÇ TANK MONTAJ TASARIMI',4,1,0,1),
('40000000-0000-0000-2222-000000000010','22222222-2222-2222-2222-222222222222',10,N'Dizayn Mühendisi',N'DIŞ TANK MONTAJ TASARIMI',4,1,0,1),
('40000000-0000-0000-2222-000000000011','22222222-2222-2222-2222-222222222222',11,N'Teknik Ressam',N'DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI',2,1,0,1);
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
IF OBJECT_ID(N'DesignPlanningProjectTasks', N'U') IS NOT NULL DROP TABLE DesignPlanningProjectTasks;
IF OBJECT_ID(N'DesignPlanningProjects', N'U') IS NOT NULL DROP TABLE DesignPlanningProjects;
IF OBJECT_ID(N'DesignPlanningTaskTemplates', N'U') IS NOT NULL DROP TABLE DesignPlanningTaskTemplates;
IF OBJECT_ID(N'DesignPlanningEmployeeExpertises', N'U') IS NOT NULL DROP TABLE DesignPlanningEmployeeExpertises;
IF OBJECT_ID(N'DesignPlanningProjectTypes', N'U') IS NOT NULL DROP TABLE DesignPlanningProjectTypes;
IF OBJECT_ID(N'DesignPlanningEmployees', N'U') IS NOT NULL DROP TABLE DesignPlanningEmployees;
");
        }
    }
}
