using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
        sealed class TransitionData
        {

            public Activity<bool> Condition
            {
                get;
                set;
            }


            public Activity Action
            {
                get;
                set;
            }


            public InternalState To
            {
                get;
                set;
            }
        }
    }

