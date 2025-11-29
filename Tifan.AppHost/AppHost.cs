var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Tifan_Product>("tifan-product");

builder.AddProject<Projects.Tifan_Basket>("tifan-basket");

builder.Build().Run();
