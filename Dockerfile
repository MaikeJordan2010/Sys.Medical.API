# Here, we include the dotnet core SDK as the base to build our app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["1 - Apresentacao/Sys.Medical.API/Sys.Medical.API.csproj","1 - Apresentacao/Sys.Medical.API/"]
COPY ["2 - Aplicacao/Sys.Medical.Aplicacao/Sys.Medical.Aplicacao.csproj","2 - Aplicacao/Sys.Medical.Aplicacao/"]
COPY ["3 - Dominio/Sys.Medical.Dominio/Sys.Medical.Dominio.csproj","3 - Dominio/Sys.Medical.Dominio/"]
COPY ["4 - Infraestrutura/Sys.Medical.Repositorio/Sys.Medical.Repositorio.csproj","4 - Infraestrutura/Sys.Medical.Repositorio/"]
RUN dotnet restore "1 - Apresentacao/Sys.Medical.API/Sys.Medical.API.csproj"
COPY . .
WORKDIR /src/1 - Apresentacao/Sys.Medical.API
RUN dotnet build "Sys.Medical.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sys.Medical.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Sys.Medical.API.dll" ]

