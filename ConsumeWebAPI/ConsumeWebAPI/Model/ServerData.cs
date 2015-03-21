namespace ConsumeWebAPI.Model
{
    public class ServerData
    {
        public int Id { get; set; }
        public string InitialDate { get; set; }
        public string EndDate { get; set; }
        public int OrderNumber { get; set; }
        public bool IsDirty { get; set; }
        public string IP { get; set; }
        public int Type { get; set; }
        public int RecordIdentifier { get; set; }
    }
}