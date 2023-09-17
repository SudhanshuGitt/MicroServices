#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

# base image for .net to package our application

# image has file system and we create a dirctory called app and set eorking dirextlry to app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
# we need to copy all the packages to the 
COPY *.csproj ./
# pull down the packages in csproj files
RUN dotnet restore

COPY . ./
RUN dotnet build "PlatformService.csproj" -c Release -o out

# build full runtime version without SDK
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
# what command we need to run when when our image is executed inside the container
ENTRYPOINT ["dotnet", "PlatformService.dll"]