#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 7272

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Portfol.io.WebAPI/Portfol.io.WebAPI.csproj", "Portfol.io.WebAPI/"]
COPY ["Portfol.io.Persistence/Portfol.io.Persistence.csproj", "Portfol.io.Persistence/"]
COPY ["Portfol.io.Application/Portfol.io.Application.csproj", "Portfol.io.Application/"]
COPY ["Portfol.io.Domain/Portfol.io.Domain.csproj", "Portfol.io.Domain/"]
RUN dotnet restore "Portfol.io.WebAPI/Portfol.io.WebAPI.csproj"
COPY . .
WORKDIR "/src/Portfol.io.WebAPI"
RUN dotnet build "Portfol.io.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Portfol.io.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Portfol.io.WebAPI.dll"]