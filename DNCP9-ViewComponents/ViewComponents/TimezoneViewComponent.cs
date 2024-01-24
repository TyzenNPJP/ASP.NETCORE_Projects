using Microsoft.AspNetCore.Mvc;

namespace DNCP9_ViewComponents.ViewComponents
{
    public class TimezoneViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ProfileCard");
        }
    }
}
