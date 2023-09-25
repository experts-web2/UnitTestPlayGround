using Bogus;
using Domain.BL.Services.Implemention;
using Domain.DL.Repositories.GenericRepository;
using Domain.Entities.Dtos;
using Domain.Entities.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class DepartmentServiceTests
    {
        [Fact]
        public void GetAllDepartment_ReturnWithDtoModel()
        {
            // Arrange
            var mockRepo = new Mock<IGenericRepository<Department>>();
            int Id = 0;
            var department = new Faker<Department>().StrictMode(false)
                                                                 .RuleFor(x => x.Name, f => f.Person.FullName)
                                                                 .RuleFor(x => x.Id, f => Id++)
                                                                 .RuleFor(x => x.Description, f => f.Lorem.Sentence());
            var allDepartment = department.Generate(10).AsQueryable();
            mockRepo.Setup(x => x.GetAll()).Returns(allDepartment);

            // Act
            var departmentService = new DepartmentService(mockRepo.Object);
            var departments = departmentService.GetAll();

            // Assert
            Assert.NotEmpty(departments);
        }

        [Fact]
        public void AddDepartment_ReturnWithDtoModel()
        {
            int Id = 1;
            // Arrange
            var Department = new Department()
            {
                Id = Id,
                Name = "CS",
                Description = "Computer Scince"
            };

            var Request = new DepartmentDto()
            {
                Id = Id,
                Name = "CS",
                Description = "Computer Scince"
            };


            var mockRepo = new Mock<IGenericRepository<Department>>();
           
           

            mockRepo.Setup(x => x.Add(Department)).ReturnsAsync(Department);

            // Act
            var departmentService = new DepartmentService(mockRepo.Object);
            var department = departmentService.CreateAsync(Request).Result;

            // Assert
            Assert.NotNull(department);
        }


        [Fact]
        public void Update_ReturnsUpdatedDepartmentDto()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepository<Department>>();
            var departmentService = new DepartmentService(mockRepository.Object);

            var departmentDto = new DepartmentDto
            {
                Id = 1,
                Name = "Updated Department",
               Description = "Update Description"
            };

            
            mockRepository.Setup(repo => repo.update(It.IsAny<Department>()));
            mockRepository.Setup(repo => repo.SaveChange());

            // Act
            var updatedDto = departmentService.Update(departmentDto);

            // Assert
            Assert.NotNull(updatedDto);
            Assert.Equal(departmentDto.Id, updatedDto.Id);
            Assert.Equal(departmentDto.Name, updatedDto.Name);
           
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsDepartmentDto()
        {
            // Arrange
            var mockRepository = new Mock<IGenericRepository<Department>>();
            var departmentService = new DepartmentService(mockRepository.Object);

            var departmentId = 1; 

            var departmentEntity = new Department
            {
               
                Id = departmentId,
                Name = "CS",
                Description = "Computer Scince"
                
            };

            mockRepository.Setup(repo => repo.GetByID(departmentId))
                          .ReturnsAsync(departmentEntity);

            // Act
            var departmentDto = await departmentService.GetByIdAsync(departmentId);

            // Assert
            Assert.NotNull(departmentDto);
            Assert.Equal(departmentEntity.Id, departmentDto.Id);
            Assert.Equal(departmentEntity.Name, departmentDto.Name);
        }


    }
}
