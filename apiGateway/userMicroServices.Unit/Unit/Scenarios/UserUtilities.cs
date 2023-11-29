using userMicroService.Entities;

namespace userMicroService.Tests.Unit.Scenarios
{
    public static class UserUtilities
    {
        public static void CreateUser(this DatabaseContext databaseContext)
        {
            User user = new()
            {
                Id = 1,
                Email = "descry@gmail.com",
                Password = "password",
                LastName = "testLastName",
                Name = "TestName",
                Username = "userName"
            };
            databaseContext.User.Add(user);
            databaseContext.SaveChanges();
        }

        public static void CreateUsers(this DatabaseContext meteoFranceDBContext)
        {
            User user = new()
            {
                Id = 3,
                Email = "descry@gmail.com",
                Password = "password",
                LastName = "testLastName",
                Name = "TestName",
                Username = "userName"
            };

            User user1 = new()
            {
                Id = 1,
                Email = "test1@gmail.com",
                Password = "password1",
                LastName = "testLastName1",
                Name = "TestName1",
                Username = "userName1"
            };
            User user2 = new()
            {
                Id = 2,
                Email = "test2@gmail.com",
                Password = "password2",
                LastName = "testLastName2",
                Name = "TestName2",
                Username = "userName2"
            };
            meteoFranceDBContext.User.AddRange(user, user1, user2);
            meteoFranceDBContext.SaveChanges();
        }
    }
}
