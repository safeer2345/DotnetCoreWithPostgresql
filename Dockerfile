# Build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
copy . ./
RUN dotnet restore "./FirstProject.csproj" --disable-parallel
RUN dotnet publish "FirstProject.csproj" -c Release -o /app --no-restore

#Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "FirstProject.dll"]

