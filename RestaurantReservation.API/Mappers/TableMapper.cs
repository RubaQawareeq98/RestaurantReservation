using RestaurantReservation.API.Models.Tables;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class TableMapper
{
    public partial Table ToTable(TableRequestBodyDto tableRequestBodyDto);
    public partial TableResponseDto ToTableResponseDto(Table table);
    public partial List<TableResponseDto> ToTableResponseDtoList(List<Table> tables);
}