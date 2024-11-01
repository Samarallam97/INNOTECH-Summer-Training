namespace BootstrapComponents.Pages;

public partial class Weather
{

    public List<Link> NavLinks = new List<Link>
{
    new Link { Text = "Table 1", Url = "/weather/#table1" },
    new Link { Text = "Table 2", Url = "/weather/#table2" },
    new Link { Text = "Table 3", Url = "/weather/#table3" }
};


    public static List<Link> DropdownLinks = new List<Link>
{
    new Link { Text = "Home", Url = "/" },
    new Link { Text = "Counter", Url = "/counter" },
    new Link { Text = "Weather", Url = "/weather" }
};

    public List<Dropdown> Dropdowns = new List<Dropdown>
{
    new Dropdown { Title = "Choose a page" , Links = DropdownLinks}
};


    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }


}