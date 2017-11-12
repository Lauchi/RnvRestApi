
using Domain;

namespace RnvTriasAdapter.RnvCommands
{
    internal class SearchStationByLocationCommand : RnvCommand
    {
        private readonly GeoLocation _geoLocation;
        private readonly int _distance;

        public SearchStationByLocationCommand(GeoLocation geoLocation, int distance = 50)
        {
            _geoLocation = geoLocation;
            _distance = distance;
        }

        public override string GetXmlRepresentation()
        {
            var xmlRepresentation = $@"<?xml version=""1.0"" encoding=""iso-8859-1"" ?>
                    <Trias xmlns=""trias"" xmlns:siri=""http://www.siri.org.uk/siri"" version=""1.0"">
                    <ServiceRequest>
                        <siri:RequestTimestamp>{SendTime}</siri:RequestTimestamp>
                        <siri:RequestorRef>{RequestToken}</siri:RequestorRef>
                        <RequestPayload>
                            <LocationInformationRequest>
                                <InitialInput>
                                    <GeoRestriction>
                                        <Circle>
                                            <Center>
                                                <Longitude>{_geoLocation.Longitude}</Longitude>
                                                <Latitude>{_geoLocation.Latitude}</Latitude>
                                            </Center>
                                            <Radius>{_distance}</Radius>
                                        </Circle>
                                    </GeoRestriction>
                                </InitialInput>
                                <Restrictions>
                                    <Type>stop</Type>
                                </Restrictions>
                            </LocationInformationRequest>
                        </RequestPayload>
                    </ServiceRequest>
                    </Trias>";
            return xmlRepresentation;
        }
    }
}