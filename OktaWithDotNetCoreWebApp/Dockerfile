FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["OktaWithDotNetCoreWebApp/OktaWithDotNetCoreWebApp.csproj", "OktaWithDotNetCoreWebApp/"]
RUN dotnet restore "OktaWithDotNetCoreWebApp/OktaWithDotNetCoreWebApp.csproj"
COPY . .
WORKDIR "/src/OktaWithDotNetCoreWebApp"
RUN dotnet build "OktaWithDotNetCoreWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OktaWithDotNetCoreWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OktaWithDotNetCoreWebApp.dll"]