FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY QIQO.Business.Accounts.Api/QIQO.Business.Accounts.Api.csproj QIQO.Business.Accounts.Api/
COPY QIQO.Business.Accounts.Proxies/QIQO.Business.Accounts.Proxies.csproj QIQO.Business.Accounts.Proxies/
COPY QIQO.Business.Accounts.Data/QIQO.Business.Accounts.Data.csproj QIQO.Business.Accounts.Data/
COPY QIQO.Business.Core/QIQO.Business.Core.csproj QIQO.Business.Core/
RUN dotnet restore
COPY . .
WORKDIR /src/QIQO.Business.Accounts.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QIQO.Business.Accounts.Api.dll"]
