# Use the .NET SDK image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["ConstructionManagementAssistant.sln", "./"]
COPY ["src/CostructionManagementAssistant_API/ConstructionManagementAssistant.API.csproj", "src/CostructionManagementAssistant_API/"]
COPY ["src/ConstructionManagementAssistant_Core/ConstructionManagementAssistant.Core.csproj", "src/ConstructionManagementAssistant_Core/"]
COPY ["src/ConstructionManagementAssistant_EF/ConstructionManagementAssistant.EF.csproj", "src/ConstructionManagementAssistant_EF/"]

# Restore NuGet packages
RUN dotnet restore

# Copy the rest of the source code
COPY . .

# Build the application
RUN dotnet build -c Release --no-restore

# Publish the application
RUN dotnet publish "src/CostructionManagementAssistant_API/ConstructionManagementAssistant.API.csproj" -c Release -o /app/publish --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
EXPOSE 443

# Set ASP.NET Core environment
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "ConstructionManagementAssistant.API.dll"] 