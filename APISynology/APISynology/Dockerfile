#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 2626

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./APISynology.csproj", "APISynology/"]
WORKDIR "/src/APISynology"
RUN dotnet restore "./APISynology.csproj"
COPY . .
RUN dotnet build "APISynology.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APISynology.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "APISynology.dll"]