using Microsoft.AspNetCore.Mvc;

namespace P235AllupDb.ViewComponents
{
    public class FeatureViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
