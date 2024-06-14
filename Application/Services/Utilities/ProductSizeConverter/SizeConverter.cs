using BusinessLogic.Interfaces.Services.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Utilities.ProductSizeConverter
{
    public class SizeConverter: ISizeConverter
    {
        private Dictionary<long, string> sizeMap;

        public SizeConverter()
        {
            sizeMap = new Dictionary<long, string>
        {
            { 1, "XS" },
            { 2, "S" },
            { 3, "M" },
            { 4, "L" },
            { 5, "XL" }
        };
        }

        public string GetSizeString(long id)
        {
            if (sizeMap.ContainsKey(id))
            {
                return sizeMap[id];
            }
            else
            {
                throw new ArgumentException("Invalid size id");
            }
        }
    }
}
