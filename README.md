## How to setup project ?
1. Setup environment
- Visual Studio /VS Code
- .NET6 SDK
- Visual Studio Code extensions
- C#
- Remote Container
- Docker, KubeCtl, newman
- Postman, Tests Postman
- Git, Source Tree

## Set Policy
1. Run as Administrator with Windows PowerShell: 
  Set-ExecutionPolicy -ExecutionPolicy RemoteSigned
2. After that:
  $env:CAKE_SETTINGS_SKIPPACKAGEVERSIONCHECK="true"
  .\build.ps1 --target=Compose
  .\build.ps1 --target=Up
  
## Run UTs test

newman run -k -e ./tests/AppData/Docker.postman_environment.json ./tests/AppData/Test.postman_collection.json

## Compose
.\build.ps1 --target=compose
## Up
.\build.ps1 --target=Up
## Down
.\build.ps1 --target=Down