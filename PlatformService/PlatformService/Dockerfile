FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy all csproj to current (app)
# The same as COPY PlatformService.csproj ./
COPY *.csproj ./
RUN dotnet restore

# Copy all to current
COPY . ./

# Run publish to build runtime version of app
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build-env
WORKDIR /app
# Copy all builded files to current (app)
COPY --from=build-env /app/out .

# Is responsible for what we want to run
ENTRYPOINT ["dotnet", "PlatformService.dll"] 
