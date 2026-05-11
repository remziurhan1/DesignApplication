using DesignPlanning.Entities;

namespace DesignPlanning.DataAccess;

public static class DesignPlanningSeed
{
    public static readonly Guid RemziUrhanId = Guid.Parse("11111111-1111-1111-1111-111111111111");
    public static readonly Guid BusraAtesId = Guid.Parse("11111111-1111-1111-1111-111111111112");
    public static readonly Guid ErdoganElginId = Guid.Parse("11111111-1111-1111-1111-111111111113");
    public static readonly Guid MuhammedSimsekId = Guid.Parse("11111111-1111-1111-1111-111111111114");
    public static readonly Guid AyhanSahinId = Guid.Parse("11111111-1111-1111-1111-111111111115");
    public static readonly Guid MustafaCakalId = Guid.Parse("11111111-1111-1111-1111-111111111116");

    public static readonly Guid TekCidarlıDepolamaId = Guid.Parse("22222222-2222-2222-2222-222222222221");
    public static readonly Guid CiftCidarlıDepolamaId = Guid.Parse("22222222-2222-2222-2222-222222222222");
    public static readonly Guid TekCidarlıTransportId = Guid.Parse("22222222-2222-2222-2222-222222222223");
    public static readonly Guid CiftCidarlıTransportId = Guid.Parse("22222222-2222-2222-2222-222222222224");

    public static IEnumerable<Employee> Employees() => new[]
    {
        new Employee { Id = RemziUrhanId, FullName = "Remzi Urhan", DailyCapacityHours = 8, IsActive = true },
        new Employee { Id = BusraAtesId, FullName = "Büşra Ateş", DailyCapacityHours = 8, IsActive = true },
        new Employee { Id = ErdoganElginId, FullName = "Erdoğan Elgin", DailyCapacityHours = 8, IsActive = true },
        new Employee { Id = MuhammedSimsekId, FullName = "Muhammed Şimşek", DailyCapacityHours = 8, IsActive = true },
        new Employee { Id = AyhanSahinId, FullName = "Ayhan Şahin", DailyCapacityHours = 8, IsActive = true },
        new Employee { Id = MustafaCakalId, FullName = "Mustafa Çakal", DailyCapacityHours = 8, IsActive = true }
    };

    public static IEnumerable<EmployeeExpertise> EmployeeExpertises() => new[]
    {
        Expertise("31111111-1111-1111-1111-111111111111", RemziUrhanId, "Teklif Hazırlama"),
        Expertise("31111111-1111-1111-1111-111111111112", BusraAtesId, "Tek Cidarlı Depolama"),
        Expertise("31111111-1111-1111-1111-111111111113", BusraAtesId, "Tek Cidarlı Transport"),
        Expertise("31111111-1111-1111-1111-111111111114", ErdoganElginId, "Çift Cidarlı Depolama"),
        Expertise("31111111-1111-1111-1111-111111111115", ErdoganElginId, "Çift Cidarlı Transport"),
        Expertise("31111111-1111-1111-1111-111111111116", MuhammedSimsekId, "Tek Cidarlı Depolama"),
        Expertise("31111111-1111-1111-1111-111111111117", MuhammedSimsekId, "Çift Cidarlı Depolama"),
        Expertise("31111111-1111-1111-1111-111111111118", AyhanSahinId, "Teknik Ressam"),
        Expertise("31111111-1111-1111-1111-111111111119", MustafaCakalId, "Teknik Ressam")
    };

    public static IEnumerable<ProjectType> ProjectTypes() => new[]
    {
        new ProjectType { Id = TekCidarlıDepolamaId, Name = "Tek Cidarlı Depolama" },
        new ProjectType { Id = CiftCidarlıDepolamaId, Name = "Çift Cidarlı Depolama" },
        new ProjectType { Id = TekCidarlıTransportId, Name = "Tek Cidarlı Transport" },
        new ProjectType { Id = CiftCidarlıTransportId, Name = "Çift Cidarlı Transport" }
    };

    public static IEnumerable<TaskTemplate> TaskTemplates()
    {
        var items = new List<TaskTemplate>();
        Add(items, TekCidarlıDepolamaId, 1, "Teklif Hazırlama", "GAD RESMİ ÇİZİMİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 2, "Teklif Hazırlama", "GAD RESMİ ÇİZİM ONAYI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 3, "Teklif Hazırlama", "Hesaplamalar", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 4, "Dizayn Mühendisi", "TUV Tip Onay Süreci", 1, DurationUnit.Week, true);
        Add(items, TekCidarlıDepolamaId, 5, "Dizayn Mühendisi", "Genel Tip Onay Resmi", 6, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 6, "Dizayn Mühendisi", "TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 7, "Teknik Ressam", "TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);

        Add(items, CiftCidarlıDepolamaId, 1, "Teklif Hazırlama", "Hesaplamalar", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 2, "Teklif Hazırlama", "GÖVDE BOMBE ORYANTASYON HAZIRLAMA", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 3, "Teklif Hazırlama", "KRİTİK AKSESUAR LİSTESİ YAYINLAMA", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 4, "Teklif Hazırlama", "P&ID HAZIRLAMA", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 5, "Teklif Hazırlama", "GAD RESMİ ÇİZİMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 6, "Teklif Hazırlama", "GAD RESMİ ÇİZİM ONAYI", 1, DurationUnit.Week, true);
        Add(items, CiftCidarlıDepolamaId, 7, "Dizayn Mühendisi", "Genel Tip Onay Resmi", 6, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 8, "Dizayn Mühendisi", "TUV Tip Onay Süreci", 1, DurationUnit.Week, true);
        Add(items, CiftCidarlıDepolamaId, 9, "Dizayn Mühendisi", "İÇ TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 10, "Dizayn Mühendisi", "DIŞ TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 11, "Teknik Ressam", "DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        return items;
    }

    private static EmployeeExpertise Expertise(string id, Guid employeeId, string name) => new() { Id = Guid.Parse(id), EmployeeId = employeeId, ExpertiseName = name, Priority = 1 };

    private static void Add(List<TaskTemplate> items, Guid projectTypeId, int sequenceNo, string role, string name, decimal duration, DurationUnit unit, bool passive) =>
        items.Add(new TaskTemplate
        {
            Id = Guid.Parse($"40000000-0000-0000-{projectTypeId.ToString()[^4..]}-{sequenceNo.ToString().PadLeft(12, '0')}"),
            ProjectTypeId = projectTypeId,
            SequenceNo = sequenceNo,
            ResponsibleRole = role,
            TaskName = name,
            DurationValue = duration,
            DurationUnit = unit,
            IsPassive = passive,
            IsActive = true
        });
}
