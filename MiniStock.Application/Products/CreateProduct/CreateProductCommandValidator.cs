using FluentValidation;

namespace MiniStock.Application.Products.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz.")
                            .Length(2, 100).WithMessage("İsim 2-100 karakter arası olmalı.");
        RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalı.");
        RuleFor(x => x.StockQuantity).GreaterThanOrEqualTo(0).WithMessage("Stok miktarı negatif olamaz.");
    }
}