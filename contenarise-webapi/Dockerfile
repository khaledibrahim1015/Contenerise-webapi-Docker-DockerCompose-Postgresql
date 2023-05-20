# Base image 
# first stage to Build Container 
#SDK IMAGE 
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build 
WORKDIR /src
EXPOSE 80
EXPOSE 443


#Copy all project file from local machine to src directory in build container 
COPY *.csproj ./

# Run dotnet restore inside built container => restore all dependencies and packages from Nuget => in Build Container 

RUN dotnet restore 

# copy all files and direstories from local machine to build container 
COPY . ./

# Run dotnet Command to publish application inside built container 

RUN dotnet publish -c Release -o out

# to run apllication inside Docker Image => need second stage (image ) to run app 
#dotnet Runtime 
#FINAL STAGE 

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
EXPOSE 80

COPY --from=build /src/out .
ENTRYPOINT [ "dotnet","contenarise-webapi.dll" ]







