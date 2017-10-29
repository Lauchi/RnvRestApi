using Domain.ValueTypes.Ids;

namespace RnvTriasAdapter.RnvCommands
{
    public class GetStationCommand : RnvCommand
    {
        private readonly StationId _stationId;

        public GetStationCommand(StationId stationId)
        {
            _stationId = stationId;
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
									<LocationRef>
										<StopPointRef>{_stationId.Id}</StopPointRef>
										<LocationName>
											<Text></Text>
										</LocationName>
									</LocationRef>
								</InitialInput>
								</LocationInformationRequest>
							</RequestPayload>
						</ServiceRequest>
						</Trias>";
        }
    }
}