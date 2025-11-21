var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Tifan_Product>("tifan-product");

builder.Build().Run();
