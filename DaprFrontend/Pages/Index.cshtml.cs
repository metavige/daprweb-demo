using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DaprFrontend.Pages;

public class IndexModel : PageModel
{
  private readonly DaprClient _daprClient;

  public IndexModel(DaprClient daprClient)
  {
    _daprClient = daprClient;
  }

  public async Task OnGet()
  {
    var forecasts = await _daprClient.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
      HttpMethod.Get,
      "DaprBackend",
      "weatherforecast");

    ViewData["WeatherForecastData"] = forecasts;
  }
}