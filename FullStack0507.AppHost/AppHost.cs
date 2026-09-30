var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.FullStack0507_MyWebApi>("fullstack0507-mywebapi");

builder.Build().Run();
