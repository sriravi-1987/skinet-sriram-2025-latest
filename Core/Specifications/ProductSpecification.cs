using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>, ISpecification<Product>
    {
        public ProductSpecification(string? brand, string? type, string? sort)
            : base(p =>
                (string.IsNullOrWhiteSpace(brand) || p.Brand == brand) &&
                (string.IsNullOrWhiteSpace(type) || p.Type == type))
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }
    }
}
