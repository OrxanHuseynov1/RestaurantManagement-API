using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Categories.Commands.Responses;

public class CreateCategoryResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
