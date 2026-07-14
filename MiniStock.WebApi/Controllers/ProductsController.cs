using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniStock.Application.Products.CreateProduct;
using MiniStock.Application.Products.DecreaseStock;
using MiniStock.Application.Products.GetProducts;

namespace MiniStock.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    // MediatR kuryemizi içeri alıyoruz
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST /api/products (Yeni Ürün Ekleme)
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductCommand command)
    {
        // Gelen isteği doğrudan MediatR'a veriyoruz, o ilgili Handler'ı bulup çalıştıracak
        await _mediator.Send(command);
        return Ok("Ürün başarıyla eklendi.");
    }

    // GET /api/products (Tüm Ürünleri Listeleme)
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    // PUT /api/products/{id}/decrease-stock (Stok Düşürme)
    [HttpPut("{id}/decrease-stock")]
    public async Task<IActionResult> DecreaseStock(Guid id, [FromBody] int quantity)
    {
        var command = new DecreaseStockCommand(id, quantity);
        await _mediator.Send(command);
        return Ok("Stok başarıyla düşüldü.");
    }
}