using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoADO.models
{
    public class Section
    {
        public int Id { get; set; }
        public string SectionName { get; set; }

        public Section(int id, string sectionName)
        {
            Id = id;
            SectionName = sectionName;
        }
    }
}
