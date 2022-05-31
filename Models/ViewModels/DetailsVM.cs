namespace Ipcam.Models.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            Tariff = new Tariff();
        }
        public Tariff Tariff { get; set; }
        public bool ExistsInCart { get; set; }
    }
}
