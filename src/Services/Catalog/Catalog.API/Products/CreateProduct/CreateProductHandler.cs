// Encapsulates the business logic

using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

// Data that needed to create a new product
// record is just a special kind of class introduced in C# 9 that is designed for immutable data and value-based equality.
public record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price
) : ICommand<CreateProductResult>;

// Response result object in this case we only return the ID
// Once successfully create product, then return that product ID
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command,
        CancellationToken cancellationToken
    )
    {
        //Create product entity from command object
        //Save to database
        // return CreateProdutResult result

        var product = new Product
        {

            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        //save to db


        //return result

        return new CreateProductResult(Guid.NewGuid());
        
    }
} 
 