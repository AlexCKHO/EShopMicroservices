// Encapsulates the business logic

namespace Catalog.API.Products.CreateProduct;

// Data that needed to create a new product
public record CreateProductCommand(
    Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
);

// Response result object in this case we only return the ID
// Once successfully create product, then return that product ID
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler { }
