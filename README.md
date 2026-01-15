Run Locally (Without Docker)

Step 1: git clone https://github.com/Varun2004Yadav/StockBackend.git

Step 2: cd api

Step 3: Update connection string
            In appsettings.json:

            "ConnectionStrings": {
            "DefaultConnection": "Server=localhost;Database=StockDb;Trusted_Connection=True;TrustServerCertificate=True"
            }
Step 4: dotnet run

Step 5: http://localhost:5000/swagger

Run Using Docker 

    Docker Image: varun997/stock-api

    Step 1: docker pull varun997/stock-api:latest
    Step 2: docker run -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development  varun997/stock-api:latest

    Step 3: http://localhost:5000/swagger


Image available at: https://hub.docker.com/r/varun997/stock-api

Common Commands
    1.docker build -t stock-api .
    2.docker tag stock-api varun997/ stock-api:latest
    3.docker push varun997/stock-api:latest
    4.docker pull varun997/stock-api:latest

Varun Yadav
    GitHub: https://github.com/Varun2004Yadav
    Docker Hub: https://hub.docker.com/u/varun997