using MediatR;



namespace BuildingBlocks.CQRS
{
    // 1️What is TResponse in IRequest<TResponse>?

    // TResponse is a placeholder for a type — it will be replaced with an
    // actual type when you use the interface.


    // out keyword: Why useful in CQRS/MediatR?
    //Your query handlers often return DTOs or base classes.
    //You might have a variable that expects IQuery<BaseResult>
    //but actually give it IQuery<SpecificResult>.
    //out lets you keep that flexibility.
    public interface IQuery<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {

    }
}
