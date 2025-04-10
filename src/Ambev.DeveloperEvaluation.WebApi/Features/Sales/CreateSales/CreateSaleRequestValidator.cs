using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(request => request.SaleNumber).NotEmpty();
            RuleFor(request => request.SaleDate).NotEmpty();
            RuleFor(request => request.BranchName).NotEmpty();
            RuleFor(request => request.TotalAmount).NotEmpty();            
            RuleFor(request => request.CustomerName).NotEmpty();
            RuleFor(request => request.CustomerId).NotEmpty();
            //RuleFor(request => request.Items).NotEmpty();
            RuleFor(request => request.BranchName).NotEmpty();                
        }
    }
}
