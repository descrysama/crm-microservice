﻿using Microsoft.Extensions.DependencyInjection;
using userMicroService.IoCApplication;


namespace userMicroService.Tests.Common
{
    public class TestBase
    {
        protected ServiceProvider _serviceProvider;

        protected DatabaseContext _context;

        private void InitTestDatabase()
        {
            _context = _serviceProvider.GetService<DatabaseContext>();
            _context?.Database.EnsureDeleted();
            _context?.Database.EnsureCreated();
        }
        public void SetUpTest()
        {
            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .ConfigureDBContextTest()
                .ConfigureInjectionDependencyRepositoryTest()
                .ConfigureInjectionDependencyServiceTest()
                .BuildServiceProvider();

            InitTestDatabase();
        }

        public void CleanTest()
        {
            _context?.Database.EnsureDeleted();
            _serviceProvider.Dispose();
            _context?.Dispose();
        }

    }
}