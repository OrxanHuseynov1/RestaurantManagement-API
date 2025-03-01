using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customer.Queries.Requests;

public record GetCustomerByIdRequest : IRequest<ResponseModel<GetCustomerByIdResponse>>
{
    public int Id { get; set; }
}
