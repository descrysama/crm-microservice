using Microsoft.EntityFrameworkCore;
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

        public static void CreateUsers(this DatabaseContext databaseContext)
        {
            User user = new()
            {
                Id = 4,
                Email = "test4@gmail.com",
                Password = "password4",
                LastName = "testLastName4",
                Name = "TestName4",
                Username = "userName4"
            };

            User user1 = new()
            {
                Id = 2,
                Email = "test2@gmail.com",
                Password = "password2",
                LastName = "testLastNam2",
                Name = "TestName2",
                Username = "userName2"
            };
            User user2 = new()
            {
                Id = 3,
                Email = "test3@gmail.com",
                Password = "password3",
                LastName = "testLastName3",
                Name = "TestName3",
                Username = "userName3"
            };
            databaseContext.User.AddRange(user, user1, user2);
            databaseContext.SaveChanges();

            foreach (var entity in databaseContext.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }
        }
    }
}
