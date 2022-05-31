using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Ipcam.Models.ViewModels
{
    public class TariffVM
    {
        public Tariff Tariff { get; set; }
        public IEnumerable<SelectListItem> ResolutionSelectList { get; set; }
        public IEnumerable<SelectListItem> PeriodSelectList { get; set; }
    }
}
