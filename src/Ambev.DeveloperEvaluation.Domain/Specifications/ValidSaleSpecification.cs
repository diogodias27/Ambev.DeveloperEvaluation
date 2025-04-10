using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications
{
    public class ValidSaleSpecification : ISpecification<Sale>
    {
        public bool IsSatisfiedBy(Sale entity)
        {
            var prod = entity.Items
                .Select(x => x.ProductId)
                .GroupBy(x => x)
                .Any(g => g.Count() > 20);

            if (prod)            
                return false;
          
            return true;
        }
    }
}

