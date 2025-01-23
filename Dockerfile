FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Gorkem_/Gorkem_.csproj", "Gorkem_/"]
RUN dotnet restore "Gorkem_/Gorkem_.csproj"

COPY . .
WORKDIR "/src/Gorkem_"
RUN dotnet build "Gorkem_.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gorkem_.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update && apt-get install -y curl

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

ENTRYPOINT ["dotnet", "Gorkem_.dll"] 