using Application.CQRS.Categories.Commands.Responses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Categories.Commands.Requests;

public class DeleteCategoryRequest : IRequest<ResponseModel<DeleteCategoryResponse>>
{
    public int Id { get; set; }
    public int DeletedBy { get; set; }
}
