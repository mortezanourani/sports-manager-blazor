using Infrastructure.Models;

namespace CityApp.Data;

public static class Statics
{
    public static Dictionary<int, string> Genders { get; } = new Dictionary<int, string>
    {
        { 0, "زن" },
        { 1, "مرد" }
    };

    public static Dictionary<int, string> UsersGenders { get; } = new Dictionary<int, string>
    {
        { 0, "آقایان" },
        { 1, "بانوان" },
        { 2, "مشترک" }
    };

    public static Dictionary<int, string> FacilityTypes { get; } = new Dictionary<int, string>
    {
        { 0, "دفتر باشگاه" },
        { 1, "روباز" },
        { 2, "سرپوشیده" }
    };
}
