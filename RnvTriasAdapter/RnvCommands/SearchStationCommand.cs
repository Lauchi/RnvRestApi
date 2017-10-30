namespace RnvTriasAdapter.RnvCommands
{
    internal class SearchStationCommand : RnvCommand
    {
        private readonly string _stationName;

        public SearchStationCommand(string stationName)
        {
            _stationName = stationName;
        }

        public override string GetXmlRepresentation()
        {
            return $@"<?xml version=""1.0"" encoding=""iso-8859-1"" ?>
                    <Trias xmlns=""trias"" xmlns:siri=""http://www.siri.org.uk/siri"" version=""1.0"">
                    <ServiceRequest>
                        <siri:RequestTimestamp>{SendTime}</siri:RequestTimestamp>
                        <siri:RequestorRef>{RequestToken}</siri:RequestorRef>
                        <RequestPayload>
                            <LocationInformationRequest>
                            <InitialInput>
                                <LocationName>{_stationName}</LocationName>
                            </InitialInput>
                            <Restrictions>
                                <Type>stop</Type>
                            </Restrictions>
                            </LocationInformationRequest>
                        </RequestPayload>
                    </ServiceRequest>
                    </Trias>";
        }
    }
}