using System.Collections.Generic;

namespace Ipcam.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Tariff> Tariffs { get; set; }
        public IEnumerable<Resolution> Resolutions { get; set; }
        public IEnumerable<Period> Periods { get; set; }
    }
}
