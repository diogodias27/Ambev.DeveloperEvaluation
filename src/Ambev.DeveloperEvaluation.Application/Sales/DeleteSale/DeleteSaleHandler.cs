using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeleteUserCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISalesRepository _salesRepository;

    /// <summary>
    /// Initializes a new instance of DeleteUserHandler
    /// </summary>
    /// <param name="salesRepository">The user repository</param>
    /// <param name="validator">The validator for DeleteUserCommand</param> 
    public DeleteSaleHandler(ISalesRepository salesRepository)
    {
        _salesRepository = salesRepository;
    }

    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

         await _salesRepository.DeleteAsync(/*request.Id*/"ss", cancellationToken);
        //var success = await _salesRepository.DeleteAsync(/*request.Id*/"ss", cancellationToken);
        //if (!success)
        //    throw new KeyNotFoundException($"User with ID {request.Id} not found");

        return new DeleteSaleResponse { Success = true };
    }
}
