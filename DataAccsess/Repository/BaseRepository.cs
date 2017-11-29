using DataAccsess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Repository
{
    public abstract class BaseRepository
    {
        protected DataModelContainer context;

        protected BaseRepository()
        {
            context = new DataModelContainer();
        }

        protected BaseRepository(DataModelContainer context)
        {
            this.context = context;
        }

    }
}
