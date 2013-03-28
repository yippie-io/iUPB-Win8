using System;

namespace iUPB.Models.Impl
{
    internal class RestaurantDataModelItem : IListDataModelItem
    {
        private DateTime day;

        public DateTime Day { get { return this.day; } }

        private string _text;

        public RestaurantDataModelItem(string text, DateTime day)
        {
            this._text = text;
            this.day = day;
        }

        public string Text
        {
            get { return this._text; }
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}