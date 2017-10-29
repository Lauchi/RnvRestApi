namespace SqliteAdapter
{
    public class PoliceOfficerDb
    {
        public string PoliceOfficerId { get; set; }
        public string Name { get; set; }

        public string GameSessionId { get; set; }
        public GameSessionDb GameSessionDb { get; set; }
        public string TicketPoolId { get; set; }
        public TicketPoolDb TicketPoolDb { get; set; }
    }
}