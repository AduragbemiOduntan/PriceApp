#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PriceApp-API/PriceApp-API.csproj", "PriceApp-API/"]
COPY ["PriceApp-Application/PriceApp-Application.csproj", "PriceApp-Application/"]
COPY ["PriceApp-Domain/PriceApp-Domain.csproj", "PriceApp-Domain/"]
COPY ["PriceApp-Infrastructure/PriceApp-Infrastructure.csproj", "PriceApp-Infrastructure/"]
COPY ["PriceApp-Shared/PriceApp-Shared.csproj", "PriceApp-Shared/"]
RUN dotnet restore "PriceApp-API/PriceApp-API.csproj"
COPY . .
WORKDIR "/src/PriceApp-API"
RUN dotnet build "PriceApp-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PriceApp-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PriceApp-API.dll"]