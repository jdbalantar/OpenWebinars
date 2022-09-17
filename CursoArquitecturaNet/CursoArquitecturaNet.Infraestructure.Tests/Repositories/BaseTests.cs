using CursoArquitecturaNet.Core.Entities.Base;
using CursoArquitecturaNet.Infraestructure.Data;
using CursoArquitecturaNet.Infraestructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace CursoArquitecturaNet.Infraestructure.Tests.Repositories
{
    public class BaseTests
    {
        [Fact]
        public async Task Add_BaseEntity_Successfully()
        {
            var dbSetMock = new Mock<DbSet<BaseEntity>>();
            dbSetMock.Setup(x => x.Add(It.IsAny<BaseEntity>()));

            var context = GenerateContext(dbSetMock);
            var repository = new Repository<BaseEntity>(context);

            var baseEntity = new BaseEntity();

            var entityAdded = await repository.AddAsync(baseEntity);

            Assert.Equal(entityAdded, baseEntity);
            dbSetMock.Verify(x => x.Add(It.IsAny<BaseEntity>()), Times.Once);
        }

        private CursoArquitecturaNetContext GenerateContext(Mock<DbSet<BaseEntity>> dbSetMock)
        {
            var dbOptions = new DbContextOptionsBuilder<CursoArquitecturaNetContext>()
                .UseInMemoryDatabase(databaseName: "CursoTestingDB").Options;

            var context = new Mock<CursoArquitecturaNetContext>(dbOptions);
            context.Setup(x => x.Set<BaseEntity>()).Returns(dbSetMock.Object);

            return context.Object;
        }
    }
}
