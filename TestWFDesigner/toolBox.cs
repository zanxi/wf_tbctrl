using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities.Presentation.Metadata;
using System.Reflection;
using System.Activities.Presentation.Toolbox;
//using ActivityLibrary;
using System.IO;
using Bornander.UI.ViewModels;
using System.Collections.ObjectModel;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    public class toolBox
    {
        public static void loadSystemIcon()
        {
            AttributeTableBuilder builder = new AttributeTableBuilder();

            string str = System.Environment.CurrentDirectory + @"\Microsoft.VisualStudio.Activities.dll";
            Assembly sourceAssembly = Assembly.LoadFile(str);


            System.Resources.ResourceReader resourceReader = new System.Resources.ResourceReader(sourceAssembly.GetManifestResourceStream("Microsoft.VisualStudio.Activities.Resources.resources"));
            foreach (Type type in typeof(System.Activities.Activity).Assembly.GetTypes())
            {
                //if (type.Namespace == "System.Activities.Statements")
                if (type.Namespace == "System.Activities.Expressions")
                {
                    createImageToActivity(builder, resourceReader, type);
                }
            }
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        private static void createImageToActivity(AttributeTableBuilder builder, System.Resources.ResourceReader resourceReader, Type builtInActivityType)
        {
            {
                string bmpName = builtInActivityType.IsGenericType ? builtInActivityType.Name.Split('`')[0] : builtInActivityType.Name;
                System.Drawing.Bitmap bitmap = getImageFromResource(resourceReader, bmpName);
                //bitmap.Save(@"C:\_2022___\_Rabota__Bizaps__Src___Inet__2__\document-management-master\" + "0"+(i++)+".bmp");
                if (bitmap != null)
                {
                    Type tbaType = typeof(System.Drawing.ToolboxBitmapAttribute);
                    Type imageType = typeof(System.Drawing.Image);
                    ConstructorInfo constructor = tbaType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[] { imageType, imageType }, null);
                    System.Drawing.ToolboxBitmapAttribute tba = constructor.Invoke(new object[] { bitmap, bitmap }) as System.Drawing.ToolboxBitmapAttribute;
                    builder.AddCustomAttributes(builtInActivityType, tba);
                    //bitmap.Save(@"C:\_2022___\_Rabota__Bizaps__Src___Inet__2__\document-management-master\" + "0" + (i++) + ".bmp");
                    //bitmap.Save(@"C:\_2022___\_Rabota__Bizaps__Src___2__\_Icons_Activity__\" + bmpName + ".bmp");

                    //File.AppendAllText(@"C:\_2022___\_Rabota__Bizaps__Src___Inet__2__\document-management-master\datawf.txt",
                    //    tbaType.ToString()+ " | " + tba.ToString() + " | " + builtInActivityType.ToString() + " | " + " | " + " | " + " |\n\n ");

                    //File.AppendAllText(@"C:\_2022___\_Rabota__Bizaps__Src___2__\_Icons_Activity__\datawf.txt",
                    //    tbaType.ToString() + " | " + tba.ToString() + " | " + builtInActivityType.ToString() + " | " + " | " + " | " + " |\n\n ");
                    //"C:\_2022___\_Rabota__Bizaps__Src___2__\_Icons_Activity__ "

                }
            }
        }

        private static System.Drawing.Bitmap getImageFromResource(System.Resources.ResourceReader resourceReader, string bitmapName)
        {
            System.Collections.IDictionaryEnumerator dictEnum = resourceReader.GetEnumerator();
            System.Drawing.Bitmap bitmap = null;
            while (dictEnum.MoveNext())
            {
                if (String.Equals(dictEnum.Key, bitmapName))
                {
                    bitmap = dictEnum.Value as System.Drawing.Bitmap;
                    System.Drawing.Color pixel = bitmap.GetPixel(bitmap.Width - 1, 0);
                    bitmap.MakeTransparent(pixel);
                    break;
                }
            }
            return bitmap;
        }

        static void addNode(ObservableCollection<TreeNodeViewModel> child, Type ty)
        {
            string bmpName = ty.IsGenericType ? ty.Name.Split('`')[0] : ty.Name;
            TreeNodeViewModel tn = new TreeNodeViewModel(bmpName);
            tn.typeActivity = ty;              
            tn.BitmapName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Settings\\_IconsA\\" + bmpName + ".bmp");
            child.Add(tn);
        }
    


        public static ToolboxCategoryItems loadToolbox(out SettingsViewModel svm)
        {
            loadSystemIcon();

            ObservableCollection<TreeNodeViewModel> child = 
                new ObservableCollection<TreeNodeViewModel>();
            //SettingsViewModel svm = new SettingsViewModel();
            svm = null;
            svm = new SettingsViewModel();

            ToolboxCategoryItems toolboxCategoryItems = new ToolboxCategoryItems();

            addNode(child, typeof(System.Activities.Statements.Flowchart));
            ToolboxItemWrapper flowchar = new ToolboxItemWrapper(typeof(System.Activities.Statements.Flowchart), "Flowchart");
            addNode(child, typeof(System.Activities.Statements.FlowDecision));
            ToolboxItemWrapper flowDecision = new ToolboxItemWrapper(typeof(System.Activities.Statements.FlowDecision), "FlowDecision");
            addNode(child, typeof(System.Activities.Statements.FlowSwitch<string>));
            ToolboxItemWrapper flowSwitch = new ToolboxItemWrapper(typeof(System.Activities.Statements.FlowSwitch<string>), "FlowSwitch");

            ToolboxCategory wf4Flowchar = new System.Activities.Presentation.Toolbox.ToolboxCategory("flow chart");

            wf4Flowchar.Add(flowchar);
            wf4Flowchar.Add(flowDecision);
            wf4Flowchar.Add(flowSwitch);

            var n2 = new TreeNodeViewModel("flow chart", child);
            svm.Add(new[] { n2 });
            child.Clear();
            
            toolboxCategoryItems.Add(wf4Flowchar);

            //状态机            
            addNode(child, typeof(StateMachineWithInitialStateFactory));
            //addNode(child, typeof());
            ToolboxItemWrapper stateMachineWithInitialStateFactory = 
                new ToolboxItemWrapper(typeof(StateMachineWithInitialStateFactory), "процесс конечного автомата");
            addNode(child, typeof(WpfApp_09_Style_TabControl.TestWFDesigner.State));
            ToolboxItemWrapper state = new ToolboxItemWrapper(typeof(WpfApp_09_Style_TabControl.TestWFDesigner.State), "узел");            
            ToolboxCategory stateMachineActivity = new System.Activities.Presentation.Toolbox.ToolboxCategory("Государственный аппарат");

            stateMachineActivity.Add(stateMachineWithInitialStateFactory);
            stateMachineActivity.Add(state);

            var n3 = new TreeNodeViewModel("Государственный аппарат", child);
            svm.Add(new[] { n3 });
            child.Clear();

            toolboxCategoryItems.Add(stateMachineActivity);




            //WF4.0 Activity
            //addNode(child, typeof(System.Activities.Statements.));
            addNode(child, typeof(System.Activities.Statements.WriteLine));
            ToolboxItemWrapper writeLine = new ToolboxItemWrapper(typeof(System.Activities.Statements.WriteLine), "WriteLine");
            addNode(child, typeof(System.Activities.Statements.Sequence));
            ToolboxItemWrapper sequence = new ToolboxItemWrapper(typeof(System.Activities.Statements.Sequence), "Sequence");
            addNode(child, typeof(System.Activities.Statements.Assign));
            ToolboxItemWrapper Assign = new ToolboxItemWrapper(typeof(System.Activities.Statements.Assign), "Assign");
            addNode(child, typeof(System.Activities.Statements.Delay));
            ToolboxItemWrapper Delay = new ToolboxItemWrapper(typeof(System.Activities.Statements.Delay), "Delay");
            addNode(child, typeof(System.Activities.Statements.If));
            ToolboxItemWrapper If = new ToolboxItemWrapper(typeof(System.Activities.Statements.If), "If");
            addNode(child, typeof(System.Activities.Statements.ForEach<string>));
            ToolboxItemWrapper ForEach = new ToolboxItemWrapper(typeof(System.Activities.Statements.ForEach<string>), "ForEach");
            addNode(child, typeof(System.Activities.Statements.Switch<string>));
            ToolboxItemWrapper Switch = new ToolboxItemWrapper(typeof(System.Activities.Statements.Switch<string>), "Switch");
            addNode(child, typeof(System.Activities.Statements.While));
            ToolboxItemWrapper While = new ToolboxItemWrapper(typeof(System.Activities.Statements.While), "While");
            addNode(child, typeof(System.Activities.Statements.DoWhile));
            ToolboxItemWrapper DoWhile = new ToolboxItemWrapper(typeof(System.Activities.Statements.DoWhile), "DoWhile");
            addNode(child, typeof(System.Activities.Statements.Parallel));
            ToolboxItemWrapper Parallel = new ToolboxItemWrapper(typeof(System.Activities.Statements.Parallel), "Parallel");
            addNode(child, typeof(System.Activities.Statements.Pick));
            ToolboxItemWrapper Pick = new ToolboxItemWrapper(typeof(System.Activities.Statements.Pick), "Pick");
            addNode(child, typeof(System.Activities.Statements.PickBranch));
            ToolboxItemWrapper PickBranch = new ToolboxItemWrapper(typeof(System.Activities.Statements.PickBranch), "PickBranch");


            ToolboxCategory wf4Activity = new System.Activities.Presentation.Toolbox.ToolboxCategory("Activity");
            
            wf4Activity.Add(writeLine);
            wf4Activity.Add(sequence);
            wf4Activity.Add(Assign);
            wf4Activity.Add(Delay);
            wf4Activity.Add(If);
            wf4Activity.Add(ForEach);
            wf4Activity.Add(Switch);
            wf4Activity.Add(While);
            wf4Activity.Add(DoWhile);
            wf4Activity.Add(Parallel);
            wf4Activity.Add(Pick);
            wf4Activity.Add(PickBranch);


            var n4 = new TreeNodeViewModel("Activity", child);
            svm.Add(new[] { n4 });
            child.Clear();

            toolboxCategoryItems.Add(wf4Activity);


            //文档活动
            //ToolboxItemWrapper StartActivity = new ToolboxItemWrapper(typeof(StartActivity), "начать событие");
            //addNode(child, typeof());
            addNode(child, typeof(DocActivity));
            ToolboxItemWrapper DocActivity = new ToolboxItemWrapper(typeof(DocActivity), "утверждение документа");
            addNode(child, typeof(EndActivity));
            ToolboxItemWrapper EndActivity = new ToolboxItemWrapper(typeof(EndActivity), "конечное событие");
            ToolboxCategory DocActivitys = new System.Activities.Presentation.Toolbox.ToolboxCategory("Документация");
            //DocActivitys.Add(StartActivity);
            DocActivitys.Add(DocActivity);
            DocActivitys.Add(EndActivity);

            var n5 = new TreeNodeViewModel("Документация", child);
            svm.Add(new[] { n5 });
            child.Clear();

            toolboxCategoryItems.Add(DocActivitys);

            return toolboxCategoryItems;

        }
    }
}
