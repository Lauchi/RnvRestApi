using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var parsedStation = (await stationMapper.MapToStation(new RnvResponse(httpResponseMessage))).SingleOrDefault();

            StationDto expectedStation = new StationDto(new StationId("de:08222:2417"), "Mannheim, Hauptbahnhof",
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

            parsedStation.Count().Should().Be(2);
        }

        private string SuccessContent => File.ReadAllText("RnvAdapter/Mapper/Responses/SuccesResponse.xml");
        private string SuccessContentMultipleLocations => File.ReadAllText("RnvAdapter/Mapper/Responses/SuccessMultiresponse.xml");
    }
}