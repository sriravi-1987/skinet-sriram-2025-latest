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
        public ProductSpecification(ProductSpecParams specParams)
            : base(p =>
                (string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search)) && 
                (!specParams.Brands.Any() || specParams.Brands.Contains(p.Brand)) &&
                (!specParams.Types.Any() || specParams.Types.Contains(p.Type)))
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            switch (specParams.Sort)
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
