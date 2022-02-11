#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Tranzact.TopProgrammingLanguage.App/Tranzact.TopProgrammingLanguage.App.csproj", "Tranzact.TopProgrammingLanguage.App/"]
COPY ["Tranzact.TopProgrammingLanguage.Contracts/Tranzact.TopProgrammingLanguage.Contracts.csproj", "Tranzact.TopProgrammingLanguage.Contracts/"]
COPY ["Tranzact.TopProgrammingLanguage.Infrastructure/Tranzact.TopProgrammingLanguage.Infrastructure.csproj", "Tranzact.TopProgrammingLanguage.Infrastructure/"]
COPY ["Tranzact.TopProgrammingLanguage.Core/Tranzact.TopProgrammingLanguage.Core.csproj", "Tranzact.TopProgrammingLanguage.Core/"]
RUN dotnet restore "Tranzact.TopProgrammingLanguage.App/Tranzact.TopProgrammingLanguage.App.csproj"
COPY . .
WORKDIR "/src/Tranzact.TopProgrammingLanguage.App"
RUN dotnet build "Tranzact.TopProgrammingLanguage.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tranzact.TopProgrammingLanguage.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tranzact.TopProgrammingLanguage.App.dll java php"]