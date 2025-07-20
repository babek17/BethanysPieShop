 using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BethanysPieShop.Pages;

public class CheckoutCompletePage : PageModel
{
    public void OnGet()
    {
        ViewData["CheckoutCompleteMessage"] = "Thank you for your purchase at Bethany's Pie Shop!";
    }
} 