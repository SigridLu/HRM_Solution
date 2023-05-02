#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
ENV RecruitingDbContext="Data Source=192.168.1.239,1433; Database=HRM_Recruiting; User Id=sa; Password=PA_Clemson\$\$2020; TrustServerCertificate=true;"
ENV OnboardingDbContext="Data Source=192.168.1.239,1433; Database=HRM_Onboarding; User Id=sa; Password=PA_Clemson\$\$2020; TrustServerCertificate=true;"
ENV AuthenticationDbContext="Data Source=192.168.1.239,1433; Database=HRM_Authentication; User Id=sa; Password=PA_Clemson\$\$2020; TrustServerCertificate=true;"
ENV InterviewDbContext="Data Source=192.168.1.239,1433; Database=HRM_Interview; User Id=sa; Password=PA_Clemson\$\$2020; TrustServerCertificate=true;"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Recruiting_API/Recruiting_API.csproj", "Recruiting_API/"]
COPY ["Recruiting_Infrastructure/Recruiting_Infrastructure.csproj", "Recruiting_Infrastructure/"]
COPY ["Recruiting_ApplicationCore/Recruiting_ApplicationCore.csproj", "Recruiting_ApplicationCore/"]
RUN dotnet restore "Recruiting_API/Recruiting_API.csproj"
COPY . .
WORKDIR "/src/Recruiting_API"
RUN dotnet build "Recruiting_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recruiting_API.dll"]
