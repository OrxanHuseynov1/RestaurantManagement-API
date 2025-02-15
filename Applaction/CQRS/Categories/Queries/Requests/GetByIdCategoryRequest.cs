using Application.CQRS.Categories.Queries.Responses;
using Common.GlobalResponses.Generics;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Queries.Requests;

public class GetByIdCategoryRequest : IRequest<ResponseModel<GetByIdCategoryResponse>>
{
    public int Id { get; set; }
}
