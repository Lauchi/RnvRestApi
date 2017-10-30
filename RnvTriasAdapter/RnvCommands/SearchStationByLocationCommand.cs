using RnvTriasAdapter.DomainDtos;

namespace RnvTriasAdapter.RnvCommands
{
    internal class SearchStationByLocationCommand : RnvCommand
    {
        private readonly GeoLocationDto _geoLocation;

        public SearchStationByLocationCommand(GeoLocationDto geoLocation)
        {
            _geoLocation = geoLocation;
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
                                            <Radius>10</Radius>
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