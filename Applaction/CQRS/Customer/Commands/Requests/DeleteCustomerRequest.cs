using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customer.Commands.Requests;

public record struct DeleteCustomerRequest : IRequest<ResponseModel<DeleteCustomerResponse>>
{
    public int Id { get; set; }
}
