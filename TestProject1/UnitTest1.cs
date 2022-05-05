using consumeapiiiii.Controllers;
using APICRUD.Data.Models;
using System;
using APICRUD.Controllers;
using APICRUD.Models;
using Xunit;
using APICRUD.EmployeeData;
using FakeItEasy;
using System.Threading.Tasks;
using NPOI.SS.Formula.Functions;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TestProject1
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task Index_Returns_The_Correct_Number_Of_Employees()
        {
            // Arrange
            int count = 2;
            var fakeEmployee = A.CollectionOfDummy<Employee>(count).AsEnumerable();
            var dataStore = A.Fake<IEmployeeData>();
            A.CallTo(() => dataStore.GetEmployees()).Returns(Task.FromResult(fakeEmployee));
            var controller = new EmployeesController(dataStore);
            //Act
            var actionResult = controller.GetEmployees();
            //Assert
            var result = actionResult.ExecuteResultAsync as OkObjectResult;
            var returnEmployees = result.Value as IEnumerable<Employee>;
            Assert.Equal(count, returnEmployees.Count());
            }
    }
}
