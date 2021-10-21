FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DotNet5MvcJwtAuth/DotNet5MvcJwtAuth.csproj", "DotNet5MvcJwtAuth/"]
RUN dotnet restore "DotNet5MvcJwtAuth/DotNet5MvcJwtAuth.csproj"
COPY . .
WORKDIR "/src/DotNet5MvcJwtAuth"
RUN dotnet build "DotNet5MvcJwtAuth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNet5MvcJwtAuth.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet5MvcJwtAuth.dll"]
