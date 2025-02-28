using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Categories.Commands.Requests;

public record struct UpdateCategoryRequest : IRequest<ResponseModel<UpdateCategoryResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
