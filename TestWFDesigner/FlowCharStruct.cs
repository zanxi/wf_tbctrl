using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    public class flowcharStruct
    {
        public flowcharStruct()
        {
            nodeList = new List<node>();
            lineList = new List<line>();
            beginNode = new node();
            endNode = new node();
        }

        public node beginNode { set; get; }

        public node endNode { set; get; }

        public List<node> nodeList { set; get; }

        public List<line> lineList { set; get; }
    }
}