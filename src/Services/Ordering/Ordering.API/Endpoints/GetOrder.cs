using BuildingBlocks.Pagination;
using Microsoft.AspNetCore.Routing;
using Ordering.Application.Orders.Queries.GetOrders;
using System.Text.RegularExpressions;

namespace Ordering.API.Endpoints;

//- Accepts pagination parameters.
//- Constructs a GetOrdersQuery with these parameters.
//- Retrieves the data and returns it in a paginated format.

//public record GetOrdersRequest(PaginationRequest PaginationRequest);
public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);

public class GetOrders : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        //   What is this
        //   [AsParameters] is basically saying to ASP.NET:
        //   “Take all the individual query(or route / body) parameters that match the properties 
        //   inside PaginationRequest, and automatically populate that object for me.”

        app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersQuery(request));

            var response = result.Adapt<GetOrdersResponse>();

            return Results.Ok(response);
        })
        .WithName("GetOrders")
        .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Orders")
        .WithDescription("Get Orders");
    }
}