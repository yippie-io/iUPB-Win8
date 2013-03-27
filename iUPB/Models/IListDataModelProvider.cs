using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iUPB.Models
{
    interface IListDataModelProvider
    {
        void load(string url = null);
        Task<IEnumerable<IListDataModel>> all();
        Task<IListDataModel> find(int id);
    }
}
