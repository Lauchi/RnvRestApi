using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
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
            var mapToStation = await stationMapper.MapToStation(new RnvResponse(httpResponseMessage));

            StationDto successExpected = new StationDto(new StationId("de:8222000:18"), "Mannheim, Hauptbahnhof",
                new GeoLocation(8.46994, 49.47975));

            Assert.Equal(successExpected, mapToStation);
        }

        private string SuccessContent => File.ReadAllText("RnvAdapter/Mapper/Responses/SuccesResponse.xml");
    }
}