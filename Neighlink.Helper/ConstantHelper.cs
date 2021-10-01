using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neighlink.Helper
{
    public static class ConstantHelper
    {
        public const string CONSTRUCTOR_DTO_SINGLE = "SIN";
        public const string CONSTRUCTOR_DTO_LIST = "LST";

        public const string API_PREFIX = "api";

        public const string NOT_FOUND_PARAMETERS_SEPARATOR = " -> ";

        public const string PRODUCT_STATUS_ACTIVATE = "ACT";

        public static string ToSafeString(this object obj, string defStr = "") => obj?.ToString() ?? defStr;
    }
}
