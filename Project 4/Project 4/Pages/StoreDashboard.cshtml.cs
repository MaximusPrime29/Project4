using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SupermarketInventory.Pages
{
    public class StoreDashboardModel : PageModel
    {


        private readonly TransferService _transferService;

        public StoreDashboardModel(TransferService transferService)
        {
            _transferService = transferService;
        }

        [BindProperty(SupportsGet = true)]
        public string Store { get; set; } = "willow";

        public string StoreName { get; set; } = "";
        public string StoreLocation { get; set; } = "";
        public string StoreIcon { get; set; } = "";

        public int TotalUnits { get; set; }
        public int Alerts { get; set; }
        public string StockValue { get; set; } = "";

        public void OnGet()
        {
            switch (Store.ToLower())
            {
                case "harbor":
                    StoreName = "Harbor Point Grocer";
                    StoreLocation = "Marina District · 88 Pier Ave";
                    StoreIcon = "⚓";
                    TotalUnits = 508;
                    Alerts = 4;
                    StockValue = "$1,639";
                    break;

                case "summit":
                    StoreName = "Summit Hill Provisions";
                    StoreLocation = "Uptown · 451 Ridge Rd";
                    StoreIcon = "⛰️";
                    TotalUnits = 252;
                    Alerts = 8;
                    StockValue = "$813";
                    break;

                default:
                    StoreName = "Willow Creek Market";
                    StoreLocation = "Downtown · 1200 Elm St";
                    StoreIcon = "🌿";
                    TotalUnits = 365;
                    Alerts = 5;
                    StockValue = "$1,177";
                    break;
            }
        }
        public IActionResult OnPostTransfer(TransferRequest request)
        {
            string result = _transferService.TransferStock(request);

            TempData["Message"] = result;

            return RedirectToPage();
        }
    }
}