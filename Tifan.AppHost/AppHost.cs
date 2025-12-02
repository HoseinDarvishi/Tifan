var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Tifan_Product>("tifan-product");

builder.AddProject<Projects.Tifan_Basket>("tifan-basket");

builder.AddProject<Projects.Tifan_Discount>("tifan-discount");

builder.AddProject<Projects.Tifan_Order>("tifan-order");

builder.Build().Run();
