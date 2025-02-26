using frontendForMasterdev.Models;

namespace frontendForMasterDev.Models
{
    public class MultiModelViewModel
    {
        public List<GetAppModel>? Apps { get; set; }
        public List<GetLogsModel>? Logs { get; set; }
        public List<GetUpdate>? Updates { get; set; }

        public String UpdatesEnabled { get; set; }
    }
}
