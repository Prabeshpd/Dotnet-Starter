public  class PetsModule: IEndpoint {
    public  void RegisterEndpoints(IEndpointRouteBuilder app) {
        app.MapGet("/pets", () => {});
    }
}
