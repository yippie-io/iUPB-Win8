using iUPB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace iUPB.Models.Impl
{
    internal class RestaurantDataModelProvider : IListDataModelProvider<RestaurantDataModel, RestaurantDataModelItem>
    {
        private bool Loaded = false;
        private Dictionary<string, RestaurantDataModel> restaurants = new Dictionary<string, RestaurantDataModel>();

        public async void Load(string url = null)
        {
            if (!Loaded)
            {
                try
                {
                    // Create a New HttpClient object.
                    HttpClient client = new HttpClient();

                    string responseBody = await client.GetStringAsync(ConfigProvider.Instance.Get("restaurants_url"));
                    JsonArray restaurants = JsonArray.Parse(responseBody);
                    foreach (JsonObject restaurant in restaurants)
                    {
                        this.restaurants.Add(restaurant.GetNamedString("name"), null);
                    }

                    int i = 0;
                    foreach (string name in this.restaurants.Keys)
                    {
                        string menusBody = await client.GetStringAsync(ConfigProvider.Instance.Get("menus_url_prefix") + name);
                        JsonArray menus = JsonArray.Parse(menusBody);
                        IEnumerable<RestaurantDataModelItem> items = menus.Select((menu) =>
                        {
                            JsonObject menuJSON = menu as JsonObject;
                            return new RestaurantDataModelItem(menuJSON.GetNamedString("description"), DateTime.Parse(menuJSON.GetNamedString("date")));
                        });
                        this.restaurants[name] = new RestaurantDataModel(name, i++, items.ToList());
                        Loaded = true;
                    }
                }
                catch (HttpRequestException e)
                {
                    // awaiting is not allowed, so no output in catch parts in Win 8 was planned ?
                    new Windows.UI.Popups.MessageDialog("Sorry, beim Abruf der Restaurantdaten ist leider ein Fehlder aufgetreten.", "Fehler / Restaurantdaten").ShowAsync().GetResults();
                }
            }
        }

        public IEnumerable<RestaurantDataModel> All()
        {
            this.Load();
            return restaurants.Values.AsEnumerable();
        }

        public RestaurantDataModel Find(int id)
        {
            this.Load();
            return restaurants.Values.First((restaurant) => restaurant.Id == id);
        }
    }
}