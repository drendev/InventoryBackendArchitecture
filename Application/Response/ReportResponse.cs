using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public record class ReportResponse(bool? Flag = null, string? Message = null, IEnumerable<Report>? Reports = null);

}
