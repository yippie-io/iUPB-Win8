using System.Collections.Generic;

namespace iUPB.Models
{
    internal interface IListDataModel<T> where T : IListDataModelItem
    {
        string Title { get; }

        int Id { get; }

        IEnumerable<T> Items { get; }
    }
}