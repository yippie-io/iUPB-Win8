using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iUPB.Models
{
    interface IListDataModel
    {
        string title { get; }
        int id { get; }
        IEnumerable<IListDataModelItem> items { get; }
    }
}
