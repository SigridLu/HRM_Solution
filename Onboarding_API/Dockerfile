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
COPY ["Onboarding_API/Onboarding_API.csproj", "Onboarding_API/"]
COPY ["Onboarding_Infrastructure/Onboarding_Infrastructure.csproj", "Onboarding_Infrastructure/"]
COPY ["Onboarding_ApplicationCore/Onboarding_ApplicationCore.csproj", "Onboarding_ApplicationCore/"]
RUN dotnet restore "Onboarding_API/Onboarding_API.csproj"
COPY . .
WORKDIR "/src/Onboarding_API"
RUN dotnet build "Onboarding_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboarding_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboarding_API.dll"]
