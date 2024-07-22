public interface IEndpoint {
    string name  {get;}
    void RegisterEndpoints(IEndpointRouteBuilder app);
}
