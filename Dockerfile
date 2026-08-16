FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ApiCotacoes.csproj", "."]
RUN dotnet restore

COPY . .
RUN dotnet publish ApiCotacoes.csproj -c Release -o /app/publish /p:UseAppHost=false && ls -la /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "ApiCotacoes.dll"]
