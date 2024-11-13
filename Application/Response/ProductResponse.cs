using Domain.Models;

namespace Application.Response
{
    public record ProductResponse(bool Flag, string Message = null!, Product? Product = null, IEnumerable<Product>? Products = null);
}
