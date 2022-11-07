using System;
using System.Linq;
using BLeader.Services;
using BLeader.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IProductRepository = DAL.Repositories.Interfaces.IProductRepository;

namespace BLeader.Controllers
{
    public class TrialController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IProductRepository _productRepository;

        public TrialController(
            IMailService mailService,
            IProductRepository productRepository)
        {
            _mailService = mailService;
            _productRepository = productRepository;
        }

    public IActionResult Index()
    {
        //throw new InvalidProgramException();
        var products = _productRepository.GetAllProducts();
        return View();
        //return "strsdsdsd";
    }

    public IActionResult About()
    {
        //throw new InvalidProgramException();
        ViewBag.Title = "About us";
        return View();
        //return "strsdsdsd";
    }

    [HttpGet("Contact")]
    public IActionResult Contact()
    {
        //throw new InvalidProgramException();
        ViewBag.Title = "Contact us";

        return View();
        //return "strsdsdsd";
    }



    [HttpPost("Contact")]
    //public IActionResult Contact(object model)
    public IActionResult Contact(ContactViewModel model)
    {
        //throw new InvalidProgramException();
        ViewBag.Title = "Contact us";
        if (ModelState.IsValid)
        {
            _mailService.SomteTestMethod();
            ViewBag.UserMessage = "mail was sent";
            ModelState.Clear();
        }
        return View();
        //return "strsdsdsd";
    }

    public IActionResult Shop()
    {
        var results = _productRepository.GetAllProducts();

            return View(results.ToList());
    }
}
}
