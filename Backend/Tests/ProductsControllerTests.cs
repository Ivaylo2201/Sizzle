using System.Collections;
using Backend.Controllers;
using Backend.Database.Entities;
using Backend.Database;
using Backend.DTOs.Product;
using Backend.Mappers;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests;

public class ProductsControllerTests
{
    private static readonly List<Product> Products = Data.Products[..2];
    private static readonly Mock<IProductRepository> MockRepo = new();
    private static readonly ProductsController Controller = new(MockRepo.Object);
    
    [Fact]
    public async Task GetAllProductsAsync_ReturnsListOfProductShortDtos_WhenThereAreProducts()
    {
        var productShortDtos = Products.Select(p => p.ToShortDto()).ToList();
        MockRepo.Setup(r => r.GetAllProductsAsync()).ReturnsAsync(productShortDtos);
        
        var response = await Controller.GetAllProductsAsync();
        
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Equivalent(productShortDtos, okResult.Value);
    }
    
    [Fact]
    public async Task GetAllProductsAsync_ReturnsEmptyList_WhenThereAreNoProducts()
    {
        MockRepo.Setup(r => r.GetAllProductsAsync()).ReturnsAsync([]);
        
        var response = await Controller.GetAllProductsAsync();
        
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Empty((okResult.Value as IEnumerable)!);
    }
    
    [Fact]
    public async Task GetProductByIdAsync_ReturnsProductLongDto_WhenProductExists()
    {
        MockRepo.Setup(r => r.GetProductByIdAsync(1)).ReturnsAsync(Products[0].ToLongDto());
        
        var response = await Controller.GetProductByIdAsync(1);
        
        var okResult = Assert.IsType<OkObjectResult>(response);
        Assert.Equivalent(Products[0].ToLongDto(), okResult.Value);
    }

    [Fact]
    public async Task GetProductByIdAsync_ReturnsNotFound_WhenProductDoesNotExist()
    {
        MockRepo.Setup(r => r.GetProductByIdAsync(-1)).ReturnsAsync((ProductLongDto?) null);
        
        var response = await Controller.GetProductByIdAsync(-1);
        
        var notFoundResult = Assert.IsType<NotFoundObjectResult>(response);
        Assert.Equivalent(
            new { message = "The requested product resource was not found on the server." },
            notFoundResult.Value);
    }
}