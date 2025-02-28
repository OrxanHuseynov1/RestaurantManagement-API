using Applaction.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responses;
using AutoMapper;
using Domain.Entites;

namespace Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, GetByIdDto>().ReverseMap();
        CreateMap<Command, User>().ReverseMap();
        CreateMap<User, RegisterDto>().ReverseMap();
        CreateMap<User, UpdateDto>().ReverseMap();


        CreateMap<Product, CreateProductRequest>().ReverseMap();
        CreateMap<CreateProductResponse, Product>().ReverseMap();
        CreateMap<Product, GetAllProductsResponse>().ReverseMap();
        CreateMap<Product, GetProductByIdResponse>().ReverseMap();
        CreateMap<UpdateProductRequest, Product>().ReverseMap();
        CreateMap<Product, UpdateProductResponse>().ReverseMap();

        CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        CreateMap<CreateCategoryResponse, Category>().ReverseMap();
        CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
        CreateMap<Category, UpdateCategoryResponse>().ReverseMap();

        CreateMap<Customer, GetAllCustomersResponse>().ReverseMap();
        CreateMap<CreateCustomerRequest, Customer>().ReverseMap();
        CreateMap<Customer, CreateCustomerResponse>().ReverseMap();
        CreateMap<Customer, GetCustomerByIdResponse>().ReverseMap();
        CreateMap<UpdateCustomerRequest, Customer>().ReverseMap();
        CreateMap<Customer, UpdateCustomerResponse>().ReverseMap();
    }
}
