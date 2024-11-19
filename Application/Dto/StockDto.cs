using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class StockDto
    {
        [Required]
        public string ProductId { get; set; } = string.Empty;

        [Required]
        public int Stock { get; set; } = 1;
    }
}
