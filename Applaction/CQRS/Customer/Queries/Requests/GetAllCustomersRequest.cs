using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customer.Queries.Requests;

public record GetAllCustomersRequest : IRequest<ResponseModelPagination<GetAllCustomersResponse>>
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;

}
