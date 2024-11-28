using System.Diagnostics.CodeAnalysis;
using AmlApi.DataAccess.Entities;
using AmlApi.Resources;
using AutoMapper;

namespace AmlApi.Mapper;

[ExcludeFromCodeCoverage]
public class InventoryMediaProfile : Profile
{
    public InventoryMediaProfile()
    {
        CreateMap<Inventory, MediaResource>()
            .ForMember(destination => destination.MediaType,
                opt => opt.MapFrom(x => x.MediaType.Name))
            .ForMember(destination => destination.BranchName,
                opt => opt.MapFrom(x => x.Branch.Name))
            .ForMember(destination => destination.Available,
                opt => opt.MapFrom(x => x.StockLevel > 0));

        CreateMap<MediaType, MediaTypeResource>();

        CreateMap<Branch, BranchResource>();
    }
}