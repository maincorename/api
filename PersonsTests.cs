namespace ApiTests
{
    using System.Collections.Generic;
    using api;
    using api.Controllers;
    using api.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using NUnit.Framework;

    /// <summary>
    /// Класс проверки работы с сотрудниками.
    /// </summary>
    public class PersonsTests
    {
        /// <summary>
        /// Контекст.
        /// </summary>
        private MyContext _myContext;

        /// <summary>
        /// Подготовка к запуску тестов.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            const string ConnectionString = "Server=DESKTOP-0RNFI1F\\SQLEXPRESS; Database=webapidb; Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            
            _myContext = new MyContext(optionsBuilder.Options);
            
        }


        /// <summary>
        /// Тест добавления сотрудника.
        /// </summary>
        [Test]
        public void PersonAddTest()
        {
            //Arrange
            PeopleController peopleController = new PeopleController(_myContext);

            var pers = new Person
            {
                Name = "ОлегTest",
                DisplayName = "Middle",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Скилл1Test",
                        Level = 3
                    },
                    new Skill
                    {
                        Name = "Скилл2Test",
                        Level = 4
                    }
                }
            };

            //Act
            var result = peopleController.Post(pers);
            var eq = new OkObjectResult(200);

            //Assert
            Assert.AreEqual(result.Result, eq);
        }

        /// <summary>
        /// Тест удаления сотрудника.
        /// </summary>
        [Test]
        public void PersonDeleteTest()
        {
            //Arrange
            var idTest = 2;
            PeopleController peopleController = new PeopleController(_myContext);

            //Act
            var result = peopleController.Delete(idTest);
            var eq = new OkResult();

            //Assert
            Assert.AreEqual(result.Result, eq);
        }

        /// <summary>
        /// Тест обновления сотрудника.
        /// </summary>
        [Test]
        public void PersonUpdateTest()
        {
            //Arrange
            var idTest = 2;
            PeopleController peopleController = new PeopleController(_myContext);

            var person = new Person
            {
                Name = "Владимир",
                DisplayName = "TL",
                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Name = "Скилл33",
                        Level = 5
                    },
                    new Skill
                    {
                        Name = "Скилл22",
                        Level = 6
                    }
                }
            };

            //Act
            var result = peopleController.Put(idTest, person);
            var eq = new OkObjectResult(200);

            //Assert
            Assert.AreEqual(result.Result, eq);
        }
    }
}