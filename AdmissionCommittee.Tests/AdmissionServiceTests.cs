using FluentAssertions;
using Moq;
using AdmissionCommittee.Services;
using AdmissionCommittee.Models;
using AdmissionCommittee.Storage.Contracts;

namespace AdmissionCommittee.Tests
{
    /// <summary>
    /// Тесты для класса <see cref="AdmissionService"/>.
    /// Проверяет бизнес-логику сервиса: валидация, взаимодействие с хранилищем и обработку исключений.
    /// </summary>
    public class AdmissionServiceTests
    {
        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.GetAllStudents"/>
        /// возвращает все данные, полученные из хранилища.
        /// </summary>
        [Fact]
        public void GetAllStudents_ReturnAllStudentsFromStorage()
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            var expectedStudents = new List<Student>
            {
                new Student{Id = "1", FullName = "Белков Андрей Петрович"},
                new Student{Id = "2", FullName = "Анки Людмила Дмитриевна"}
            };

            mockStorage.Setup(x => x.GetAll()).Returns(expectedStudents);

            var service = new AdmissionService(mockStorage.Object);

            // Act
            var actualStudents = service.GetAllStudents();

            // Assert
            actualStudents.Should().NotBeNull();
            actualStudents.Should().HaveCount(2);
            actualStudents.Should().BeEquivalentTo(expectedStudents);
        }

        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.AddStudent(Student)"/> 
        /// успешно добавляет валидного студента и вызывает метод хранилища <see cref="IStudentStorage.Add(Student)"/>.
        /// </summary>
        [Fact]
        public void AddStudent_WithValidData_ShouldAddNewStudentAndCallStorage()
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            var testStudent = new Student { Id = "Add_valid_01", FullName = "Иванов Борис Романович", DateBirth = new DateTime(2001, 3, 12) };

            var service = new AdmissionService(mockStorage.Object);

            // Act
            service.AddStudent(testStudent);

            // Assert
            mockStorage.Verify(x => x.Add(It.IsAny<Student>()), Times.Once);

        }

        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.AddStudent(Student)"/> 
        /// выбрасывает <see cref="ArgumentException"/>, если дата рождения студента невалидна 
        /// (возраст меньше минимального или дата в будущем).
        /// </summary>
        [Theory]
        [InlineData(2020)]
        [InlineData(2030)]
        public void AddStudent_WithInvalidData_ShouldThrowArgumentException(int birthYear)
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            var invalidStudent = new Student { Id = "Add_invalid_01", FullName = "Иванов Борис Романович", DateBirth = new DateTime(birthYear, 1, 1) };

            var service = new AdmissionService(mockStorage.Object);

            // Act
            Action act = () => service.AddStudent(invalidStudent);

            // Assert
            act.Should().Throw<ArgumentException>();
            mockStorage.Verify(x => x.Add(It.IsAny<Student>()), Times.Never);
        }

        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.UpdateStudent(Student)"/> 
        /// успешно обновляет валидного студента и вызывает метод хранилища <see cref="IStudentStorage.Update(Student)"/>.
        /// </summary>
        [Fact]
        public void UpdateStudent_WithValidStudent_ShouldCallStorageUpdate()
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            var testStudent = new Student { Id = "Update_valid_01", FullName = "Иванов Борис Романович", DateBirth = new DateTime(2001, 3, 12) };

            var service = new AdmissionService(mockStorage.Object);

            // Act
            service.UpdateStudent(testStudent);

            // Assert
            mockStorage.Verify(x => x.Update(It.IsAny<Student>()), Times.Once);
        }

        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.UpdateStudent(Student)"/> 
        /// выбрасывает <see cref="InvalidOperationException"/>, если хранилище не находит студента для обновления 
        /// (перехватывает <see cref="KeyNotFoundException"/> от хранилища).
        /// </summary>
        [Fact]
        public void UpdateStudent_WhenStorageThrowsKeyNotFoundException_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            mockStorage.Setup(x => x.Update(It.IsAny<Student>()))
                .Throws<KeyNotFoundException>();

            var invalidStudent = new Student { Id = "Update_02", FullName = "Иванов Борис Романович", DateBirth = new DateTime(2001, 3, 12) };

            var service = new AdmissionService(mockStorage.Object);

            // Act
            Action act = () => service.UpdateStudent(invalidStudent);

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.DeleteStudent(string)"/> 
        /// вызывает метод хранилища <see cref="IStudentStorage.Delete(string)"/> с переданным идентификатором.
        /// </summary>
        [Fact]
        public void DeleteStudent_ShouldDeleteStudent()
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            var testId = "Delete_01";

            var service = new AdmissionService(mockStorage.Object);

            // Act
            service.DeleteStudent(testId);

            // Assert
            mockStorage.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);
        }

        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.GetStatistics"/> 
        /// возвращает <see cref="StudentStatistic.Empty"/>, когда в хранилище нет студентов.
        /// </summary>
        [Fact]
        public void GetStatistics_WhenEmpty_ReturnStudentStatisticEmpty()
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            mockStorage.Setup(x => x.GetTotalCount()).Returns(0);

            var service = new AdmissionService(mockStorage.Object);

            // Act
            var result = service.GetStatistics();

            // Assert
            result.Should().BeEquivalentTo(StudentStatistic.Empty);
        }

        /// <summary>
        /// Проверяет, что метод <see cref="AdmissionService.GetStatistics"/> 
        /// корректно формирует статистику при наличии данных в хранилище:
        /// общее количество, количество прошедших порог, средний, максимальный и минимальный баллы.
        /// </summary>
        [Fact]
        public void GetStatistics_WithData_ShouldReturnCorrectStatistic()
        {
            // Arrange
            var mockStorage = new Mock<IStudentStorage>();

            var testStudent = new List<Student>
            {
                new Student{ MathScores = 100, RusScores = 100, ComputerScienceScores = 100 },
                new Student{ MathScores = 30, RusScores = 60, ComputerScienceScores = 20 },
                new Student{ MathScores = 100, RusScores = 50, ComputerScienceScores = 80 },
            };

            mockStorage.Setup(x => x.GetTotalCount()).Returns(3);
            mockStorage.Setup(x => x.GetPassedCount(150)).Returns(2);
            mockStorage.Setup(x => x.GetAverageScore()).Returns(200);
            mockStorage.Setup(x => x.GetAll()).Returns(testStudent);

            var service = new AdmissionService(mockStorage.Object);

            // Act
            var result = service.GetStatistics();

            // Assert
            result.TotalCount.Should().Be(3);
            result.PassedCount.Should().Be(2);
            result.AverageScore.Should().Be(200);
            result.MaxScore.Should().Be(300);
            result.MinScore.Should().Be(110);
            result.Threshold.Should().Be(150);
        }
    }
}
