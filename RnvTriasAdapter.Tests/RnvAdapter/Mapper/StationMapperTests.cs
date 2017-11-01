using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using Domain.ValueTypes.Ids;
using FluentAssertions;
using RnvTriasAdapter.Mapper;
using Xunit;

namespace RnvTriasAdapter.Tests.RnvAdapter.Mapper
{
    public class StationMapperTests
    {
        [Fact]
        public async Task MapToStation_HappyPath()
        {
            var stationMapper = new StationMapper();
            var httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StringContent(SuccessContent);
            var parsedStation = (await stationMapper.MapToStation(new RnvResponse(httpResponseMessage))).SingleOrDefault();

            var expectedStation = new Station(new StationId("de:08222:2417"), "Mannheim, Hauptbahnhof",
                new GeoLocation(8.46994, 49.47975));

            expectedStation.Should().BeEquivalentTo(parsedStation);
        }

        [Fact]
        public async Task MapToStation_MultipleStations()
        {
            var stationMapper = new StationMapper();
            var httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StringContent(SuccessContentMultipleLocations);
            var parsedStation = await stationMapper.MapToStation(new RnvResponse(httpResponseMessage));

            var stationDtos = parsedStation as Station[] ?? parsedStation.ToArray();
            stationDtos.Length.Should().Be(2);
            stationDtos[0].StationId.Id.Should().BeEquivalentTo("de:08222:6004");
            stationDtos[1].StationId.Id.Should().BeEquivalentTo("de:08222:2462");
        }

        private string SuccessContent => File.ReadAllText("RnvAdapter/Mapper/Responses/SuccesResponse.xml");
        private string SuccessContentMultipleLocations => File.ReadAllText("RnvAdapter/Mapper/Responses/SuccessMultiresponse.xml");
    }
}