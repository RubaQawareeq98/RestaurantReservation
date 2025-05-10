using AutoMapper;
using RestaurantReservation.API.Models.Tables;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class TableProfile : Profile
{
    public TableProfile()
    {
        CreateMap<Table, TableResponseDto>();
        CreateMap<TableRequestBodyDto, Table>();
    }
}
