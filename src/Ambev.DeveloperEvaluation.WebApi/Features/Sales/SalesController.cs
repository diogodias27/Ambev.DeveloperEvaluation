using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="request">The user creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created user details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateSaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSalesResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<CreateSalesResponse>(response)
            });
        }


        ///// <summary>
        ///// Gets a sale by ID
        ///// </summary>
        ///// <param name="id">The ID of the sale</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns>The sale details</returns>
        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<GetSaleResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetSaleById(Guid id, CancellationToken cancellationToken)
        //{
        //    var query = new GetSaleByIdQuery { Id = id };
        //    var response = await _mediator.Send(query, cancellationToken);

        //    if (response == null)
        //        return NotFound(new ApiResponse { Success = false, Message = "Sale not found" });

        //    return Ok(new ApiResponseWithData<GetSaleResponse>
        //    {
        //        Success = true,
        //        Message = "Sale retrieved successfully",
        //        Data = _mapper.Map<GetSaleResponse>(response)
        //    });
        //}

        ///// <summary>
        ///// Updates a sale
        ///// </summary>
        ///// <param name="id">The ID of the sale to update</param>
        ///// <param name="request">The update request</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns>The updated sale details</returns>
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<UpdateSaleResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> UpdateSale(Guid id, [FromBody] UpdateSaleRequest request, CancellationToken cancellationToken)
        //{
        //    var validator = new UpdateSaleRequestValidator();
        //    var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<UpdateSaleCommand>(request);
        //    command.Id = id;

        //    var response = await _mediator.Send(command, cancellationToken);

        //    if (response == null)
        //        return NotFound(new ApiResponse { Success = false, Message = "Sale not found" });

        //    return Ok(new ApiResponseWithData<UpdateSaleResponse>
        //    {
        //        Success = true,
        //        Message = "Sale updated successfully",
        //        Data = _mapper.Map<UpdateSaleResponse>(response)
        //    });
        //}

        ///// <summary>
        ///// Deletes a sale
        ///// </summary>
        ///// <param name="id">The ID of the sale to delete</param>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns>Status of the deletion</returns>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> DeleteSale(Guid id, CancellationToken cancellationToken)
        //{
        //    var command = new DeleteSaleCommand { Id = id };
        //    var result = await _mediator.Send(command, cancellationToken);

        //    if (!result)
        //        return NotFound(new ApiResponse { Success = false, Message = "Sale not found" });

        //    return Ok(new ApiResponse
        //    {
        //        Success = true,
        //        Message = "Sale deleted successfully"
        //    });
        //}


        ///// <summary>
        ///// Gets all sales
        ///// </summary>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns>List of sales</returns>
        //[HttpGet]
        //[ProducesResponseType(typeof(ApiResponseWithData<List<GetSaleResponse>>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllSales(CancellationToken cancellationToken)
        //{
        //    var query = new GetAllSalesQuery();
        //    var response = await _mediator.Send(query, cancellationToken);

        //    var mappedResponse = _mapper.Map<List<GetSaleResponse>>(response);

        //    return Ok(new ApiResponseWithData<List<GetSaleResponse>>
        //    {
        //        Success = true,
        //        Message = "Sales retrieved successfully",
        //        Data = mappedResponse
        //    });
        //}


        ///// <summary>
        ///// Gets all sales
        ///// </summary>
        ///// <param name="cancellationToken">Cancellation token</param>
        ///// <returns>List of sales</returns>
        //[HttpGet]
        //[ProducesResponseType(typeof(ApiResponseWithData<List<GetSaleResponse>>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllSales(CancellationToken cancellationToken)
        //{
        //    var query = new GetAllSalesQuery();
        //    var response = await _mediator.Send(query, cancellationToken);

        //    var mappedResponse = _mapper.Map<List<GetSaleResponse>>(response);

        //    return Ok(new ApiResponseWithData<List<GetSaleResponse>>
        //    {
        //        Success = true,
        //        Message = "Sales retrieved successfully",
        //        Data = mappedResponse
        //    });
        //}


    }
}
