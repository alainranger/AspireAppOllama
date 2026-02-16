var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireAppOllama_ApiService>("apiservice")
	.WithHttpHealthCheck("/health");

builder.AddProject<Projects.AspireAppOllama_Web>("webfrontend")
	.WithExternalHttpEndpoints()
	.WithHttpHealthCheck("/health")
	.WithReference(apiService)
	.WaitFor(apiService);

await builder.Build().RunAsync();
