using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace grep_food.DataAccess
{
    public interface IEntityTypeConfigurationRegistrar
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);
    }
}
