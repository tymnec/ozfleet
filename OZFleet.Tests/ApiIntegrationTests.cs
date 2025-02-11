using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using OZFleet.Core.Entities;
using OZFleet.WebApi;
using System.Text;

namespace OZFleet.Tests.Integration
{
    public abstract class ApiTestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient Client;

        public ApiTestBase(WebApplicationFactory<Program> factory)
        {
            Client = factory.CreateClient();
        }

        protected bool IsAllowedStatus(HttpStatusCode code, params HttpStatusCode[] allowed)
        {
            foreach (var status in allowed)
            {
                if (code == status) return true;
            }
            return false;
        }
    }

    public class UserTests : ApiTestBase
    {
        public UserTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact(DisplayName = "User CRUD Operations")]
        public async Task User_CRUD_Works()
        {
            var result = new TestResult(
                "User CRUD Operations",
                "Create, Read, Update, Delete"
            );

            try
            {
                var newUser = new User { Name = "Test User", Email = "testuser@example.com" };
                var createResponse = await Client.PostAsJsonAsync("/api/User", newUser);
                createResponse.EnsureSuccessStatusCode();
                var createdUser = await createResponse.Content.ReadFromJsonAsync<User>();
                Assert.NotNull(createdUser);
                Assert.True(createdUser.Id > 0);

                var getResponse = await Client.GetAsync($"/api/User/{createdUser.Id}");
                getResponse.EnsureSuccessStatusCode();
                var fetchedUser = await getResponse.Content.ReadFromJsonAsync<User>();
                Assert.Equal(createdUser.Id, fetchedUser.Id);

                fetchedUser.Name = "Updated Test User";
                var updateResponse = await Client.PutAsJsonAsync($"/api/User/{fetchedUser.Id}", fetchedUser);
                updateResponse.EnsureSuccessStatusCode();

                var deleteResponse = await Client.DeleteAsync($"/api/User/{fetchedUser.Id}");
                Assert.True(IsAllowedStatus(deleteResponse.StatusCode, HttpStatusCode.OK, HttpStatusCode.NoContent));

                var getAfterDelete = await Client.GetAsync($"/api/User/{fetchedUser.Id}");
                Assert.Equal(HttpStatusCode.NotFound, getAfterDelete.StatusCode);

                result.Passed++;
            }
            catch
            {
                result.Failed++;
            }

            System.Console.WriteLine(result.ToString());
        }
    }

    public class VehicleTests : ApiTestBase
    {
        public VehicleTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact(DisplayName = "Vehicle CRUD Operations")]
        public async Task Vehicle_CRUD_Works()
        {
            var result = new TestResult(
                "Vehicle CRUD Operations",
                "Create, Read, Update, Delete"
            );

            try
            {
                var newVehicle = new Vehicle { Make = "Toyota", Model = "Camry", Year = 2020 };
                var createResponse = await Client.PostAsJsonAsync("/api/Vehicle", newVehicle);
                createResponse.EnsureSuccessStatusCode();
                var createdVehicle = await createResponse.Content.ReadFromJsonAsync<Vehicle>();
                Assert.NotNull(createdVehicle);
                Assert.True(createdVehicle.Id > 0);

                var getResponse = await Client.GetAsync($"/api/Vehicle/{createdVehicle.Id}");
                getResponse.EnsureSuccessStatusCode();
                var fetchedVehicle = await getResponse.Content.ReadFromJsonAsync<Vehicle>();
                Assert.Equal(createdVehicle.Id, fetchedVehicle.Id);

                fetchedVehicle.Model = "Corolla";
                var updateResponse = await Client.PutAsJsonAsync($"/api/Vehicle/{fetchedVehicle.Id}", fetchedVehicle);
                updateResponse.EnsureSuccessStatusCode();

                var deleteResponse = await Client.DeleteAsync($"/api/Vehicle/{fetchedVehicle.Id}");
                Assert.True(IsAllowedStatus(deleteResponse.StatusCode, HttpStatusCode.OK, HttpStatusCode.NoContent));

                var getAfterDelete = await Client.GetAsync($"/api/Vehicle/{fetchedVehicle.Id}");
                Assert.Equal(HttpStatusCode.NotFound, getAfterDelete.StatusCode);

                result.Passed++;
            }
            catch
            {
                result.Failed++;
            }

            System.Console.WriteLine(result.ToString());
        }
    }

    public class DriverTests : ApiTestBase
    {
        public DriverTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact(DisplayName = "Driver CRUD Operations")]
        public async Task Driver_CRUD_Works()
        {
            var result = new TestResult(
                "Driver CRUD Operations",
                "Create, Read, Update, Delete"
            );

            try
            {
                var newDriver = new Driver
                {
                    Name = "Test Driver",
                    LicenseNumber = "XYZ123",
                    LicenseExpiry = System.DateTime.UtcNow.AddYears(2)
                };
                var createResponse = await Client.PostAsJsonAsync("/api/Driver", newDriver);
                createResponse.EnsureSuccessStatusCode();
                var createdDriver = await createResponse.Content.ReadFromJsonAsync<Driver>();
                Assert.NotNull(createdDriver);
                Assert.True(createdDriver.Id > 0);

                var getResponse = await Client.GetAsync($"/api/Driver/{createdDriver.Id}");
                getResponse.EnsureSuccessStatusCode();
                var fetchedDriver = await getResponse.Content.ReadFromJsonAsync<Driver>();
                Assert.Equal(createdDriver.Id, fetchedDriver.Id);

                fetchedDriver.Name = "Updated Driver";
                var updateResponse = await Client.PutAsJsonAsync($"/api/Driver/{fetchedDriver.Id}", fetchedDriver);
                updateResponse.EnsureSuccessStatusCode();

                var deleteResponse = await Client.DeleteAsync($"/api/Driver/{fetchedDriver.Id}");
                Assert.True(IsAllowedStatus(deleteResponse.StatusCode, HttpStatusCode.OK, HttpStatusCode.NoContent));

                var getAfterDelete = await Client.GetAsync($"/api/Driver/{fetchedDriver.Id}");
                Assert.Equal(HttpStatusCode.NotFound, getAfterDelete.StatusCode);

                result.Passed++;
            }
            catch
            {
                result.Failed++;
            }

            System.Console.WriteLine(result.ToString());
        }
    }

    public class FuelRecordTests : ApiTestBase
    {
        public FuelRecordTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact(DisplayName = "FuelRecord CRUD Operations")]
        public async Task FuelRecord_CRUD_Works()
        {
            var result = new TestResult(
                "FuelRecord CRUD Operations",
                "Create, Read, Update, Delete"
            );

            try
            {
                var newFuelRecord = new FuelRecord
                {
                    VehicleId = 1,
                    DriverId = 1,
                    FuelDate = System.DateTime.UtcNow,
                    FuelAmount = 50.0m,
                    Cost = 100.0m,
                    OdometerReading = 1000.0
                };
                var createResponse = await Client.PostAsJsonAsync("/api/FuelRecord", newFuelRecord);
                createResponse.EnsureSuccessStatusCode();
                var createdFuelRecord = await createResponse.Content.ReadFromJsonAsync<FuelRecord>();
                Assert.NotNull(createdFuelRecord);
                Assert.True(createdFuelRecord.Id > 0);

                var getResponse = await Client.GetAsync($"/api/FuelRecord/{createdFuelRecord.Id}");
                getResponse.EnsureSuccessStatusCode();
                var fetchedFuelRecord = await getResponse.Content.ReadFromJsonAsync<FuelRecord>();
                Assert.Equal(createdFuelRecord.Id, fetchedFuelRecord.Id);

                fetchedFuelRecord.Cost = 110.0m;
                var updateResponse = await Client.PutAsJsonAsync($"/api/FuelRecord/{fetchedFuelRecord.Id}", fetchedFuelRecord);
                updateResponse.EnsureSuccessStatusCode();

                var deleteResponse = await Client.DeleteAsync($"/api/FuelRecord/{fetchedFuelRecord.Id}");
                Assert.True(IsAllowedStatus(deleteResponse.StatusCode, HttpStatusCode.OK, HttpStatusCode.NoContent));

                var getAfterDelete = await Client.GetAsync($"/api/FuelRecord/{fetchedFuelRecord.Id}");
                Assert.Equal(HttpStatusCode.NotFound, getAfterDelete.StatusCode);

                result.Passed++;
            }
            catch
            {
                result.Failed++;
            }

            System.Console.WriteLine(result.ToString());
        }
    }

    public class MaintenanceTests : ApiTestBase
    {
        public MaintenanceTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact(DisplayName = "Maintenance CRUD Operations")]
        public async Task Maintenance_CRUD_Works()
        {
            var result = new TestResult(
                "Maintenance CRUD Operations",
                "Create, Read, Update, Delete"
            );

            try
            {
                var newMaintenance = new Maintenance
                {
                    VehicleId = 1,
                    MaintenanceDate = System.DateTime.UtcNow,
                    Description = "Test Maintenance",
                    Cost = 75.0m,
                    NextDueDate = System.DateTime.UtcNow.AddMonths(6)
                };
                var createResponse = await Client.PostAsJsonAsync("/api/Maintenance", newMaintenance);
                createResponse.EnsureSuccessStatusCode();
                var createdMaintenance = await createResponse.Content.ReadFromJsonAsync<Maintenance>();
                Assert.NotNull(createdMaintenance);
                Assert.True(createdMaintenance.Id > 0);

                var getResponse = await Client.GetAsync($"/api/Maintenance/{createdMaintenance.Id}");
                getResponse.EnsureSuccessStatusCode();
                var fetchedMaintenance = await getResponse.Content.ReadFromJsonAsync<Maintenance>();
                Assert.Equal(createdMaintenance.Id, fetchedMaintenance.Id);

                fetchedMaintenance.Cost = 80.0m;
                var updateResponse = await Client.PutAsJsonAsync($"/api/Maintenance/{fetchedMaintenance.Id}", fetchedMaintenance);
                updateResponse.EnsureSuccessStatusCode();

                var deleteResponse = await Client.DeleteAsync($"/api/Maintenance/{fetchedMaintenance.Id}");
                Assert.True(IsAllowedStatus(deleteResponse.StatusCode, HttpStatusCode.OK, HttpStatusCode.NoContent));

                var getAfterDelete = await Client.GetAsync($"/api/Maintenance/{fetchedMaintenance.Id}");
                Assert.Equal(HttpStatusCode.NotFound, getAfterDelete.StatusCode);

                result.Passed++;
            }
            catch
            {
                result.Failed++;
            }

            System.Console.WriteLine(result.ToString());
        }
    }

    public class TripTests : ApiTestBase
    {
        public TripTests(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact(DisplayName = "Trip CRUD Operations")]
        public async Task Trip_CRUD_Works()
        {
            var result = new TestResult(
                "Trip CRUD Operations",
                "Create, Read, Update, Delete"
            );

            try
            {
                var newTrip = new Trip
                {
                    VehicleId = 1,
                    DriverId = 1,
                    StartTime = System.DateTime.UtcNow,
                    EndTime = System.DateTime.UtcNow.AddHours(2),
                    StartLocation = "Location A",
                    EndLocation = "Location B",
                    Distance = 120.0
                };
                var createResponse = await Client.PostAsJsonAsync("/api/Trip", newTrip);
                createResponse.EnsureSuccessStatusCode();
                var createdTrip = await createResponse.Content.ReadFromJsonAsync<Trip>();
                Assert.NotNull(createdTrip);
                Assert.True(createdTrip.Id > 0);

                var getResponse = await Client.GetAsync($"/api/Trip/{createdTrip.Id}");
                getResponse.EnsureSuccessStatusCode();
                var fetchedTrip = await getResponse.Content.ReadFromJsonAsync<Trip>();
                Assert.Equal(createdTrip.Id, fetchedTrip.Id);

                fetchedTrip.Distance = 130.0;
                var updateResponse = await Client.PutAsJsonAsync($"/api/Trip/{fetchedTrip.Id}", fetchedTrip);
                updateResponse.EnsureSuccessStatusCode();

                var deleteResponse = await Client.DeleteAsync($"/api/Trip/{fetchedTrip.Id}");
                Assert.True(IsAllowedStatus(deleteResponse.StatusCode, HttpStatusCode.OK, HttpStatusCode.NoContent));

                var getAfterDelete = await Client.GetAsync($"/api/Trip/{fetchedTrip.Id}");
                Assert.Equal(HttpStatusCode.NotFound, getAfterDelete.StatusCode);

                result.Passed++;
            }
            catch
            {
                result.Failed++;
            }

            System.Console.WriteLine(result.ToString());
        }
    }

    public class TestResult(string testName, string testDescription)
    {
        public int Passed { get; set; }
        public int Failed { get; set; }
        public string TestName { get; set; } = testName;

        public string TestDescription { get; set; } = testDescription;

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Test Result for {TestName}");
            result.AppendLine($"{TestDescription}");
            result.AppendLine($"Passed: {Passed}");
            result.AppendLine($"Failed: {Failed}");
            result.AppendLine($"Total: {Passed + Failed}");
            result.AppendLine($"Success Rate: {(double)Passed / (Passed + Failed) * 100:0.00}%");
            // System.Console.WriteLine($"Test: {TestName}, Passed: {Passed}, Failed: {Failed}, Total: {Passed + Failed}");
            return result.ToString();
        }
    }
}


