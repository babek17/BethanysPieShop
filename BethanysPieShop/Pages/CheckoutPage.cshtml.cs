using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BethanysPieShop.Pages;

public class CheckoutPage : PageModel
{
    private readonly IShoppingCart _shoppingCart;
    private readonly IOrderRepository _orderRepository;
    
    [BindProperty]
    public Order Order { get; set; }
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        if (_shoppingCart.ShoppingCartItems.Count == 0)
        {
            ModelState.AddModelError("", "Please add at least one pie");
        }

        if (ModelState.IsValid)
        {
            _orderRepository.CreateOrder(Order);
            _shoppingCart.ClearCart();
            return RedirectToPage("CheckoutCompletePage");
        }
        return Page();
    }
}