using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iUPB.Models.Impl
{
    class RestaurantDataModel : IListDataModel
    {

        public RestaurantDataModel(string title, int id, List<RestaurantDataModelItem> items)
        {
            this.Items = items;
            this._id = id;
            this._title = title;
        }

        private List<RestaurantDataModelItem> Items;
        public IEnumerable<RestaurantDataModelItem> items { get { return this.Items; } }

        public IEnumerable<RestaurantDataModelItem> itemsByDate(DateTime day)
        {
            return this.Items.Where((item, index) =>
            {
                return item.Day.Equals(day);
            });
        }

        private string _title;
        public string title
        {
            get { return this._title; }
        }

        private int _id;
        public int id
        {
            get { return this._id; }
        }
    }
}
