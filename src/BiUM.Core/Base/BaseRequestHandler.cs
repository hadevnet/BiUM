using MediatR;

namespace BiUM.Core.Base;

public interface IBaseRequestHandler<TRequest, TType>
{
}

public interface ICommandHandler<TCommand, TType> : IRequestHandler<TCommand, ApiResponse<TType>>, IBaseRequestHandler<TCommand, TType>
    where TCommand : IRequest<ApiResponse<TType>>
{
    new Task<ApiResponse<TType>> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface IQueryHandler<TQuery, TType> : IRequestHandler<TQuery, ApiResponse<TType>>, IBaseRequestHandler<TQuery, TType>
    where TQuery : IRequest<ApiResponse<TType>>
{
    new Task<ApiResponse<TType>> Handle(TQuery query, CancellationToken cancellationToken);
}