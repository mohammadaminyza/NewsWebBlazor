using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorNews.Core.Generators
{
    public static class GuidGenerate
    {
        public static string GuidGenerator()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
