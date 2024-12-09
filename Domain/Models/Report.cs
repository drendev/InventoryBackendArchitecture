using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Report
    {
        public string ReportId { get; set; }
        public string? ProductName { get; set; }
        public string? UserName { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int Quantity { get; set; }
        public int CurrentStock { get; set; }
        public string? ReportType { get; set; }
        public TimeOnly Created { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        public Report()
        {
            ReportId = Guid.NewGuid().ToString("N").Substring(0, 14);

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
            DateTime manilaTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

            Date = DateOnly.FromDateTime(manilaTime);
            Created = TimeOnly.FromDateTime(manilaTime);
        }
    }
}
