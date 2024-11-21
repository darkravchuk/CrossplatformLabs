using ClassLibraryLabs.Lab1;
using ClassLibraryLabs.Lab2;
using ClassLibraryLabs.Lab3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[Authorize]
public class LabsController : Controller
{
    [HttpGet]
    public IActionResult ExecuteLab1()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult ExecuteLab1(string inputText)
    {
        Lab1.Execute(inputText, out string outputResult);
        ViewBag.OutputResult = outputResult;
        return View();
    }
    
    [HttpGet]
    public IActionResult ExecuteLab2()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult ExecuteLab2(string inputText)
    {
        Lab2.Execute(inputText, out string outputResult);
        ViewBag.OutputResult = outputResult;
        return View();
    }
    
    [HttpGet]
    public IActionResult ExecuteLab3()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult ExecuteLab3(string inputText)
    {
        Lab3.Execute(inputText, out string outputResult);
        ViewBag.OutputResult = outputResult;
        return View();
    } 
}