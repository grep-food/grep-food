using System;

namespace grep_food.DataAccess
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
