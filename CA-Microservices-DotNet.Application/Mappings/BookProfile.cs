using AutoMapper;
using CA_Microservices_DotNet.Common.Models;
using CA_Microservices_DotNet.Domain.Entities;

namespace CA_Microservices_DotNet.Application.Mappings;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookModel>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Reviews.Any() ? src.Reviews.Average(r => r.Stars) : 0.0));

        CreateMap<BookModel, Book>();
    }

}
