using Infrastructure.Models;

namespace ProvinceApp.Models;

public class Population : BasePopulation
{
    public int CityId { get; set; }
    public virtual City City { get; set; } = null!;
}
