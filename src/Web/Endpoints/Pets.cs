public  class PetsModule: IEndpoint {
    public string name { get; } = "/pets";
    public  void RegisterEndpoints(IEndpointRouteBuilder app) {
        app.MapGet("", () => {});
    }

    
}
