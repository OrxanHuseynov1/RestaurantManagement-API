﻿using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Customer.Commands.Requests;

public record struct UpdateCustomerRequest : IRequest<ResponseModel<UpdateCustomerResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

}
