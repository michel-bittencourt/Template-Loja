using AutoMapper;
using Loja.Application.DTO;
using Loja.Domain.Entities;

namespace Loja.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<ProductEntity, ProductDTO>().ReverseMap();
        CreateMap<InventoryEntity, InventoryDTO>().ReverseMap();
    }
}
