FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /app
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebApi/Api/*.csproj ./WebApi/Api/
COPY WebApi/Contracts/*.csproj ./WebApi/Contracts/
COPY WebApi/Entities/*.csproj ./WebApi/Entities/
COPY WebApi/Extensions/*.csproj ./WebApi/Extensions/
COPY WebApi/Generics/*.csproj ./WebApi/Generics/
COPY WebApi/Infrastructure/*.csproj ./WebApi/Infrastructure/
COPY WebApi/Repositories/*.csproj ./WebApi/Repositories/
COPY WebApi/Services/*.csproj ./WebApi/Services/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY WebApi/Api/. ./WebApi/Api/
COPY WebApi/Contracts/. ./WebApi/Contracts/
COPY WebApi/Entities/. ./WebApi/Entities/
COPY WebApi/Extensions/. ./WebApi/Extensions/
COPY WebApi/Generics/. ./WebApi/Generics/
COPY WebApi/Infrastructure/. ./WebApi/Infrastructure/
COPY WebApi/Repositories/. ./WebApi/Repositories/
COPY WebApi/Services/. ./WebApi/Services/
#
WORKDIR /app/
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app/ 

#
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Api.dll"]

# docker build -f .\WebApi\Api\Dockerfile -t teste .
# https://medium.com/@oluwabukunmi.aluko/dockerize-asp-net-core-web-app-with-multiple-layers-projects-part1-2256aa1b0511
