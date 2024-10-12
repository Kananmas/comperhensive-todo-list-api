FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["comperhensive-todo-list-api.csproj", "."]
RUN dotnet restore "comperhensive-todo-list-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "comperhensive-todo-list-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "comperhensive-todo-list-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "comperhensive-todo-list-api.dll"]