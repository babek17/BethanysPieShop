using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class HomeController: Controller
{
    private readonly IPieRepository _pieRepository;

    public HomeController(IPieRepository pieRepository)
    {
        _pieRepository = pieRepository;
    }
    
    
    public IActionResult Index()
    {
        var piesOftheWeek = _pieRepository.PiesOfTheWeek;
        var homeViewModel = new HomeViewModel(piesOftheWeek);
        return View(homeViewModel);
    }
}