using CodeXSnips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeXSnips.DataAccess.Repository.IRepository
{
    public interface IStoryRepository : IRepository<Story>
    {
        void Update(Story obj);
    }
}
