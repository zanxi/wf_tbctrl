using System;
using System.Data;

namespace WpfApp_09_Style_TabControl.TestWFDesigner.BLL
{

        public class Document
        {
            public static int DocumentAdd(Model.Document documentinfo)
            {
                return DAL.Document.DocumentAdd(documentinfo);
            }

            public static int DocumentUpdate(Model.Document documentinfo)
            {
                return DAL.Document.DocumentUpdate(documentinfo);
            }

            public static int DocumentDel(string ID)
            {
                return DAL.Document.DocumentDel(ID);
            }

            public static int PublicDocument(string ID)
            {
                return DAL.Document.PublicDocument(ID);
            }

            public static int DocumentEndStep(Guid FlowID, string result)
            {
                return DAL.Document.DocumentEndStep(FlowID, result);
            }

            public static int DocumentStep(Guid FlowID, string StepID)
            {
                return DAL.Document.DocumentStep(FlowID, StepID);
            }
        }
    }


