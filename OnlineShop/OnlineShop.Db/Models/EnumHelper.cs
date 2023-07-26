using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace OnlineShop.Db.Models
{
    public class EnumHelper
    {
        public static string GetAttributeName(Enum enumItem)
        {
            return enumItem.GetType()
                .GetMember(enumItem.ToString()).First()
                .GetCustomAttribute<DisplayAttribute>()?
                .GetName();
        }
    }
}
