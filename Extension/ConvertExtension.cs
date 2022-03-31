using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Extension
{
    public static class ConvertExtension
    {
        public static List<SelectListItem> ConvertToSelectList<T>(this IEnumerable<T> collection, int selectedValue) where T :IPrimaryProperties
        {
            return (
                    from item in collection
                    select new SelectListItem { 
                    Value=item.Id.ToString(),
                    Text=item.Title,
                    Selected=(item.Id==selectedValue)
                    }
                ).ToList();
        }
    }
}
