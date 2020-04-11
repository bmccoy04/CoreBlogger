FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY . ./

WORKDIR /app/CoreBlogger.Site
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 As runtime
WORKDIR /app
COPY --from=build /app/CoreBlogger.Site/out ./

ENTRYPOINT ["dotnet", "CoreBlogger.Site.dll"]