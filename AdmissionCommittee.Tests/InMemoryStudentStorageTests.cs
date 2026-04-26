using AdmissionCommittee.Models;
using AdmissionCommittee.Storage.InMemory;
using FluentAssertions;

namespace AdmissionCommittee.Tests
{
    /// <summary>
    /// Тесты для класса <see cref="InMemoryStudentStorage"/>.
    /// Проверяют корректность операций добавления, поиска, обновления и удаления студентов.
    /// </summary>
    public class InMemoryStudentStorageTests
    {
        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.Add(Student)"/> 
        /// добавляет нового студента в хранилище, и его можно найти по идентификатору.
        /// </summary>
        [Fact]
        public void Add_StudentShouldAddedToStorage()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            var testStudent = new Student
            {
                Id = "4",
                FullName = "Кичигин Эдуард Валерьевич",
                Gender = Gender.Male,
                DateBirth = new DateTime(2000, 12, 11),
                FormOfEducation = "Очное",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100,
            };

            // Act
            storage.Add(testStudent);

            //Assert
            var found = storage.GetById("4");
            storage.GetTotalCount().Should().Be(4);
            found!.FullName.Should().Be("Кичигин Эдуард Валерьевич");
            found!.Id.Should().Be("4");
        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.GetById(string)"/> 
        /// возвращает студента при поиске по существующему идентификатору.
        /// </summary>
        [Fact]
        public void GetById_ExistingId_ShouldReturnStudent()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            var expectedStudent = new Student
            {
                Id = "TEST",
                FullName = "Кичигин Эдуард Валерьевич",
                Gender = Gender.Male,
                DateBirth = new DateTime(2000, 12, 11),
                FormOfEducation = "Очное",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100,
            };

            // Act
            storage.Add(expectedStudent);
            var actualStudent = storage.GetById("TEST");

            // Assert
            actualStudent.Should().NotBeNull();
            actualStudent!.Id.Should().Be("TEST");
            actualStudent!.FullName.Should().Be("Кичигин Эдуард Валерьевич");
        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.GetById(string)"/> 
        /// возвращает <see langword="null"/>, если студент с указанным идентификатором не найден.
        /// </summary>
        [Fact]
        public void GetById_NotExistingId_ShouldReturnNull()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            // Act
            var result = storage.GetById("???");

            // Arrange
            result.Should().BeNull();
        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.Delete(string)"/> 
        /// удаляет студента по существующему идентификатору.
        /// </summary>
        [Fact]
        public void Delete_ExistingId_ShouldRemoveStudent()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            var expectedStudent = new Student
            {
                Id = "4",
                FullName = "Кичигин Эдуард Валерьевич",
                Gender = Gender.Male,
                DateBirth = new DateTime(2000, 12, 11),
                FormOfEducation = "Очное",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100,
            };

            storage.Add(expectedStudent);
            var totalCount = storage.GetTotalCount();

            // Act
            storage.Delete("4");

            // Assert
            storage.GetTotalCount().Should().Be(totalCount - 1);
            storage.GetById("4").Should().BeNull();
        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.Delete(string)"/> 
        /// не вызывает исключение и не изменяет хранилище при удалении несуществующего студента.
        /// </summary>
        [Fact]
        public void Delete_NonExistingId_ShouldNotThrow()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            var totalCount = storage.GetTotalCount();

            // Act
            storage.Delete("4");

            // Assert
            storage.GetTotalCount().Should().Be(totalCount);

        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.Update(Student)"/> 
        /// обновляет данные существующего студента по идентификатору.
        /// </summary>
        [Fact]
        public void Update_ExistingStudent_ShouldUpdateRecord()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            var originStudent = new Student
            {
                Id = "4",
                FullName = "Старое имя",
                Gender = Gender.Male,
                DateBirth = new DateTime(2000, 12, 11),
                FormOfEducation = "Очное",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100,
            };

            storage.Add(originStudent);

            // Act
            var updatedStudent = new Student
            {
                Id = "4",
                FullName = "Новое имя",
                Gender = Gender.Male,
                DateBirth = new DateTime(2000, 12, 11),
                FormOfEducation = "Очное",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100,
            };

            storage.Update(updatedStudent);

            // Assert
            var found = storage.GetById("4");
            found.Should().NotBeNull();
            found!.FullName.Should().Be("Новое имя");
        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.Update(Student)"/> 
        /// выбрасывает <see cref="KeyNotFoundException"/>, если студент с указанным идентификатором не найден.
        /// </summary>
        [Fact]
        public void Update_NonExistentStudent_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            var testStudent = new Student
            {
                Id = "4",
                FullName = "Новое имя",
                Gender = Gender.Male,
                DateBirth = new DateTime(2000, 12, 11),
                FormOfEducation = "Очное",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100,
            };

            // Act
            Action act = () => storage.Update(testStudent);

            // Assert
            act.Should().Throw<KeyNotFoundException>();
        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.GetPassedCount(int)"/> 
        /// корректно подсчитывает количество студентов, набравших баллы выше заданного порога.
        /// </summary>
        [Fact]
        public void GetPassedCount_WithMixedScores_ShouldReturnCorrectCount()
        {
            // Arrenge
            var storage = new InMemoryStudentStorage();

            storage.Add(new Student
            {
                Id = "S1",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100, // Total = 300
                FullName = "S1",
                Gender = Gender.Male,
                DateBirth = DateTime.Now,
                FormOfEducation = "Очное"
            });

            storage.Add(new Student
            {
                Id = "S2",
                MathScores = 50,
                RusScores = 50,
                ComputerScienceScores = 50, // Total = 150 (не > 150!)
                FullName = "S2",
                Gender = Gender.Male,
                DateBirth = DateTime.Now,
                FormOfEducation = "Очное"
            });

            storage.Add(new Student
            {
                Id = "S3",
                MathScores = 90,
                RusScores = 90,
                ComputerScienceScores = 90, // Total = 270
                FullName = "S3",
                Gender = Gender.Male,
                DateBirth = DateTime.Now,
                FormOfEducation = "Очное"
            });

            // Act
            int result = storage.GetPassedCount(150);

            // Assert
            result.Should().Be(2);
        }

        /// <summary>
        /// Проверяет, что метод <see cref="InMemoryStudentStorage.GetAverageScore"/>
        /// корректно вычисляет средний балл всех студентов в хранилище.
        /// </summary>
        [Fact]
        public void GetAverageScore_WithStudents_ShouldReturnCorrectAverage()
        {
            // Arrange
            var storage = new InMemoryStudentStorage();

            storage.Add(new Student
            {
                Id = "S1",
                MathScores = 100,
                RusScores = 100,
                ComputerScienceScores = 100,
                FullName = "S1",
                Gender = Gender.Male,
                DateBirth = DateTime.Now,
                FormOfEducation = "Очное"
            });

            storage.Add(new Student
            {
                Id = "S2",
                MathScores = 50,
                RusScores = 50,
                ComputerScienceScores = 50,
                FullName = "S2",
                Gender = Gender.Male,
                DateBirth = DateTime.Now,
                FormOfEducation = "Очное"
            });

            // Act
            double result = storage.GetAverageScore();

            // Assert
            result.Should().Be(255);
        }
    }
}
