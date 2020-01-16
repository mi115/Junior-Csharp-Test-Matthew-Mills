using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI;
using Dapper;
using Xunit;
using WPFUI.Models;

namespace WPFUI.Tests
{
    public class DatabaseTests
    {
        [Fact]
        public void FetchAllBranches_CallAllBranchesFromDB()
        {
            // Arrange
            var dbConnection = new Database().GetConnection;
            var sql = "Select COUNT(*) from practicaltest.branches";
            var expected = dbConnection.QueryFirst<int>(sql);
            dbConnection.Close();

            // Act
            var db = new Database();
            var actual = db.FetchAllBranches();

            //Assert
            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public void GetAllOrders_NumberOfOrdersFetchedCorrectly()
        {
            //Arrange
            var dbConnection = new Database().GetConnection;
            var sql = "Select COUNT(*) from practicaltest.orders";
            var expected = dbConnection.QueryFirst<int>(sql);
            dbConnection.Close();

            //Act
            var db = new Database();
            var actual = db.GetAllOrders();

            //Assert
            Assert.Equal(expected, actual.Count());
        }

        [Theory]
        [InlineData(1, "Daniel", "Jackson", "09365358705", 1)]
        [InlineData(7209, "Margaret", "Collins", "00014846147", 7209)]
        [InlineData(15518, "Mark", "Morgan", "00393472034", 15518)]
        [InlineData(20000, "Patrick", "Young", "08966779912", 20000)]
        public void GetCustomerFromCustomerNumber_ReturnCorrectCustomer(int expectedCustomerNumber, string expectedForename, string expectedSurname, string expectedTelephoneNumber, int customerNumber)
        {
            //Arrange
            CustomerModel expected = new CustomerModel { CustomerNumber = expectedCustomerNumber, Forename = expectedForename, Surname = expectedSurname, TelephoneNumber = expectedTelephoneNumber };

            //Act
            var db = new Database();
            var actual = db.GetCustomerFromCustomerNumber(customerNumber);

            //Assert
            Assert.Equal(expected.CustomerNumber, actual.CustomerNumber);
            Assert.Equal(expected.Forename, actual.Forename);
            Assert.Equal(expected.Surname, actual.Surname);
            Assert.Equal(expected.TelephoneNumber, actual.TelephoneNumber);
        }

        [Fact]
        public void GetAllEmployees_NumberOfEmployeesFetchedCorrectly()
        {
            //Arrange
            var dbConnection = new Database().GetConnection;
            var sql = "Select COUNT(*) from practicaltest.employees";
            var expected = dbConnection.QueryFirst<int>(sql);
            dbConnection.Close();

            //Act
            var db = new Database();
            var actual = db.GetAllEmployees();

            //Assert
            Assert.Equal(expected, actual.Count());
        }

        [Fact]
        public void GetOrdersAfterDate_CheckForOldOrdersAfterCall()
        {
            //Arrange
            DateTime testVariable = new DateTime(2019, 1, 1);

            //Act
            var db = new Database();
            var actual = db.GetOrdersAfterDate(testVariable);

            //Assert
            Assert.Null(actual.Find(x => x.OrderDate < testVariable));
        }
    }
}
