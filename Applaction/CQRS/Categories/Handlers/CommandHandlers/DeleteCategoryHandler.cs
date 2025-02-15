using Applaction.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responses;
using Common.GlobalResponses.Generics;
using Domain.Entites;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Categories.Handlers.CommandHandlers;

public class DeleteCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryRequest, ResponseModel<DeleteCategoryResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<ResponseModel<DeleteCategoryResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CategoryRepository.Remove(request.Id, 0);
        return new ResponseModel<DeleteCategoryResponse>
        {
            Data = new DeleteCategoryResponse { Message = "Deleted Successfully!" },
            Errors = [],
            IsSuccess = true
        };
    }
}

