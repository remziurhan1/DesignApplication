using DesignPlanning.Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using TaskStatus = DesignPlanning.Entities.TaskStatus;

namespace MVC.ProductManagement.Presentation.Services.DesignPlanning;

public static class DesignPlanningPlanExcelExporter
{
    private static readonly string[] Headers =
    {
        "Atanan / Grup",
        "Proje Kodu",
        "Proje Adı",
        "Sıra",
        "Görev",
        "Sorumlu Rol",
        "Başlangıç",
        "Bitiş",
        "Süre",
        "Pasif",
        "Durum"
    };

    public static byte[] Export(string title, DateTime selectedDate, IReadOnlyList<ProjectTask> tasks, bool groupByEmployee)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add(SanitizeWorksheetName(title));

        worksheet.Cells[1, 1].Value = title;
        worksheet.Cells[1, 1, 1, Headers.Length].Merge = true;
        worksheet.Cells[1, 1].Style.Font.Bold = true;
        worksheet.Cells[1, 1].Style.Font.Size = 14;
        worksheet.Cells[1, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
        worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(13, 110, 253));
        worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);

        worksheet.Cells[2, 1].Value = "Tarih";
        worksheet.Cells[2, 2].Value = selectedDate.ToString("dd.MM.yyyy");
        worksheet.Cells[2, 1].Style.Font.Bold = true;

        var row = 4;
        WriteHeader(worksheet, row++);

        if (groupByEmployee)
        {
            foreach (var group in tasks.GroupBy(GetEmployeeGroupName).OrderBy(x => x.Key))
            {
                worksheet.Cells[row, 1].Value = group.Key;
                worksheet.Cells[row, 1, row, Headers.Length].Merge = true;
                worksheet.Cells[row, 1].Style.Font.Bold = true;
                worksheet.Cells[row, 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                worksheet.Cells[row, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(226, 239, 218));
                row++;

                foreach (var task in group.OrderBy(x => x.PlannedStart).ThenBy(x => x.SequenceNo))
                {
                    WriteTaskRow(worksheet, row++, task);
                }
            }
        }
        else
        {
            foreach (var task in tasks.OrderBy(x => x.PlannedStart).ThenBy(x => x.SequenceNo))
            {
                WriteTaskRow(worksheet, row++, task);
            }
        }

        if (row > 5)
        {
            worksheet.Cells[4, 1, row - 1, Headers.Length].AutoFilter = !groupByEmployee;
            worksheet.Cells[4, 1, row - 1, Headers.Length].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[4, 1, row - 1, Headers.Length].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[4, 1, row - 1, Headers.Length].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            worksheet.Cells[4, 1, row - 1, Headers.Length].Style.Border.Right.Style = ExcelBorderStyle.Thin;
        }

        worksheet.View.FreezePanes(5, 1);
        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
        worksheet.Column(7).Style.Numberformat.Format = "dd.mm.yyyy hh:mm";
        worksheet.Column(8).Style.Numberformat.Format = "dd.mm.yyyy hh:mm";

        return package.GetAsByteArray();
    }

    private static void WriteHeader(ExcelWorksheet worksheet, int row)
    {
        for (var i = 0; i < Headers.Length; i++)
        {
            worksheet.Cells[row, i + 1].Value = Headers[i];
        }

        worksheet.Cells[row, 1, row, Headers.Length].Style.Font.Bold = true;
        worksheet.Cells[row, 1, row, Headers.Length].Style.Fill.PatternType = ExcelFillStyle.Solid;
        worksheet.Cells[row, 1, row, Headers.Length].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(217, 225, 242));
    }

    private static void WriteTaskRow(ExcelWorksheet worksheet, int row, ProjectTask task)
    {
        worksheet.Cells[row, 1].Value = GetEmployeeGroupName(task);
        worksheet.Cells[row, 2].Value = task.Project?.ProjectCode;
        worksheet.Cells[row, 3].Value = task.Project?.ProjectName;
        worksheet.Cells[row, 4].Value = task.SequenceNo;
        worksheet.Cells[row, 5].Value = task.TaskName;
        worksheet.Cells[row, 6].Value = task.ResponsibleRole;
        worksheet.Cells[row, 7].Value = task.PlannedStart;
        worksheet.Cells[row, 8].Value = task.PlannedEnd;
        worksheet.Cells[row, 9].Value = $"{task.DurationValue:N2} {task.DurationUnit}";
        worksheet.Cells[row, 10].Value = task.IsPassive ? "Evet" : "Hayır";
        worksheet.Cells[row, 11].Value = GetStatusText(task.Status);
    }

    private static string GetEmployeeGroupName(ProjectTask task)
    {
        if (task.IsPassive)
        {
            return "Pasif takip";
        }

        return string.IsNullOrWhiteSpace(task.AssignedEmployee?.FullName)
            ? "Atanmamış"
            : task.AssignedEmployee.FullName;
    }

    private static string GetStatusText(TaskStatus status) => status switch
    {
        TaskStatus.Waiting => "Bekliyor",
        TaskStatus.Planned => "Planlandı",
        TaskStatus.InProgress => "Devam ediyor",
        TaskStatus.Completed => "Tamamlandı",
        TaskStatus.Delayed => "Gecikti",
        _ => status.ToString()
    };

    private static string SanitizeWorksheetName(string name)
    {
        var invalidChars = new[] { ':', '\\', '/', '?', '*', '[', ']' };
        var sanitized = invalidChars.Aggregate(name, (current, invalidChar) => current.Replace(invalidChar, '-'));
        return sanitized.Length <= 31 ? sanitized : sanitized[..31];
    }
}
