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
COPY ["Authentication_API/Authentication_API.csproj", "Authentication_API/"]
COPY ["Authentication_Infrastructure/Authentication_Infrastructure.csproj", "Authentication_Infrastructure/"]
COPY ["Authentication_ApplicationCore/Authentication_ApplicationCore.csproj", "Authentication_ApplicationCore/"]
RUN dotnet restore "Authentication_API/Authentication_API.csproj"
COPY . .
WORKDIR "/src/Authentication_API"
RUN dotnet build "Authentication_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authentication_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authentication_API.dll"]
