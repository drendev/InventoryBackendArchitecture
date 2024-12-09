using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ReportDto
    {
        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        public int CurrentStock { get; set; } = 1;

        [Required]
        public string ReportType { get; set; } = string.Empty;
    }
}
