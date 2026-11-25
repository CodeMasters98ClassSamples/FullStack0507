# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["FullStack0507.MyWebApi/FullStack0507.MyWebApi.csproj", "FullStack0507.MyWebApi/"]
COPY ["FullStack0507.MyApplication/FullStack0507.MyApplication.csproj", "FullStack0507.MyApplication/"]
COPY ["FullStack0507.MyDomain/FullStack0507.MyDomain.csproj", "FullStack0507.MyDomain/"]
COPY ["FullStack0507.MyInfrastructure/FullStack0507.MyInfrastructure.csproj", "FullStack0507.MyInfrastructure/"]
COPY ["FullStack0507.MySharedPresentation/FullStack0507.MySharedPresentation.csproj", "FullStack0507.MySharedPresentation/"]
COPY ["FullStack0507.MySharedApplication/FullStack0507.MySharedApplication.csproj", "FullStack0507.MySharedApplication/"]
COPY ["FullStack0507.ServiceDefaults/FullStack0507.ServiceDefaults.csproj", "FullStack0507.ServiceDefaults/"]
RUN dotnet restore "./FullStack0507.MyWebApi/FullStack0507.MyWebApi.csproj"
COPY . .
WORKDIR "/src/FullStack0507.MyWebApi"
RUN dotnet build "./FullStack0507.MyWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FullStack0507.MyWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FullStack0507.MyWebApi.dll"]