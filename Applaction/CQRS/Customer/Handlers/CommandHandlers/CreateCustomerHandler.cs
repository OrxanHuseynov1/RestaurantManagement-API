using Application.CQRS.Customer.Commands.Requests;
using Application.CQRS.Customer.Commands.Responses;
using AutoMapper;
using Common.GlobalResponses.Generics;
using FluentValidation;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Customer.Handlers.CommandHandlers;

public class CreateCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCustomerRequest> validator) : IRequestHandler<CreateCustomerRequest, ResponseModel<CreateCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidator<CreateCustomerRequest> _validator = validator;

    public async Task<ResponseModel<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        await _unitOfWork.CustomerRepository.AddAsync(customer);

        return new ResponseModel<CreateCustomerResponse>
        {
            Data = _mapper.Map<CreateCustomerResponse>(customer),
            Errors = [],
            IsSuccess = true
        };
    }
}
