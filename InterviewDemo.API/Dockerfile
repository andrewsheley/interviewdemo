FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY InterviewDemo.API/InterviewDemo.API.csproj InterviewDemo.API/
COPY InterviewDemo.DataAccess/InterviewDemo.DataAccess.csproj InterviewDemo.DataAccess/
COPY InterviewDemo.Core/InterviewDemo.Core.csproj InterviewDemo.Core/
RUN dotnet restore InterviewDemo.API/InterviewDemo.API.csproj
COPY . .
WORKDIR /src/InterviewDemo.API
RUN dotnet build InterviewDemo.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish InterviewDemo.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "InterviewDemo.API.dll"]
