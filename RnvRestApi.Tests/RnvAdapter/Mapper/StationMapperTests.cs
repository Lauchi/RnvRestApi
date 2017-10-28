using System.IO;
using System.Net.Http;
using RnvRestApi.DomainDtos;
using RnvRestApi.RnvAdapter;
using RnvRestApi.RnvAdapter.Mapper;
using Xunit;

namespace RnvRestApi.Tests.RnvAdapter.Mapper
{
    public class StationMapperTests
    {
        [Fact]
        public void MapToStation_HappyPath()
        {
            var stationMapper = new StationMapper();
            var httpResponseMessage = new HttpResponseMessage();
            httpResponseMessage.Content = new StringContent(SuccessContent);
            var mapToStation = stationMapper.MapToStation(new RnvResponse(httpResponseMessage));

            StationDto successExpected = new StationDto()
            {
                StationId = new StationId("de:8222000:18"),
                GeoLocation = new GeoLocation(8.46994, 49.47975),
                Name = "Mannheim, Hauptbahnhof"
            };

            Assert.Equal(successExpected, mapToStation);
        }

        private string SuccessContent => File.ReadAllText("RnvRestApi.Tests/RnvAdapter/Mapper/Responses/SuccesResponse.xml");
    }
}