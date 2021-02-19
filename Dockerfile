FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY /FinanceiroCore/*.csproj ./FinanceiroCore/
WORKDIR /app/FinanceiroCore
RUN dotnet restore

# Copy everything else and build
WORKDIR /app
COPY /FinanceiroCore/. ./FinanceiroCore/
WORKDIR /app/FinanceiroCore
RUN dotnet publish -c Release -o out

# Copy csproj and restore as distinct layers
WORKDIR /app
COPY /Api2/*.csproj ./Api2/
WORKDIR /app/Api2
RUN dotnet restore

# Copy everything else and build
WORKDIR /app
COPY /Api2/. ./Api2/
WORKDIR /app/Api2
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app/Api2
COPY --from=build-env /app/Api2/out .
ENTRYPOINT ["dotnet", "Api2.dll"]