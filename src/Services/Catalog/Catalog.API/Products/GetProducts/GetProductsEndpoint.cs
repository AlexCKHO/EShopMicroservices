namespace Catalog.API.Products.GetProducts
{
    //Since we are getting a list of all products and doesn't require any parameter. Thus we don't need any request object 
    //But it is a good practice to put code one in and comment out

    // public record GetProductsRequest();

    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapGet("/products", async (ISender sender) =>
            {

                var result = await sender.Send(new GetProductsQuery());

                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            })
             .WithName("GetProducts")
             .Produces<GetProductsResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Get Products")
             .WithDescription("Get Products")
                ;
        }

    }
}
