using DragonCity.Models;
namespace DragonCity.Services;
public interface IDragonService

{
    List<dragoes> GetDragao();
    List<Tipo> GetTipos();
    dragoes GetDragoes(int Numero);
    DragonCityDto GetDragonCityDto();
    public DetailsDto GetDetailedDragoes(int Numero)
{
    var dragao = GetDragao();
    var drag = new DetailsDto()
    {
        Current = dragao.Where(p => p.Numero == Numero)
            .FirstOrDefault(),
        Prior = dragao.OrderByDescending(p => p.Numero)
            .FirstOrDefault(p => p.Numero < Numero),
        Next = dragao.OrderBy(p => p.Numero)
            .FirstOrDefault(p => p.Numero > Numero),
    };
    return drag;
}

    Tipo GetTipo(string Nome);
}




