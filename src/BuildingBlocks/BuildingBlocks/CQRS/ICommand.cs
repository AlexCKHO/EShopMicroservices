using MediatR;

namespace BuildingBlocks.CQRS
{

    //Command with no return type
    internal interface ICommand : ICommand<Unit>
    {
    }

    // With return type
     public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }
}
