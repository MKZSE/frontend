namespace frontendForMasterdev.Models
{
    public class GetLogsModel
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int app_id { get; set; }
        public string message { get; set; }
    }
}