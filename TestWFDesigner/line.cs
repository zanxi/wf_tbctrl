using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    public class line
    {
        public line()
        {
            connectorPoint = new List<point>();
        }

        public List<point> connectorPoint { set; get; }

        public string beginNodeID { set; get; }

        public string endNodeID { set; get; }

        public string text { set; get; }

    }

    public class point
    {
        public double x { set; get; }
        public double y { set; get; }
    }
}
