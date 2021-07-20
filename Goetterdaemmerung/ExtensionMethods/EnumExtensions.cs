using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Threading.Tasks;
using Project_Goettergaemmerung.Components.Model;
using System.ComponentModel;

namespace Project_Goettergaemmerung.ExtensionMethods
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var enumField = value.GetType().GetField(value.ToString());

            if (enumField != null)
            {
                var attributes = (DescriptionAttribute[])enumField.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes[0].Description;
            }
            return "";
        }
    }
}
