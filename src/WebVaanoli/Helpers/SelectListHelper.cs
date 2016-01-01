using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebVaanoli.Helpers
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> AsSelectList<T>(
            this IEnumerable<T> list,
            Func<T, string> textProperty,
            Func<T, string> valueProperty)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem() { Text = "-- Select --" });
            selectList.AddRange(list.Select(item =>
            {
                return new SelectListItem()
                {
                    Text = textProperty(item),
                    Value = valueProperty(item)
                };
            }).ToList());
            return selectList;
        }

        public static List<SelectListItem> BooleanSelectList()
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem() { Text = "-- Select --" });
            selectList.Add(new SelectListItem() { Text = "Yes", Value = "true" });
            selectList.Add(new SelectListItem() { Text = "No", Value = "false" });
            return selectList;
        }
    }
}
