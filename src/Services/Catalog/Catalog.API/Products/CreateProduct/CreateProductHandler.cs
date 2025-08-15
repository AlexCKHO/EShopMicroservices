// Encapsulates the business logic

using MediatR;

namespace Catalog.API.Products.CreateProduct;

// Data that needed to create a new product
// record is just a special kind of class introduced in C# 9 that is designed for immutable data and value-based equality.
public record CreateProductCommand(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
) : IRequest<CreateProductResult>;

// Response result object in this case we only return the ID
// Once successfully create product, then return that product ID
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(
        CreateProductCommand request,
        CancellationToken cancellationToken
    )
    {
        // Business logic to create a product
        return Task.FromResult(new CreateProductResult(request.Id));
    }
} 
