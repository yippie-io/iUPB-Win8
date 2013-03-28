using System.Collections.Generic;

namespace iUPB.Models
{
    internal interface IListDataModelProvider<T, U> where T : IListDataModel<U> 
                                                    where U : IListDataModelItem
    {
        void Load(string url = null);

        IEnumerable<T> All();

        T Find(int id);
    }
}