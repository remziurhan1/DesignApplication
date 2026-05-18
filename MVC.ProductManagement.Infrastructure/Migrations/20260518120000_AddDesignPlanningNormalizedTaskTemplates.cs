using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.ProductManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDesignPlanningNormalizedTaskTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000001')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 1, [TaskName] = N'GAD RESMİ ÇİZİMİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000001';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000001', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 1, N'GAD RESMİ ÇİZİMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000002')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 2, [TaskName] = N'GAD RESMİ ÇİZİM ONAYI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000002';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000002', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 2, N'GAD RESMİ ÇİZİM ONAYI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000003')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 3, [TaskName] = N'Hesaplamalar'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000003';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000003', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 3, N'Hesaplamalar');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000004')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 4, [TaskName] = N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000004';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000004', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 4, N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000005')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 5, [TaskName] = N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000005';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000005', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 5, N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000006')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 6, [TaskName] = N'TUV Tip Onay Süreci (Tüm Projeler İçin)'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000006';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000006', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 6, N'TUV Tip Onay Süreci (Tüm Projeler İçin)');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000007')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 7, [TaskName] = N'Genel Tip Onay Resmi'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000007';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000007', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 7, N'Genel Tip Onay Resmi');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000008')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 8, [TaskName] = N'Onay ve kontrol süreci (TUV)'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000008';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000008', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 8, N'Onay ve kontrol süreci (TUV)');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000009')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 9, [TaskName] = N'TANK BOMBE MONTAJ RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000009';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000009', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 9, N'TANK BOMBE MONTAJ RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000010')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 10, [TaskName] = N'TANK PUL ÇAPI KONTROL'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000010';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000010', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 10, N'TANK PUL ÇAPI KONTROL');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000011')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 11, [TaskName] = N'TANK GÖVDE BOMBE KESİM RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000011';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000011', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 11, N'TANK GÖVDE BOMBE KESİM RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000012')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 12, [TaskName] = N'TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000012';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000012', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 12, N'TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000013')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 13, [TaskName] = N'TANK REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000013';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000013', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 13, N'TANK REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000014')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 14, [TaskName] = N'TANK AYAK TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000014';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000014', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 14, N'TANK AYAK TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000015')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 15, [TaskName] = N'TANK AYAK REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000015';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000015', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 15, N'TANK AYAK REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000016')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 16, [TaskName] = N'BOYA GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000016';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000016', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 16, N'BOYA GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000017')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 17, [TaskName] = N'ETİKET GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000017';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000017', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 17, N'ETİKET GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000018')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 18, [TaskName] = N'ETİKET TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000018';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000018', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 18, N'ETİKET TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000019')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 19, [TaskName] = N'Tank Manuel Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000019';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000019', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 19, N'Tank Manuel Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000020')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 20, [TaskName] = N'TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000020';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000020', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teknik Ressam', 20, N'TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000021')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 21, [TaskName] = N'TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000021';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000021', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teknik Ressam', 21, N'TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000022')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 22, [TaskName] = N'TANK AYAK TEKNİK RESİMLERİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000022';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000022', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teknik Ressam', 22, N'TANK AYAK TEKNİK RESİMLERİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000023')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 23, [TaskName] = N'TANK AKSESUAR TEKNİK RESİMLERİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000023';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000023', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teknik Ressam', 23, N'TANK AKSESUAR TEKNİK RESİMLERİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000024')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 24, [TaskName] = N'NAKLİYE RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000024';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000024', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teknik Ressam', 24, N'NAKLİYE RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000001')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 1, [TaskName] = N'Hesaplamalar'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000001';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000001', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 1, N'Hesaplamalar');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000002')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 2, [TaskName] = N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000002';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000002', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 2, N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000003')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 3, [TaskName] = N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000003';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000003', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 3, N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000004')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 4, [TaskName] = N'P&ID HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000004';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000004', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 4, N'P&ID HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000005')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 5, [TaskName] = N'GAD RESMİ ÇİZİMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000005';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000005', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 5, N'GAD RESMİ ÇİZİMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000006')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 6, [TaskName] = N'GAD RESMİ ÇİZİM ONAYI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000006';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000006', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 6, N'GAD RESMİ ÇİZİM ONAYI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000007')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 7, [TaskName] = N'Genel Tip Onay Resmi'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000007';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000007', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 7, N'Genel Tip Onay Resmi');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000008')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 8, [TaskName] = N'TUV Tip Onay Süreci (Tüm Projeler İçin)'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000008';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000008', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 8, N'TUV Tip Onay Süreci (Tüm Projeler İçin)');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000009')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 9, [TaskName] = N'İÇ TANK BOMBE MONTAJ RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000009';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000009', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 9, N'İÇ TANK BOMBE MONTAJ RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000010')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 10, [TaskName] = N'İÇ TANK PUL ÇAPI KONTROL'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000010';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000010', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 10, N'İÇ TANK PUL ÇAPI KONTROL');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000011')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 11, [TaskName] = N'İÇ TANK GÖVDE BOMBE KESİM RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000011';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000011', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 11, N'İÇ TANK GÖVDE BOMBE KESİM RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000012')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 12, [TaskName] = N'İÇ TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000012';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000012', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 12, N'İÇ TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000013')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 13, [TaskName] = N'İÇ TANK REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000013';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000013', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 13, N'İÇ TANK REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000014')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 14, [TaskName] = N'İÇ TANK BORULAMA TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000014';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000014', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 14, N'İÇ TANK BORULAMA TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000015')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 15, [TaskName] = N'İÇ TANK BORULAMA REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000015';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000015', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 15, N'İÇ TANK BORULAMA REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000016')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 16, [TaskName] = N'DIŞ TANK BOMBE MONTAJ TEKNİK RESİM'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000016';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000016', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 16, N'DIŞ TANK BOMBE MONTAJ TEKNİK RESİM');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000017')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 17, [TaskName] = N'DIŞ TANK PUL ÇAPI KONTROL'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000017';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000017', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 17, N'DIŞ TANK PUL ÇAPI KONTROL');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000018')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 18, [TaskName] = N'DIŞ TANK GÖVDE BOMBE KESİM RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000018';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000018', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 18, N'DIŞ TANK GÖVDE BOMBE KESİM RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000019')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 19, [TaskName] = N'DIŞ TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000019';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000019', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 19, N'DIŞ TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000020')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 20, [TaskName] = N'DIŞ TANK REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000020';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000020', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 20, N'DIŞ TANK REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000021')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 21, [TaskName] = N'İGM MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000021';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000021', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 21, N'İGM MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000022')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 22, [TaskName] = N'DIŞ BORULAMA TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000022';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000022', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 22, N'DIŞ BORULAMA TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000023')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 23, [TaskName] = N'DIŞ BORULAMA REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000023';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000023', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 23, N'DIŞ BORULAMA REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000024')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 24, [TaskName] = N'BUHARLIŞTIRICI TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000024';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000024', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 24, N'BUHARLIŞTIRICI TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000025')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 25, [TaskName] = N'BUHARLIŞTIRICI REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000025';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000025', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 25, N'BUHARLIŞTIRICI REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000026')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 26, [TaskName] = N'İZOLASYON GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000026';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000026', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 26, N'İZOLASYON GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000027')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 27, [TaskName] = N'BOYA GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000027';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000027', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 27, N'BOYA GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000028')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 28, [TaskName] = N'ETİKET GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000028';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000028', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 28, N'ETİKET GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000029')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 29, [TaskName] = N'ETİKET TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000029';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000029', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 29, N'ETİKET TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000030')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 30, [TaskName] = N'Tank Manuel Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000030';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000030', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 30, N'Tank Manuel Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000031')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 31, [TaskName] = N'DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000031';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000031', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 31, N'DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000032')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 32, [TaskName] = N'DIŞ TANK GÖVDE MONTAJ teknik resmi ( dış tank ring& ring sarımı & mapa yerleşimi & dablinler)'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000032';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000032', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 32, N'DIŞ TANK GÖVDE MONTAJ teknik resmi ( dış tank ring& ring sarımı & mapa yerleşimi & dablinler)');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000033')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 33, [TaskName] = N'PROFİL AYAK MONTAJ RESMİNİN HAZIRLANMASI TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000033';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000033', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 33, N'PROFİL AYAK MONTAJ RESMİNİN HAZIRLANMASI TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000034')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 34, [TaskName] = N'İÇ TANK BORULAMA TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000034';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000034', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 34, N'İÇ TANK BORULAMA TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000035')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 35, [TaskName] = N'İÇ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000035';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000035', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 35, N'İÇ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000036')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 36, [TaskName] = N'İÇ TANK GÖVDE MONTAJ& NOZUL& DABLİN & TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000036';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000036', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 36, N'İÇ TANK GÖVDE MONTAJ& NOZUL& DABLİN & TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000037')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 37, [TaskName] = N'İGM MONTAJ TEKNİK RESİM'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000037';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000037', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 37, N'İGM MONTAJ TEKNİK RESİM');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000038')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 38, [TaskName] = N'DIŞ BORULAMA  TEKNİK RESİM'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000038';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000038', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 38, N'DIŞ BORULAMA  TEKNİK RESİM');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000039')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 39, [TaskName] = N'EVAP KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000039';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000039', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 39, N'EVAP KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000040')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 40, [TaskName] = N'EVAP TEKNİK RESİM'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000040';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000040', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 40, N'EVAP TEKNİK RESİM');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000041')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 41, [TaskName] = N'NAKLİYE RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000041';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000041', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 41, N'NAKLİYE RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000042')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 42, [TaskName] = N'ASBUILT RESMİ HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000042';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000042', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 42, N'ASBUILT RESMİ HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000001')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 1, [TaskName] = N'Hesaplamalar'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000001';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000001', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teklif Hazırlama', 1, N'Hesaplamalar');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000002')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 2, [TaskName] = N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000002';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000002', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teklif Hazırlama', 2, N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000003')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 3, [TaskName] = N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000003';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000003', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teklif Hazırlama', 3, N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000004')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 4, [TaskName] = N'P&ID HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000004';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000004', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teklif Hazırlama', 4, N'P&ID HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000005')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 5, [TaskName] = N'GAD RESMİ ÇİZİMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000005';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000005', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teklif Hazırlama', 5, N'GAD RESMİ ÇİZİMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000006')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 6, [TaskName] = N'GAD RESMİ ÇİZİM ONAYI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000006';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000006', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teklif Hazırlama', 6, N'GAD RESMİ ÇİZİM ONAYI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000007')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 7, [TaskName] = N'Genel Tip Onay Resmi'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000007';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000007', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 7, N'Genel Tip Onay Resmi');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000008')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 8, [TaskName] = N'TUV Tip Onay Süreci (Tüm Projeler İçin)'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000008';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000008', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 8, N'TUV Tip Onay Süreci (Tüm Projeler İçin)');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000009')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 9, [TaskName] = N'TANK BOMBE MONTAJ RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000009';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000009', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 9, N'TANK BOMBE MONTAJ RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000010')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 10, [TaskName] = N'TANK PUL ÇAPI KONTROL'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000010';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000010', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 10, N'TANK PUL ÇAPI KONTROL');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000011')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 11, [TaskName] = N'TANK GÖVDE BOMBE KESİM RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000011';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000011', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 11, N'TANK GÖVDE BOMBE KESİM RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000012')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 12, [TaskName] = N'TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000012';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000012', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 12, N'TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000013')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 13, [TaskName] = N'TANK MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000013';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000013', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 13, N'TANK MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000014')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 14, [TaskName] = N'DALGAKIRAN TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000014';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000014', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 14, N'DALGAKIRAN TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000015')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 15, [TaskName] = N'DALGAKIRAN REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000015';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000015', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 15, N'DALGAKIRAN REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000016')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 16, [TaskName] = N'ŞASE MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000016';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000016', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 16, N'ŞASE MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000017')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 17, [TaskName] = N'ŞASE MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000017';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000017', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 17, N'ŞASE MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000018')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 18, [TaskName] = N'TANK AYAK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000018';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000018', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 18, N'TANK AYAK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000019')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 19, [TaskName] = N'TANK AYAK MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000019';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000019', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 19, N'TANK AYAK MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000020')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 20, [TaskName] = N'KİNG PİN & MEKANİK AYAK TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000020';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000020', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 20, N'KİNG PİN & MEKANİK AYAK TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000021')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 21, [TaskName] = N'KİNG PİN & MEKANİK AYAK REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000021';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000021', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 21, N'KİNG PİN & MEKANİK AYAK REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000022')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 22, [TaskName] = N'KONSOL MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000022';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000022', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 22, N'KONSOL MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000023')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 23, [TaskName] = N'KONSOL MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000023';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000023', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 23, N'KONSOL MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000024')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 24, [TaskName] = N'ŞASE MONTAJ SON MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000024';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000024', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 24, N'ŞASE MONTAJ SON MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000025')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 25, [TaskName] = N'DIŞ BORULAMA TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000025';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000025', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 25, N'DIŞ BORULAMA TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000026')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 26, [TaskName] = N'DIŞ BORULAMA REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000026';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000026', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 26, N'DIŞ BORULAMA REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000027')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 27, [TaskName] = N'DOLAP TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000027';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000027', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 27, N'DOLAP TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000028')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 28, [TaskName] = N'DOLAP REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000028';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000028', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 28, N'DOLAP REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000029')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 29, [TaskName] = N'BOYA GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000029';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000029', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 29, N'BOYA GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000030')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 30, [TaskName] = N'ETİKET GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000030';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000030', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 30, N'ETİKET GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000031')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 31, [TaskName] = N'ETİKET TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000031';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000031', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 31, N'ETİKET TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000032')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 32, [TaskName] = N'Tank Manuel Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000032';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000032', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222223', N'Dizayn Mühendisi', 32, N'Tank Manuel Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000033')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 33, [TaskName] = N'TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000033';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000033', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 33, N'TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000034')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 34, [TaskName] = N'Şase Kesim Resimlerinin Listelerinin Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000034';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000034', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 34, N'Şase Kesim Resimlerinin Listelerinin Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000035')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 35, [TaskName] = N'Şase Teknik Resmi'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000035';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000035', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 35, N'Şase Teknik Resmi');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000036')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 36, [TaskName] = N'DALGAKIRAN KESİM LİSTESİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000036';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000036', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 36, N'DALGAKIRAN KESİM LİSTESİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000037')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 37, [TaskName] = N'TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000037';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000037', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 37, N'TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000038')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 38, [TaskName] = N'DALGAKIRAN TEKNİK RESİMLERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000038';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000038', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 38, N'DALGAKIRAN TEKNİK RESİMLERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000039')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 39, [TaskName] = N'KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000039';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000039', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 39, N'KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000040')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 40, [TaskName] = N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000040';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000040', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 40, N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000041')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 41, [TaskName] = N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK TEKNİK RESMİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000041';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000041', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 41, N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK TEKNİK RESMİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000042')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 42, [TaskName] = N'KONSOL MONTAJ TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000042';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000042', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 42, N'KONSOL MONTAJ TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000043')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 43, [TaskName] = N'DOLAP TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000043';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000043', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 43, N'DOLAP TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000044')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 44, [TaskName] = N'BORULAMA TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000044';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000044', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 44, N'BORULAMA TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000045')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 45, [TaskName] = N'NAKLİYE RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000045';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000045', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 45, N'NAKLİYE RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2223-000000000046')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222223', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 46, [TaskName] = N'ASBUİLT'
                    WHERE [Id] = '40000000-0000-0000-2223-000000000046';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2223-000000000046', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222223', N'Teknik Ressam', 46, N'ASBUİLT');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000001')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 1, [TaskName] = N'Hesaplamalar'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000001';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000001', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teklif Hazırlama', 1, N'Hesaplamalar');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000002')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 2, [TaskName] = N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000002';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000002', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teklif Hazırlama', 2, N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000003')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 3, [TaskName] = N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000003';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000003', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teklif Hazırlama', 3, N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000004')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 4, [TaskName] = N'P&ID HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000004';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000004', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teklif Hazırlama', 4, N'P&ID HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000005')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 5, [TaskName] = N'GAD RESMİ ÇİZİMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000005';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000005', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teklif Hazırlama', 5, N'GAD RESMİ ÇİZİMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000006')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 6, [TaskName] = N'GAD RESMİ ÇİZİM ONAYI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000006';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000006', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teklif Hazırlama', 6, N'GAD RESMİ ÇİZİM ONAYI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000007')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 7, [TaskName] = N'Genel Tip Onay Resmi'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000007';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000007', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 7, N'Genel Tip Onay Resmi');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000008')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 8, [TaskName] = N'TUV Tip Onay Süreci (Tüm Projeler İçin)'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000008';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000008', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 8, N'TUV Tip Onay Süreci (Tüm Projeler İçin)');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000009')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 9, [TaskName] = N'İÇ TANK BOMBE MONTAJ RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000009';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000009', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 9, N'İÇ TANK BOMBE MONTAJ RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000010')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 10, [TaskName] = N'İÇ TANK PUL ÇAPI KONTROL'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000010';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000010', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 10, N'İÇ TANK PUL ÇAPI KONTROL');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000011')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 11, [TaskName] = N'İÇ TANK GÖVDE BOMBE KESİM RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000011';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000011', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 11, N'İÇ TANK GÖVDE BOMBE KESİM RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000012')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 12, [TaskName] = N'DIŞ TANK BOMBE MONTAJ RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000012';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000012', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 12, N'DIŞ TANK BOMBE MONTAJ RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000013')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 13, [TaskName] = N'DIŞ TANK PUL ÇAPI KONTROL'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000013';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000013', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 13, N'DIŞ TANK PUL ÇAPI KONTROL');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000014')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 14, [TaskName] = N'DIŞ TANK GÖVDE BOMBE KESİM RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000014';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000014', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 14, N'DIŞ TANK GÖVDE BOMBE KESİM RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000015')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 15, [TaskName] = N'İÇ TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000015';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000015', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 15, N'İÇ TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000016')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 16, [TaskName] = N'DALGAKIRAN TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000016';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000016', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 16, N'DALGAKIRAN TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000017')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 17, [TaskName] = N'DALGAKIRAN REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000017';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000017', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 17, N'DALGAKIRAN REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000018')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 18, [TaskName] = N'İÇ TANK MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000018';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000018', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 18, N'İÇ TANK MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000019')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 19, [TaskName] = N'İÇ TANK İÇ BORULAMA MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000019';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000019', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 19, N'İÇ TANK İÇ BORULAMA MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000020')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 20, [TaskName] = N'İÇ TANK İÇ BORULAMA MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000020';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000020', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 20, N'İÇ TANK İÇ BORULAMA MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000021')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 21, [TaskName] = N'DIŞ TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000021';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000021', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 21, N'DIŞ TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000022')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 22, [TaskName] = N'DIŞ TANK MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000022';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000022', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 22, N'DIŞ TANK MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000023')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 23, [TaskName] = N'İGM MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000023';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000023', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 23, N'İGM MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000024')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 24, [TaskName] = N'İGM MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000024';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000024', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 24, N'İGM MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000025')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 25, [TaskName] = N'DIŞ BORULAMA TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000025';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000025', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 25, N'DIŞ BORULAMA TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000026')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 26, [TaskName] = N'DIŞ BORULAMA REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000026';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000026', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 26, N'DIŞ BORULAMA REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000027')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 27, [TaskName] = N'TANK AYAK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000027';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000027', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 27, N'TANK AYAK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000028')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 28, [TaskName] = N'TANK AYAK MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000028';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000028', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 28, N'TANK AYAK MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000029')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 29, [TaskName] = N'ŞASE MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000029';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000029', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 29, N'ŞASE MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000030')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 30, [TaskName] = N'ŞASE MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000030';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000030', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 30, N'ŞASE MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000031')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 31, [TaskName] = N'KİNG PİN & MEKANİK AYAK TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000031';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000031', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 31, N'KİNG PİN & MEKANİK AYAK TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000032')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 32, [TaskName] = N'KİNG PİN & MEKANİK AYAK REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000032';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000032', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 32, N'KİNG PİN & MEKANİK AYAK REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000033')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 33, [TaskName] = N'KONSOL MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000033';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000033', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 33, N'KONSOL MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000034')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 34, [TaskName] = N'KONSOL MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000034';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000034', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 34, N'KONSOL MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000035')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 35, [TaskName] = N'ŞASE MONTAJ SON MONTAJ REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000035';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000035', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 35, N'ŞASE MONTAJ SON MONTAJ REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000036')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 36, [TaskName] = N'DOLAP TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000036';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000036', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 36, N'DOLAP TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000037')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 37, [TaskName] = N'DOLAP REÇETESİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000037';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000037', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 37, N'DOLAP REÇETESİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000038')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 38, [TaskName] = N'BOYA GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000038';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000038', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 38, N'BOYA GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000039')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 39, [TaskName] = N'ETİKET GRUBU REÇETE GİRİŞ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000039';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000039', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 39, N'ETİKET GRUBU REÇETE GİRİŞ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000040')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 40, [TaskName] = N'ETİKET TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000040';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000040', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 40, N'ETİKET TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000041')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 41, [TaskName] = N'Tank Manuel Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000041';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000041', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Dizayn Mühendisi', 41, N'Tank Manuel Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000042')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 42, [TaskName] = N'İç Tank Kesim Listelerinin Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000042';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000042', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 42, N'İç Tank Kesim Listelerinin Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000043')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 43, [TaskName] = N'DALGAKIRAN KESİM LİSTESİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000043';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000043', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 43, N'DALGAKIRAN KESİM LİSTESİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000044')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 44, [TaskName] = N'DALGAKIRAN TEKNİK RESİMLERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000044';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000044', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 44, N'DALGAKIRAN TEKNİK RESİMLERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000045')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 45, [TaskName] = N'İÇ TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000045';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000045', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 45, N'İÇ TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000046')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 46, [TaskName] = N'İç BORULAMA TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000046';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000046', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 46, N'İç BORULAMA TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000047')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 47, [TaskName] = N'Dış Tank Kesim Listelerinin Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000047';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000047', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 47, N'Dış Tank Kesim Listelerinin Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000048')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 48, [TaskName] = N'Dış TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000048';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000048', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 48, N'Dış TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000049')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 49, [TaskName] = N'İGM MONTAJ TEKNİK RESİM'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000049';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000049', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 49, N'İGM MONTAJ TEKNİK RESİM');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000050')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 50, [TaskName] = N'KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000050';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000050', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 50, N'KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000051')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 51, [TaskName] = N'KİNG PİN & MEKANİK AYAK Teknik Resimlerinin HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000051';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000051', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 51, N'KİNG PİN & MEKANİK AYAK Teknik Resimlerinin HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000052')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 52, [TaskName] = N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000052';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000052', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 52, N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000053')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 53, [TaskName] = N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK TEKNİK RESMİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000053';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000053', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 53, N'TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK TEKNİK RESMİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000054')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 54, [TaskName] = N'Şase Teknik Resimlerinin Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000054';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000054', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 54, N'Şase Teknik Resimlerinin Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000055')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 55, [TaskName] = N'KONSOL MONTAJ TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000055';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000055', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 55, N'KONSOL MONTAJ TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000056')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 56, [TaskName] = N'Dolap Kesim Listelerinin Hazırlanması'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000056';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000056', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 56, N'Dolap Kesim Listelerinin Hazırlanması');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000057')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 57, [TaskName] = N'DOLAP TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000057';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000057', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 57, N'DOLAP TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000058')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 58, [TaskName] = N'Dış BORULAMA TEKNİK RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000058';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000058', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 58, N'Dış BORULAMA TEKNİK RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000059')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 59, [TaskName] = N'NAKLİYE RESMİ'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000059';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000059', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 59, N'NAKLİYE RESMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2224-000000000060')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222224', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 60, [TaskName] = N'ASBUİLT'
                    WHERE [Id] = '40000000-0000-0000-2224-000000000060';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2224-000000000060', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222224', N'Teknik Ressam', 60, N'ASBUİLT');
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM [DesignPlanningTaskTemplates]
                WHERE [Id] IN (
                        '40000000-0000-0000-2221-000000000001',
                        '40000000-0000-0000-2221-000000000002',
                        '40000000-0000-0000-2221-000000000003',
                        '40000000-0000-0000-2221-000000000004',
                        '40000000-0000-0000-2221-000000000005',
                        '40000000-0000-0000-2221-000000000006',
                        '40000000-0000-0000-2221-000000000007',
                        '40000000-0000-0000-2221-000000000008',
                        '40000000-0000-0000-2221-000000000009',
                        '40000000-0000-0000-2221-000000000010',
                        '40000000-0000-0000-2221-000000000011',
                        '40000000-0000-0000-2221-000000000012',
                        '40000000-0000-0000-2221-000000000013',
                        '40000000-0000-0000-2221-000000000014',
                        '40000000-0000-0000-2221-000000000015',
                        '40000000-0000-0000-2221-000000000016',
                        '40000000-0000-0000-2221-000000000017',
                        '40000000-0000-0000-2221-000000000018',
                        '40000000-0000-0000-2221-000000000019',
                        '40000000-0000-0000-2221-000000000020',
                        '40000000-0000-0000-2221-000000000021',
                        '40000000-0000-0000-2221-000000000022',
                        '40000000-0000-0000-2221-000000000023',
                        '40000000-0000-0000-2221-000000000024',
                        '40000000-0000-0000-2222-000000000001',
                        '40000000-0000-0000-2222-000000000002',
                        '40000000-0000-0000-2222-000000000003',
                        '40000000-0000-0000-2222-000000000004',
                        '40000000-0000-0000-2222-000000000005',
                        '40000000-0000-0000-2222-000000000006',
                        '40000000-0000-0000-2222-000000000007',
                        '40000000-0000-0000-2222-000000000008',
                        '40000000-0000-0000-2222-000000000009',
                        '40000000-0000-0000-2222-000000000010',
                        '40000000-0000-0000-2222-000000000011',
                        '40000000-0000-0000-2222-000000000012',
                        '40000000-0000-0000-2222-000000000013',
                        '40000000-0000-0000-2222-000000000014',
                        '40000000-0000-0000-2222-000000000015',
                        '40000000-0000-0000-2222-000000000016',
                        '40000000-0000-0000-2222-000000000017',
                        '40000000-0000-0000-2222-000000000018',
                        '40000000-0000-0000-2222-000000000019',
                        '40000000-0000-0000-2222-000000000020',
                        '40000000-0000-0000-2222-000000000021',
                        '40000000-0000-0000-2222-000000000022',
                        '40000000-0000-0000-2222-000000000023',
                        '40000000-0000-0000-2222-000000000024',
                        '40000000-0000-0000-2222-000000000025',
                        '40000000-0000-0000-2222-000000000026',
                        '40000000-0000-0000-2222-000000000027',
                        '40000000-0000-0000-2222-000000000028',
                        '40000000-0000-0000-2222-000000000029',
                        '40000000-0000-0000-2222-000000000030',
                        '40000000-0000-0000-2222-000000000031',
                        '40000000-0000-0000-2222-000000000032',
                        '40000000-0000-0000-2222-000000000033',
                        '40000000-0000-0000-2222-000000000034',
                        '40000000-0000-0000-2222-000000000035',
                        '40000000-0000-0000-2222-000000000036',
                        '40000000-0000-0000-2222-000000000037',
                        '40000000-0000-0000-2222-000000000038',
                        '40000000-0000-0000-2222-000000000039',
                        '40000000-0000-0000-2222-000000000040',
                        '40000000-0000-0000-2222-000000000041',
                        '40000000-0000-0000-2222-000000000042',
                        '40000000-0000-0000-2223-000000000001',
                        '40000000-0000-0000-2223-000000000002',
                        '40000000-0000-0000-2223-000000000003',
                        '40000000-0000-0000-2223-000000000004',
                        '40000000-0000-0000-2223-000000000005',
                        '40000000-0000-0000-2223-000000000006',
                        '40000000-0000-0000-2223-000000000007',
                        '40000000-0000-0000-2223-000000000008',
                        '40000000-0000-0000-2223-000000000009',
                        '40000000-0000-0000-2223-000000000010',
                        '40000000-0000-0000-2223-000000000011',
                        '40000000-0000-0000-2223-000000000012',
                        '40000000-0000-0000-2223-000000000013',
                        '40000000-0000-0000-2223-000000000014',
                        '40000000-0000-0000-2223-000000000015',
                        '40000000-0000-0000-2223-000000000016',
                        '40000000-0000-0000-2223-000000000017',
                        '40000000-0000-0000-2223-000000000018',
                        '40000000-0000-0000-2223-000000000019',
                        '40000000-0000-0000-2223-000000000020',
                        '40000000-0000-0000-2223-000000000021',
                        '40000000-0000-0000-2223-000000000022',
                        '40000000-0000-0000-2223-000000000023',
                        '40000000-0000-0000-2223-000000000024',
                        '40000000-0000-0000-2223-000000000025',
                        '40000000-0000-0000-2223-000000000026',
                        '40000000-0000-0000-2223-000000000027',
                        '40000000-0000-0000-2223-000000000028',
                        '40000000-0000-0000-2223-000000000029',
                        '40000000-0000-0000-2223-000000000030',
                        '40000000-0000-0000-2223-000000000031',
                        '40000000-0000-0000-2223-000000000032',
                        '40000000-0000-0000-2223-000000000033',
                        '40000000-0000-0000-2223-000000000034',
                        '40000000-0000-0000-2223-000000000035',
                        '40000000-0000-0000-2223-000000000036',
                        '40000000-0000-0000-2223-000000000037',
                        '40000000-0000-0000-2223-000000000038',
                        '40000000-0000-0000-2223-000000000039',
                        '40000000-0000-0000-2223-000000000040',
                        '40000000-0000-0000-2223-000000000041',
                        '40000000-0000-0000-2223-000000000042',
                        '40000000-0000-0000-2223-000000000043',
                        '40000000-0000-0000-2223-000000000044',
                        '40000000-0000-0000-2223-000000000045',
                        '40000000-0000-0000-2223-000000000046',
                        '40000000-0000-0000-2224-000000000001',
                        '40000000-0000-0000-2224-000000000002',
                        '40000000-0000-0000-2224-000000000003',
                        '40000000-0000-0000-2224-000000000004',
                        '40000000-0000-0000-2224-000000000005',
                        '40000000-0000-0000-2224-000000000006',
                        '40000000-0000-0000-2224-000000000007',
                        '40000000-0000-0000-2224-000000000008',
                        '40000000-0000-0000-2224-000000000009',
                        '40000000-0000-0000-2224-000000000010',
                        '40000000-0000-0000-2224-000000000011',
                        '40000000-0000-0000-2224-000000000012',
                        '40000000-0000-0000-2224-000000000013',
                        '40000000-0000-0000-2224-000000000014',
                        '40000000-0000-0000-2224-000000000015',
                        '40000000-0000-0000-2224-000000000016',
                        '40000000-0000-0000-2224-000000000017',
                        '40000000-0000-0000-2224-000000000018',
                        '40000000-0000-0000-2224-000000000019',
                        '40000000-0000-0000-2224-000000000020',
                        '40000000-0000-0000-2224-000000000021',
                        '40000000-0000-0000-2224-000000000022',
                        '40000000-0000-0000-2224-000000000023',
                        '40000000-0000-0000-2224-000000000024',
                        '40000000-0000-0000-2224-000000000025',
                        '40000000-0000-0000-2224-000000000026',
                        '40000000-0000-0000-2224-000000000027',
                        '40000000-0000-0000-2224-000000000028',
                        '40000000-0000-0000-2224-000000000029',
                        '40000000-0000-0000-2224-000000000030',
                        '40000000-0000-0000-2224-000000000031',
                        '40000000-0000-0000-2224-000000000032',
                        '40000000-0000-0000-2224-000000000033',
                        '40000000-0000-0000-2224-000000000034',
                        '40000000-0000-0000-2224-000000000035',
                        '40000000-0000-0000-2224-000000000036',
                        '40000000-0000-0000-2224-000000000037',
                        '40000000-0000-0000-2224-000000000038',
                        '40000000-0000-0000-2224-000000000039',
                        '40000000-0000-0000-2224-000000000040',
                        '40000000-0000-0000-2224-000000000041',
                        '40000000-0000-0000-2224-000000000042',
                        '40000000-0000-0000-2224-000000000043',
                        '40000000-0000-0000-2224-000000000044',
                        '40000000-0000-0000-2224-000000000045',
                        '40000000-0000-0000-2224-000000000046',
                        '40000000-0000-0000-2224-000000000047',
                        '40000000-0000-0000-2224-000000000048',
                        '40000000-0000-0000-2224-000000000049',
                        '40000000-0000-0000-2224-000000000050',
                        '40000000-0000-0000-2224-000000000051',
                        '40000000-0000-0000-2224-000000000052',
                        '40000000-0000-0000-2224-000000000053',
                        '40000000-0000-0000-2224-000000000054',
                        '40000000-0000-0000-2224-000000000055',
                        '40000000-0000-0000-2224-000000000056',
                        '40000000-0000-0000-2224-000000000057',
                        '40000000-0000-0000-2224-000000000058',
                        '40000000-0000-0000-2224-000000000059',
                        '40000000-0000-0000-2224-000000000060')
                    AND [Id] NOT IN ('40000000-0000-0000-2221-000000000001', '40000000-0000-0000-2221-000000000002', '40000000-0000-0000-2221-000000000003', '40000000-0000-0000-2221-000000000004', '40000000-0000-0000-2221-000000000005', '40000000-0000-0000-2221-000000000006', '40000000-0000-0000-2221-000000000007', '40000000-0000-0000-2222-000000000001', '40000000-0000-0000-2222-000000000002', '40000000-0000-0000-2222-000000000003', '40000000-0000-0000-2222-000000000004', '40000000-0000-0000-2222-000000000005', '40000000-0000-0000-2222-000000000006', '40000000-0000-0000-2222-000000000007', '40000000-0000-0000-2222-000000000008', '40000000-0000-0000-2222-000000000009', '40000000-0000-0000-2222-000000000010', '40000000-0000-0000-2222-000000000011');
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000001')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 1, [TaskName] = N'GAD RESMİ ÇİZİMİ'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000001';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000001', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 1, N'GAD RESMİ ÇİZİMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000002')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 2, [TaskName] = N'GAD RESMİ ÇİZİM ONAYI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000002';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000002', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 2, N'GAD RESMİ ÇİZİM ONAYI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000003')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 3, [TaskName] = N'Hesaplamalar'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000003';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000003', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teklif Hazırlama', 3, N'Hesaplamalar');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000004')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 4, [TaskName] = N'TUV Tip Onay Süreci'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000004';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000004', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 4, N'TUV Tip Onay Süreci');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000005')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 5, [TaskName] = N'Genel Tip Onay Resmi'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000005';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000005', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 5, N'Genel Tip Onay Resmi');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000006')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 6, [TaskName] = N'TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000006';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000006', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222221', N'Dizayn Mühendisi', 6, N'TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2221-000000000007')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222221', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 7, [TaskName] = N'TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2221-000000000007';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2221-000000000007', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222221', N'Teknik Ressam', 7, N'TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000001')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 1, [TaskName] = N'Hesaplamalar'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000001';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000001', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 1, N'Hesaplamalar');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000002')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 2, [TaskName] = N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000002';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000002', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 2, N'GÖVDE BOMBE ORYANTASYON HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000003')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 3, [TaskName] = N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000003';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000003', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 3, N'KRİTİK AKSESUAR LİSTESİ YAYINLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000004')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 4, [TaskName] = N'P&ID HAZIRLAMA'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000004';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000004', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 4, N'P&ID HAZIRLAMA');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000005')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 5, [TaskName] = N'GAD RESMİ ÇİZİMİ'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000005';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000005', 1, 1, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 5, N'GAD RESMİ ÇİZİMİ');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000006')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teklif Hazırlama', [SequenceNo] = 6, [TaskName] = N'GAD RESMİ ÇİZİM ONAYI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000006';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000006', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222222', N'Teklif Hazırlama', 6, N'GAD RESMİ ÇİZİM ONAYI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000007')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 6, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 7, [TaskName] = N'Genel Tip Onay Resmi'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000007';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000007', 1, 6, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 7, N'Genel Tip Onay Resmi');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000008')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 3, [DurationValue] = 1, [IsActive] = 1, [IsPassive] = 1, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 8, [TaskName] = N'TUV Tip Onay Süreci'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000008';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000008', 3, 1, 1, 1, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 8, N'TUV Tip Onay Süreci');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000009')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 9, [TaskName] = N'İÇ TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000009';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000009', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 9, N'İÇ TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000010')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 4, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Dizayn Mühendisi', [SequenceNo] = 10, [TaskName] = N'DIŞ TANK MONTAJ TASARIMI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000010';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000010', 1, 4, 1, 0, '22222222-2222-2222-2222-222222222222', N'Dizayn Mühendisi', 10, N'DIŞ TANK MONTAJ TASARIMI');
                END
                IF EXISTS (SELECT 1 FROM [DesignPlanningTaskTemplates] WHERE [Id] = '40000000-0000-0000-2222-000000000011')
                BEGIN
                    UPDATE [DesignPlanningTaskTemplates]
                    SET [DurationUnit] = 1, [DurationValue] = 2, [IsActive] = 1, [IsPassive] = 0, [ProjectTypeId] = '22222222-2222-2222-2222-222222222222', [ResponsibleRole] = N'Teknik Ressam', [SequenceNo] = 11, [TaskName] = N'DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI'
                    WHERE [Id] = '40000000-0000-0000-2222-000000000011';
                END
                ELSE
                BEGIN
                    INSERT INTO [DesignPlanningTaskTemplates] ([Id], [DurationUnit], [DurationValue], [IsActive], [IsPassive], [ProjectTypeId], [ResponsibleRole], [SequenceNo], [TaskName])
                    VALUES ('40000000-0000-0000-2222-000000000011', 1, 2, 1, 0, '22222222-2222-2222-2222-222222222222', N'Teknik Ressam', 11, N'DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI');
                END
            ");
        }
    }
}
