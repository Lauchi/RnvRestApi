using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using RnvRestApi.DomainDtos;
using RnvRestApi.RnvAdapter;
using RnvRestApi.RnvAdapter.Mapper;
using Xunit;

namespace RnvRestApi.Tests.RnvAdapter.Mapper
{
    public class StationMapperTests
    {
        [Fact]
        public async Task MapToStation_HappyPath()
        {
            var stationMapper = new StationMapper();
            var httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StringContent(SuccessContent);
            var parsedStation = await stationMapper.MapToStation(new RnvResponse(httpResponseMessage));

            StationDto expectedStation = new StationDto(new StationId("de:08222:2417"), "Mannheim, Hauptbahnhof",
                new GeoLocation(8.46994, 49.47975));

            expectedStation.Should().BeEquivalentTo(parsedStation);
        }

        private string SuccessContent => File.ReadAllText("RnvAdapter/Mapper/Responses/SuccesResponse.xml");
    }
}