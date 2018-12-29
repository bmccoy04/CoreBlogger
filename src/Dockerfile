FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY . ./

WORKDIR /app/CoreBlogger.Site
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime As runtime
WORKDIR /app
COPY --from=build /app/CoreBlogger.Site/out ./

ENTRYPOINT ["dotnet", "CoreBlogger.Site.dll"]