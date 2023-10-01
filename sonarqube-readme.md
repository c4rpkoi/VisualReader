1. Increase vm.max_map_count
* For windows: 
wsl -d docker-desktop
sysctl -w vm.max_map_count=262144

2. Start sonarqube docker - Run cmd
docker-compose -f .\sonarqube-compose.yml up -d

3. Go website: http://localhost:9000
Login with account:
user: admin
pass: admin

4. Create new project
- Choose "Use the global setting"
- Create successfully -> Choose "Locally"
- Generate token
- Run analysis on your project
- Click to tab .Net

5. Run cmd with config in UI
Example:
dotnet tool install --global dotnet-sonarscanner
dotnet sonarscanner begin /k:"aaa" /d:sonar.host.url="http://localhost:9000"  /d:sonar.token="{token}"
dotnet build
dotnet sonarscanner end /d:sonar.token="{token}"

