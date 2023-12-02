# Square Service

DDD service that finds squares from points.

## Usage

To use this service, follow these steps:

1. **Install SQL Server Express LocalDB**  
   You can download and install SQL Server Express LocalDB from [Microsoft's official documentation](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16).

2. **Build the Docker Image**  
   Use the following command to build the Docker image: 
	```bash
    docker build -t square-service .
	```

3. **Run the Docker Container**
   After building the image, run the container using:
   ```bash
   docker run -d -p 8080:80 --name my-square-service square-service
   ```
Or just open up your favorite IDE and press f5.

### Remarks

1. Would have added ApplicationInsights but currently don't have an Azure account
2. MongoDB would have been better for something like this, but requirments are requirments :)

#### TODO

1. Add E2E tests
2. Add benchmarks