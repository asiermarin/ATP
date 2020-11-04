FROM microsoft/dotnet:2.2-aspnetcore-runtime
# We create the folder inside the container
WORKDIR /hello

# We are coping all project executables that we created with dotnet build and dotnet publish 
COPY ./bin/Debug/netcoreapp3.1/publish/* ./

# We indicate to execute the program in the executable of the project
ENTRYPOINT ["dotnet", "Hello.dll"]