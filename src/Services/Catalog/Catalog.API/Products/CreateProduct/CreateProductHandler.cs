// Encapsulates the business logic

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

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }

}




internal class CreateProductCommandHandler(IDocumentSession session)
    //, ILogger<CreateProductCommandHandler> logger)
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

        //logger.LogInformation("CreateProductCommandHandler.Handle called with {@command}", command);

        var product = new Product
        {

            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };

        //save to db
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //return result

        return new CreateProductResult(product.Id);
        
    }
} 
 