using MediatR;
using NoferApi.Shared;

namespace NoferApi.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
