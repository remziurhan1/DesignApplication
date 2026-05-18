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
        Add(items, TekCidarlıDepolamaId, 4, "Teklif Hazırlama", "GÖVDE BOMBE ORYANTASYON HAZIRLAMA", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 5, "Teklif Hazırlama", "KRİTİK AKSESUAR LİSTESİ YAYINLAMA", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 6, "Dizayn Mühendisi", "TUV Tip Onay Süreci (Tüm Projeler İçin)", 1, DurationUnit.Week, true);
        Add(items, TekCidarlıDepolamaId, 7, "Dizayn Mühendisi", "Genel Tip Onay Resmi", 6, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 8, "Dizayn Mühendisi", "Onay ve kontrol süreci (TUV)", 1, DurationUnit.Week, true);
        Add(items, TekCidarlıDepolamaId, 9, "Dizayn Mühendisi", "TANK BOMBE MONTAJ RESMİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 10, "Dizayn Mühendisi", "TANK PUL ÇAPI KONTROL", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 11, "Dizayn Mühendisi", "TANK GÖVDE BOMBE KESİM RESMİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 12, "Dizayn Mühendisi", "TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 13, "Dizayn Mühendisi", "TANK REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 14, "Dizayn Mühendisi", "TANK AYAK TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 15, "Dizayn Mühendisi", "TANK AYAK REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 16, "Dizayn Mühendisi", "BOYA GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 17, "Dizayn Mühendisi", "ETİKET GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 18, "Dizayn Mühendisi", "ETİKET TASARIMI", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 19, "Dizayn Mühendisi", "Tank Manuel Hazırlanması", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 20, "Teknik Ressam", "TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 21, "Teknik Ressam", "TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 22, "Teknik Ressam", "TANK AYAK TEKNİK RESİMLERİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 23, "Teknik Ressam", "TANK AKSESUAR TEKNİK RESİMLERİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıDepolamaId, 24, "Teknik Ressam", "NAKLİYE RESMİ", 1, DurationUnit.Hour, false);

        Add(items, CiftCidarlıDepolamaId, 1, "Teklif Hazırlama", "Hesaplamalar", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 2, "Teklif Hazırlama", "GÖVDE BOMBE ORYANTASYON HAZIRLAMA", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 3, "Teklif Hazırlama", "KRİTİK AKSESUAR LİSTESİ YAYINLAMA", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 4, "Teklif Hazırlama", "P&ID HAZIRLAMA", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 5, "Teklif Hazırlama", "GAD RESMİ ÇİZİMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 6, "Teklif Hazırlama", "GAD RESMİ ÇİZİM ONAYI", 1, DurationUnit.Week, true);
        Add(items, CiftCidarlıDepolamaId, 7, "Dizayn Mühendisi", "Genel Tip Onay Resmi", 6, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 8, "Dizayn Mühendisi", "TUV Tip Onay Süreci (Tüm Projeler İçin)", 1, DurationUnit.Week, true);
        Add(items, CiftCidarlıDepolamaId, 9, "Dizayn Mühendisi", "İÇ TANK BOMBE MONTAJ RESMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 10, "Dizayn Mühendisi", "İÇ TANK PUL ÇAPI KONTROL", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 11, "Dizayn Mühendisi", "İÇ TANK GÖVDE BOMBE KESİM RESMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 12, "Dizayn Mühendisi", "İÇ TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 13, "Dizayn Mühendisi", "İÇ TANK REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 14, "Dizayn Mühendisi", "İÇ TANK BORULAMA TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 15, "Dizayn Mühendisi", "İÇ TANK BORULAMA REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 16, "Dizayn Mühendisi", "DIŞ TANK BOMBE MONTAJ TEKNİK RESİM", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 17, "Dizayn Mühendisi", "DIŞ TANK PUL ÇAPI KONTROL", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 18, "Dizayn Mühendisi", "DIŞ TANK GÖVDE BOMBE KESİM RESMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 19, "Dizayn Mühendisi", "DIŞ TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 20, "Dizayn Mühendisi", "DIŞ TANK REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 21, "Dizayn Mühendisi", "İGM MONTAJ TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 22, "Dizayn Mühendisi", "DIŞ BORULAMA TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 23, "Dizayn Mühendisi", "DIŞ BORULAMA REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 24, "Dizayn Mühendisi", "BUHARLIŞTIRICI TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 25, "Dizayn Mühendisi", "BUHARLIŞTIRICI REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 26, "Dizayn Mühendisi", "İZOLASYON GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 27, "Dizayn Mühendisi", "BOYA GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 28, "Dizayn Mühendisi", "ETİKET GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 29, "Dizayn Mühendisi", "ETİKET TASARIMI", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 30, "Dizayn Mühendisi", "Tank Manuel Hazırlanması", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 31, "Teknik Ressam", "DIŞ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 32, "Teknik Ressam", "DIŞ TANK GÖVDE MONTAJ teknik resmi ( dış tank ring& ring sarımı & mapa yerleşimi & dablinler)", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 33, "Teknik Ressam", "PROFİL AYAK MONTAJ RESMİNİN HAZIRLANMASI TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 34, "Teknik Ressam", "İÇ TANK BORULAMA TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 35, "Teknik Ressam", "İÇ TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 36, "Teknik Ressam", "İÇ TANK GÖVDE MONTAJ& NOZUL& DABLİN & TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 37, "Teknik Ressam", "İGM MONTAJ TEKNİK RESİM", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 38, "Teknik Ressam", "DIŞ BORULAMA  TEKNİK RESİM", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 39, "Teknik Ressam", "EVAP KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 40, "Teknik Ressam", "EVAP TEKNİK RESİM", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 41, "Teknik Ressam", "NAKLİYE RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıDepolamaId, 42, "Teknik Ressam", "ASBUILT RESMİ HAZIRLANMASI", 2, DurationUnit.Hour, false);

        Add(items, TekCidarlıTransportId, 1, "Teklif Hazırlama", "Hesaplamalar", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 2, "Teklif Hazırlama", "GÖVDE BOMBE ORYANTASYON HAZIRLAMA", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 3, "Teklif Hazırlama", "KRİTİK AKSESUAR LİSTESİ YAYINLAMA", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 4, "Teklif Hazırlama", "P&ID HAZIRLAMA", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 5, "Teklif Hazırlama", "GAD RESMİ ÇİZİMİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 6, "Teklif Hazırlama", "GAD RESMİ ÇİZİM ONAYI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 7, "Dizayn Mühendisi", "Genel Tip Onay Resmi", 6, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 8, "Dizayn Mühendisi", "TUV Tip Onay Süreci (Tüm Projeler İçin)", 1, DurationUnit.Week, true);
        Add(items, TekCidarlıTransportId, 9, "Dizayn Mühendisi", "TANK BOMBE MONTAJ RESMİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 10, "Dizayn Mühendisi", "TANK PUL ÇAPI KONTROL", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 11, "Dizayn Mühendisi", "TANK GÖVDE BOMBE KESİM RESMİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 12, "Dizayn Mühendisi", "TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 13, "Dizayn Mühendisi", "TANK MONTAJ REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 14, "Dizayn Mühendisi", "DALGAKIRAN TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 15, "Dizayn Mühendisi", "DALGAKIRAN REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 16, "Dizayn Mühendisi", "ŞASE MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 17, "Dizayn Mühendisi", "ŞASE MONTAJ REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 18, "Dizayn Mühendisi", "TANK AYAK MONTAJ TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 19, "Dizayn Mühendisi", "TANK AYAK MONTAJ REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 20, "Dizayn Mühendisi", "KİNG PİN & MEKANİK AYAK TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 21, "Dizayn Mühendisi", "KİNG PİN & MEKANİK AYAK REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 22, "Dizayn Mühendisi", "KONSOL MONTAJ TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 23, "Dizayn Mühendisi", "KONSOL MONTAJ REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 24, "Dizayn Mühendisi", "ŞASE MONTAJ SON MONTAJ REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 25, "Dizayn Mühendisi", "DIŞ BORULAMA TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 26, "Dizayn Mühendisi", "DIŞ BORULAMA REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 27, "Dizayn Mühendisi", "DOLAP TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 28, "Dizayn Mühendisi", "DOLAP REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 29, "Dizayn Mühendisi", "BOYA GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 30, "Dizayn Mühendisi", "ETİKET GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 31, "Dizayn Mühendisi", "ETİKET TASARIMI", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 32, "Dizayn Mühendisi", "Tank Manuel Hazırlanması", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 33, "Teknik Ressam", "TANK KESİM RESİMLERİNİN VE LİSTELERİNİN HAZIRLANMASI", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 34, "Teknik Ressam", "Şase Kesim Resimlerinin Listelerinin Hazırlanması", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 35, "Teknik Ressam", "Şase Teknik Resmi", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 36, "Teknik Ressam", "DALGAKIRAN KESİM LİSTESİNİN HAZIRLANMASI", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 37, "Teknik Ressam", "TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ", 4, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 38, "Teknik Ressam", "DALGAKIRAN TEKNİK RESİMLERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 39, "Teknik Ressam", "KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 40, "Teknik Ressam", "TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 41, "Teknik Ressam", "TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK TEKNİK RESMİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 42, "Teknik Ressam", "KONSOL MONTAJ TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 43, "Teknik Ressam", "DOLAP TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 44, "Teknik Ressam", "BORULAMA TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 45, "Teknik Ressam", "NAKLİYE RESMİ", 1, DurationUnit.Hour, false);
        Add(items, TekCidarlıTransportId, 46, "Teknik Ressam", "ASBUİLT", 1, DurationUnit.Hour, false);

        Add(items, CiftCidarlıTransportId, 1, "Teklif Hazırlama", "Hesaplamalar", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 2, "Teklif Hazırlama", "GÖVDE BOMBE ORYANTASYON HAZIRLAMA", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 3, "Teklif Hazırlama", "KRİTİK AKSESUAR LİSTESİ YAYINLAMA", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 4, "Teklif Hazırlama", "P&ID HAZIRLAMA", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 5, "Teklif Hazırlama", "GAD RESMİ ÇİZİMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 6, "Teklif Hazırlama", "GAD RESMİ ÇİZİM ONAYI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 7, "Dizayn Mühendisi", "Genel Tip Onay Resmi", 6, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 8, "Dizayn Mühendisi", "TUV Tip Onay Süreci (Tüm Projeler İçin)", 1, DurationUnit.Week, true);
        Add(items, CiftCidarlıTransportId, 9, "Dizayn Mühendisi", "İÇ TANK BOMBE MONTAJ RESMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 10, "Dizayn Mühendisi", "İÇ TANK PUL ÇAPI KONTROL", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 11, "Dizayn Mühendisi", "İÇ TANK GÖVDE BOMBE KESİM RESMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 12, "Dizayn Mühendisi", "DIŞ TANK BOMBE MONTAJ RESMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 13, "Dizayn Mühendisi", "DIŞ TANK PUL ÇAPI KONTROL", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 14, "Dizayn Mühendisi", "DIŞ TANK GÖVDE BOMBE KESİM RESMİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 15, "Dizayn Mühendisi", "İÇ TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 16, "Dizayn Mühendisi", "DALGAKIRAN TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 17, "Dizayn Mühendisi", "DALGAKIRAN REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 18, "Dizayn Mühendisi", "İÇ TANK MONTAJ REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 19, "Dizayn Mühendisi", "İÇ TANK İÇ BORULAMA MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 20, "Dizayn Mühendisi", "İÇ TANK İÇ BORULAMA MONTAJ REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 21, "Dizayn Mühendisi", "DIŞ TANK MONTAJ TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 22, "Dizayn Mühendisi", "DIŞ TANK MONTAJ REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 23, "Dizayn Mühendisi", "İGM MONTAJ TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 24, "Dizayn Mühendisi", "İGM MONTAJ REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 25, "Dizayn Mühendisi", "DIŞ BORULAMA TASARIMI", 6, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 26, "Dizayn Mühendisi", "DIŞ BORULAMA REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 27, "Dizayn Mühendisi", "TANK AYAK MONTAJ TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 28, "Dizayn Mühendisi", "TANK AYAK MONTAJ REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 29, "Dizayn Mühendisi", "ŞASE MONTAJ TASARIMI", 6, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 30, "Dizayn Mühendisi", "ŞASE MONTAJ REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 31, "Dizayn Mühendisi", "KİNG PİN & MEKANİK AYAK TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 32, "Dizayn Mühendisi", "KİNG PİN & MEKANİK AYAK REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 33, "Dizayn Mühendisi", "KONSOL MONTAJ TASARIMI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 34, "Dizayn Mühendisi", "KONSOL MONTAJ REÇETESİ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 35, "Dizayn Mühendisi", "ŞASE MONTAJ SON MONTAJ REÇETESİ", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 36, "Dizayn Mühendisi", "DOLAP TASARIMI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 37, "Dizayn Mühendisi", "DOLAP REÇETESİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 38, "Dizayn Mühendisi", "BOYA GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 39, "Dizayn Mühendisi", "ETİKET GRUBU REÇETE GİRİŞ", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 40, "Dizayn Mühendisi", "ETİKET TASARIMI", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 41, "Dizayn Mühendisi", "Tank Manuel Hazırlanması", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 42, "Teknik Ressam", "İç Tank Kesim Listelerinin Hazırlanması", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 43, "Teknik Ressam", "DALGAKIRAN KESİM LİSTESİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 44, "Teknik Ressam", "DALGAKIRAN TEKNİK RESİMLERİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 45, "Teknik Ressam", "İÇ TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 46, "Teknik Ressam", "İç BORULAMA TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 47, "Teknik Ressam", "Dış Tank Kesim Listelerinin Hazırlanması", 1, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 48, "Teknik Ressam", "Dış TANK GÖVDE MONTAJ & NOZUL& DABLİN & TEKNİK RESMİ", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 49, "Teknik Ressam", "İGM MONTAJ TEKNİK RESİM", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 50, "Teknik Ressam", "KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 51, "Teknik Ressam", "KİNG PİN & MEKANİK AYAK Teknik Resimlerinin HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 52, "Teknik Ressam", "TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK KESİM LİSTESİNİN HAZIRLANMASI", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 53, "Teknik Ressam", "TANK AYAK MONTAJ TASARIMI & KİNG PİN & MEKANİK AYAK TEKNİK RESMİN HAZIRLANMASI", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 54, "Teknik Ressam", "Şase Teknik Resimlerinin Hazırlanması", 4, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 55, "Teknik Ressam", "KONSOL MONTAJ TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 56, "Teknik Ressam", "Dolap Kesim Listelerinin Hazırlanması", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 57, "Teknik Ressam", "DOLAP TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 58, "Teknik Ressam", "Dış BORULAMA TEKNİK RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 59, "Teknik Ressam", "NAKLİYE RESMİ", 2, DurationUnit.Hour, false);
        Add(items, CiftCidarlıTransportId, 60, "Teknik Ressam", "ASBUİLT", 2, DurationUnit.Hour, false);

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
