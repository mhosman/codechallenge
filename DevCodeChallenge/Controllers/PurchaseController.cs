using DevCodeChallenge.Services;
using System.Web.Mvc;

namespace DevCodeChallenge.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly PurchaseService _purchaseService;

        public PurchaseController() { }

        public PurchaseController(PurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public ActionResult Index()
        {
            var purchases = _purchaseService.GetAllPurchases();
            return View(purchases);
        }

        public ActionResult GetPurchasesJson(bool ascendingOrder = true)
        {
            var purchases = _purchaseService.GetAllPurchases(ascendingOrder);
            return Json(purchases, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPurchasesWithTotalCostGreaterThanJson(decimal totalCost, bool ascendingOrder = true)
        {
            var purchases = _purchaseService.GetPurchasesWithTotalCostGreaterThan(totalCost, ascendingOrder);
            return Json(purchases, JsonRequestBehavior.AllowGet);
        }
    }
}