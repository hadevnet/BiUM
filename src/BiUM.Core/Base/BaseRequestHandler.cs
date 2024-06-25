using MediatR;

namespace BiUM.Core.Base;

public interface IBaseRequestHandler<TRequest>
{
}

public interface IBaseRequestHandler<TRequest, TType> : IBaseRequestHandler<TRequest>
{
}

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, ApiEmptyResponse>, IBaseRequestHandler<TCommand>
    where TCommand : IRequest<ApiEmptyResponse>
{
    new Task<ApiEmptyResponse> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface IQueryHandler<TQuery, TType> : IRequestHandler<TQuery, ApiResponse<TType>>, IBaseRequestHandler<TQuery, TType>
    where TQuery : IRequest<ApiResponse<TType>>
{
    new Task<ApiResponse<TType>> Handle(TQuery query, CancellationToken cancellationToken);
}