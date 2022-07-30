using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.Runtime.Serialization;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    [DataContract]
    public class TriggerCompletedEvent
    {

        [DataMember]
        public int TriggedId
        {
            get;
            set;
        }

        [DataMember]
        public Bookmark Bookmark
        {
            get;
            set;
        }
    }
}
