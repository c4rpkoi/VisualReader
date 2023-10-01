FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY src/VisualReader.Api/*.csproj         ./src/VisualReader.Api/
COPY src/VisualReader.Application/*.csproj ./src/VisualReader.Application/
COPY src/VisualReader.Domain/*.csproj      ./src/VisualReader.Domain/
COPY src/VisualReader.Persistence/*.csproj ./src/VisualReader.Persistence/
RUN dotnet restore ./src/VisualReader.Api/*.csproj /property:Configuration=Release -nowarn:msb3202,nu1503

COPY src/ ./src
RUN dotnet publish ./src/VisualReader.Api/*.csproj --no-restore -c Release -o /app/out

# Run time image
FROM base AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "VisualReader.Api.dll"]
