using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ComponentModel;


namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
        public sealed class EndActivity : CodeActivity
        {
            public System.Activities.InArgument<string> s
            { set; get; }

            protected override void Execute(CodeActivityContext context)
            {
                try
                {
                    Guid FlowInstranceID = context.WorkflowInstanceId;
                    string result = s.Get(context);
                    if (FlowInstranceID != null)
                    {
                        if (result == "true")
                        {
                            BLL.Document.DocumentEndStep(FlowInstranceID, "1");
                        }
                        else
                        {
                            BLL.Document.DocumentEndStep(FlowInstranceID, "2");
                        }
                    }
                }
                catch (Exception e)
                {
                //execution error
            }
        }
        }

    }
