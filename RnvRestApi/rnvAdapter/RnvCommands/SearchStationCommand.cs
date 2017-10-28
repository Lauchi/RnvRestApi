namespace RnvRestApi.rnvAdapter
{
    internal class SearchStationCommand : IRnvCommand
    {
        private readonly string _stationName;

        public SearchStationCommand(string stationName)
        {
            _stationName = stationName;
        }

        public string GetXmlRepresentation()
        {
            return $@"<?xml version=""1.0"" encoding=""iso-8859-1"" ?>
                    <Trias xmlns=""trias"" xmlns:siri=""http://www.siri.org.uk/siri"" version=""1.0"">
                    <ServiceRequest>
                        <siri:RequestTimestamp>2017-10-24T13:42:55</siri:RequestTimestamp>
                        <siri:RequestorRef>PC-HEISS</siri:RequestorRef>
                        <RequestPayload>
                            <LocationInformationRequest>
                            <InitialInput>
                                <LocationName>{_stationName}</LocationName>
                            </InitialInput>
                            </LocationInformationRequest>
                        </RequestPayload>
                    </ServiceRequest>
                    </Trias>";
        }
    }
}