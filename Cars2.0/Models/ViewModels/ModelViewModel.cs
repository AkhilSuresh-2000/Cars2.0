using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cars2._0.Models.ViewModels
{
    public class ModelViewModel
    {
        public Model Model { get; set; }
        //display the list of makes in our drop down
        public IEnumerable<Make> Makes { get; set; }
        //CSelectListItem is a method in ModelViewModel class to convert a IEnumerabme of make to the IEnumerable of selectlist item
        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Make> Items)
        {
           if(Items == null)
            {
                
            }

            List<SelectListItem> MakeList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                //This is to show the drop down on top
                Text = "----Select----",
                Value = "0"
            };
            MakeList.Add(sli);
            try
            {
                foreach (Make make in Items)
                {
                    sli = new SelectListItem
                    {

                        Text = make.Name,
                        Value = make.id.ToString()

                    };
                    MakeList.Add(sli);
                }
            }
            catch(NullReferenceException e) {
                Console.WriteLine(e.GetBaseException());
            }
            
            return MakeList;

        }
    }
}
