#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mandegar.Api.Admin/Mandegar.Api.Admin.csproj", "Mandegar.Api.Admin/"]
RUN dotnet restore "Mandegar.Api.Admin/Mandegar.Api.Admin.csproj"
COPY . .
WORKDIR "/src/Mandegar.Api.Admin"
RUN dotnet build "Mandegar.Api.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mandegar.Api.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mandegar.Api.Admin.dll"]