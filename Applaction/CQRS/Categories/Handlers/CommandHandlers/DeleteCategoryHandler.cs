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
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

        if (category == null)
        {
            return new ResponseModel<DeleteCategoryResponse>
            {
                Data = null,
                Errors = ["Daxil Edilen Id-e uygun Categori Tapilmadi "],
                IsSuccess = false,
            };
        }

        await _unitOfWork.CategoryRepository.Remove(category.Id, request.DeletedBy);
        //await _unitOfWork.SaveChangesAsync();

        return new ResponseModel<DeleteCategoryResponse>
        {
            Data = new DeleteCategoryResponse
            {
                Id = category.Id,
                DeletedBy = request.DeletedBy
            },
            Errors = [],
            IsSuccess = true
        };
    }
}

