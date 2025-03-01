using Application.CQRS.Customer.Commands.Requests;
using Application.CQRS.Customer.Commands.Responses;
using Common.Exceptions;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Customer.Handlers.CommandHandlers;


public sealed class DeleteCustomerHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCustomerRequest, ResponseModel<DeleteCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ResponseModel<DeleteCustomerResponse>> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
        if (customer is null)
            throw new BadRequestException("Customer can not be found with provided id");

        await _unitOfWork.CustomerRepository.Remove(request.Id, 0);
        await _unitOfWork.SaveChanges();
        return new ResponseModel<DeleteCustomerResponse>
        {
            Data = new DeleteCustomerResponse
            {
                Message = "Customer deleted successfully"
            },
            Errors = [],
            IsSuccess = true
        };
    }
}
