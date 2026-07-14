using MediatR;
using MiniStock.Domain;

namespace MiniStock.Application.Products.GetProducts;

public sealed record GetProductsQuery()
    : IRequest<List<Product>>;