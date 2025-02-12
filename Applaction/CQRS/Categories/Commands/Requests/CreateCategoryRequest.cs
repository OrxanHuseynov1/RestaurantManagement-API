using Application.CQRS.Categories.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Applaction.CQRS.Categories.Commands.Requests;

public class CreateCategoryRequest : IRequest<ResponseModel<CreateCategoryResponse>>
{
    public string? Name { get; set; }
}
