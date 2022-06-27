using FluentAssertions;
using Kata_SonarCloud_Pipelines;
using Kata_SonarCloud_Pipelines.Controllers;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorld.Tests;

public class WeatherForecastTest : TestBase
{
    [Fact]
    public async Task GetReturnsCorrectInformation()
    {
        var response = await Server.CreateHttpApiRequest<WeatherForecastController>(c => c.Get()).GetAsync();

        response.IsSuccessStatusCode.Should().BeTrue();
        JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(await response.Content.ReadAsStringAsync())
            .Should().OnlyHaveUniqueItems().And.HaveCount(5);
    }
}