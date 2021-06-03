using Microsoft.EntityFrameworkCore;

namespace Tap2021Demo.Infrastructure.DataAccess
{
    public interface IEntityTypeConfigurationRegistrar
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
