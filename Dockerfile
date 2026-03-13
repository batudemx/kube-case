
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS multistage
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o paket


FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=multistage /app/paket .
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "task1.dll"]