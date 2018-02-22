using Songs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Songs.Web.ViewModels.Singers
{
    public class IndexViewModel
    {
        public List<Person> Singers { get; set; }
    }
}
