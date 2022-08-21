using System.Collections.Generic;

namespace FIS.ViewModels
{
    public class AircraftListViewModel
    {
        public string Query { get; set; }
        public List<AircraftItem> Aircrafts { get; set; }

        public class AircraftItem
        {
            public int Id { get; set; }
            public string Registration { get; set; }
            public string Type { get; set; }
            public int YConfig { get; set; }
            public int JConfig { get; set; }
            public int FConfig { get; set; }
        }
    }
}
