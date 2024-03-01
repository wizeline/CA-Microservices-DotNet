using AutoMapper;
using CA_Microservices_DotNet.Common.Models;
using CA_Microservices_DotNet.Domain.Entities;

namespace CA_Microservices_DotNet.Application.Mappings;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<Review, ReviewModel>().ReverseMap();
    }
}
