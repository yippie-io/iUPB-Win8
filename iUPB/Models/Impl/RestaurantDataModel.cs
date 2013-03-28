using System;
using System.Collections.Generic;
using System.Linq;

namespace iUPB.Models.Impl
{
    internal class RestaurantDataModel : IListDataModel<RestaurantDataModelItem>
    {
        public RestaurantDataModel(string title, int id, List<RestaurantDataModelItem> items)
        {
            this._items = items;
            this._id = id;
            this._title = title;
        }

        private List<RestaurantDataModelItem> _items;

        public IEnumerable<RestaurantDataModelItem> Items { get { return this._items; } }

        public IEnumerable<RestaurantDataModelItem> ItemsByDate(DateTime day)
        {
            return this.Items.Where((item, index) =>
            {
                return item.Day.Equals(day);
            });
        }

        private string _title;

        public string Title
        {
            get { return this._title; }
        }

        private int _id;

        public int Id
        {
            get { return this._id; }
        }
    }
}