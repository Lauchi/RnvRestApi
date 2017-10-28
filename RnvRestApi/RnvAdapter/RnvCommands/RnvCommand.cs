using System;

namespace RnvRestApi.RnvAdapter.RnvCommands
{
    public abstract class RnvCommand
    {
        public RnvCommand()
        {
            SendTime =  DateTimeOffset.Now;
            RequestToken = "PC-HEISS";
        }

        public DateTimeOffset SendTime { get; }
        public string RequestToken { get; }
        public abstract string GetXmlRepresentation();
    }
}