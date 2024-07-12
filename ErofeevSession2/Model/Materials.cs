using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErofeevSession2.Model
{
   public partial class Material
    {
        public string ColorType
        {
            get
            {
                if (CountInStock < MinCount)
                    return "#f19292";
                if (CountInStock > MinCount * 3)
                    return "#ffba01";
                else
                    return "White";
            }
        }
        public string Supplier
        {
            get
            {
                string result = String.Empty;
                foreach (var x in MaterialSupplier)
                {
                    if (result != String.Empty)
                        result += ", ";
                    result += x.Supplier.Title;
                }
                if (result == String.Empty)
                    result = "Поставщиков нет";
                return result;
            }
        }
    }
}
