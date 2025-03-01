using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customer.Commands.Requests;
public record struct CreateCustomerRequest : IRequest<ResponseModel<CreateCustomerResponse>>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
}