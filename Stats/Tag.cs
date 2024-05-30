using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akaha_Gesture.Stats
{
    public class Tag
    {
        public int id { get; set; }
        public string tag { get; set; }

        public List<Session> sessions { get; set; }
    }
}
