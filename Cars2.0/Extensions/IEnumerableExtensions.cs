using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars2._0.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items)
        {
            if (Items == null)
            {

            }

            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                //This is to show the drop down on top
                Text = "----Select----",
                Value = "0"
            };
            List.Add(sli);
            try
            {
                foreach (var item in Items)
                {
                    sli = new SelectListItem
                    {
                        Text = item.GetPropertyValue("Name"),
                       // Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                       // Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString()
                       Value = item.GetPropertyValue("Id")

                    };
                    List.Add(sli);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.GetBaseException());
            }

            return List;

        }
    }
}
