FROM node:20-alpine AS react-build
WORKDIR /app
COPY react-mindmap-app/package*.json ./
RUN npm install
COPY react-mindmap-app ./
ENV NODE_OPTIONS=--openssl-legacy-provider
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BacPeBune.csproj", "."]

RUN grep -q "Microsoft.EntityFrameworkCore" BacPeBune.csproj || dotnet add package Microsoft.EntityFrameworkCore
RUN grep -q "Microsoft.EntityFrameworkCore.SqlServer" BacPeBune.csproj || dotnet add package Microsoft.EntityFrameworkCore.SqlServer
RUN grep -q "Microsoft.EntityFrameworkCore.Tools" BacPeBune.csproj || dotnet add package Microsoft.EntityFrameworkCore.Tools

RUN dotnet restore "./BacPeBune.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./BacPeBune.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BacPeBune.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false
COPY --from=react-build /app/build/ /app/publish/wwwroot/react-mindmap-app/

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BacPeBune.dll"]