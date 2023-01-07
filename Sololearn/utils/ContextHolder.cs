using SoloLearn.payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.utils
{
    public static class ContextHolder
    {

        public static UserDto? CurrentUser { get; set; }
    }
}
