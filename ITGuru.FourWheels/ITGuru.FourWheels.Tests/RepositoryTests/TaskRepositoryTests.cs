using ITGuru.FourWheels.Data;
using ITGuru.FourWheels.Service;
using ITGuru.FourWheels.Service.Repos;

namespace ITGuru.FourWheels.Tests.RepositoryTests
{
    public class TaskRepositoryTests
    {
        private ITaskService _taskRepository;

        public TaskRepositoryTests()
        {
            DataLayer.WipeData();

            _taskRepository = new TaskService();
        }

        [Fact]
        public void AddAndGetTaskTest()
        {
            // Arrange

            // Act
            // Save task in repository.
            var addResult = _taskRepository.Add(TestData.DEFAULT_TASK);

            // Retrieve the newly added task from the repository.
            var addedTask = _taskRepository.GetById(TestData.DEFAULT_TASK.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedTask);
            AssertMulti.AllTaskProperties(TestData.DEFAULT_TASK, addedTask);
        }

        [Fact]
        public void AddAndRemoveTaskTest()
        {
            // 1. Add
            // Arrange

            // Act
            var addResult = _taskRepository.Add(TestData.DEFAULT_TASK);
            var addedTask = _taskRepository.GetById(TestData.DEFAULT_TASK.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedTask);
            AssertMulti.AllTaskProperties(TestData.DEFAULT_TASK, addedTask);

            // 2. Delete
            // Act
            var removeResult = _taskRepository.Remove(addedTask);
            var removedTask = _taskRepository.GetById(addedTask.Id);

            // Assert
            Assert.True(removeResult.Succeeded);
            Assert.Null(removedTask);
        }

        [Fact]
        public void AddAndUpdateTaskTest()
        {
            // 1. Add
            // Arrange

            // Act
            var addResult = _taskRepository.Add(TestData.DEFAULT_TASK);
            var addedTask = _taskRepository.GetById(TestData.DEFAULT_TASK.Id);

            // Assert
            Assert.True(addResult.Succeeded);
            Assert.NotNull(addedTask);
            AssertMulti.AllTaskProperties(TestData.DEFAULT_TASK, addedTask);

            // 2. Update
            // Act
            var updateResult = _taskRepository.Update(TestData.DEFAULT_TASK_EDITED);
            var editedTask = _taskRepository.GetById(addedTask.Id);

            // Assert
            Assert.True(updateResult.Succeeded);
            Assert.NotNull(editedTask);
            AssertMulti.AllTaskProperties(TestData.DEFAULT_TASK_EDITED, editedTask);
        }

        [Fact]
        public void AddDublicateTaskTest()
        {
            // Arrange

            // Act
            _taskRepository.Add(TestData.DEFAULT_TASK);
            _taskRepository.Add(TestData.DEFAULT_TASK);
            _taskRepository.Add(TestData.DEFAULT_TASK);

            var allTasks = _taskRepository.GetAll();

            // Assert
            var returnedTasks = allTasks.Where(c => c.Id == TestData.DEFAULT_TASK.Id);
            Assert.NotNull(returnedTasks.FirstOrDefault());
            Assert.Single(returnedTasks);
        }

        [Fact]
        public void GetAllTasks()
        {
            // Arrange
            bool addAllSuccess = true;
            foreach (var task in TestData.TASKS)
            {
                addAllSuccess = _taskRepository.Add(task).Succeeded && addAllSuccess;
            }

            // Act
            var retrievedTasks = _taskRepository.GetAll();

            // Assert
            Assert.True(addAllSuccess);

            foreach (var task in TestData.TASKS)
            {
                // Assert: Task is present and data is correct.
                var retrievedTask = retrievedTasks.Where(c => c.Id == task.Id).FirstOrDefault();
                Assert.NotNull(retrievedTask);
                AssertMulti.AllTaskProperties(task, retrievedTask);

                // Assert: Task is present once only.
                Assert.Single(retrievedTasks.Where(c => c.Id == task.Id));
            }
        }

        [Fact]
        public void DeleteNonExistingTaskTest()
        {
            // Arrange
            ITask nonExistingTask = new TaskDTO
            {
                Id = Guid.NewGuid()
            };

            // Act
            var result = _taskRepository.Remove(nonExistingTask);

            // Assert
            Assert.False(result.Succeeded);
        }
    }
}
