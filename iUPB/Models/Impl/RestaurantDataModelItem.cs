using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iUPB.Models.Impl
{
    class RestaurantDataModelItem : IListDataModelItem
    {
        private DateTime day;
        public DateTime Day { get { return this.day; } }

        private string _text;
        public RestaurantDataModelItem(string text, DateTime day)
        {
            this._text = text;
            this.day = day;
        }
        public string text
        {
            get { return this._text; }
        }

        public override string ToString()
        {
            return this.text;
        }
    }
}
