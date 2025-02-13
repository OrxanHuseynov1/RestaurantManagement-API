namespace Application.CQRS.Categories.Commands.Responses;

public class DeleteCategoryResponse
{
    public int Id { get; set; }
    public int DeletedBy { get; set; }
}
