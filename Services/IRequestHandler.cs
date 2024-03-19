namespace cqrs_example.Services;
/// <summary>
/// Interface for request handlers without a response
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public interface IRequestHandler<TRequest> where TRequest : class {
    /// <summary>
    /// Executes the request type command
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<bool> Execute(TRequest request);
}

/// <summary>
/// Interface for request handlers with a response
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public interface IRequestHandler<TRequest, TResponse> where TRequest : class where TResponse : class {
    /// <summary>
    /// Executes the request type query
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<TResponse> Execute(TRequest request);
}