var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FullStack0507_MyWebApi>("fullstack0507-mywebapi");

builder.AddProject<Projects.FullStack0507_MyStoreWebApi>("fullstack0507-mystorewebapi");

builder.Build().Run();
