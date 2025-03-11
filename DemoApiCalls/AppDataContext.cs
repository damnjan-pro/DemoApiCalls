using DemoApiCalls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApiCalls
{
    public class AppDataContext
    {
        public Layouts CurrentLayout { get; set; } = Layouts.single;
    }
}
