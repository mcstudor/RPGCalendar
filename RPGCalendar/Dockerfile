FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Prevent 'Warning: apt-key output should not be parsed (stdout is not a terminal)'
ENV APT_KEY_DONT_WARN_ON_DANGEROUS_USAGE=1

# install NodeJS 13.x
# see https://github.com/nodesource/distributions/blob/master/README.md#deb
RUN apt-get update -yq 
RUN apt-get install curl gnupg -yq 
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get install -y nodejs

# copy csproj and restore as distinct layers
COPY *.sln .
COPY RPGCalendar/*.csproj ./RPGCalendar/
RUN dotnet restore

# copy everything else and build app
COPY RPGCalendar/. ./RPGCalendar/
WORKDIR /app/RPGCalendar
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/RPGCalendar/out ./

ENTRYPOINT ["dotnet", "RPGCalendar.dll"]