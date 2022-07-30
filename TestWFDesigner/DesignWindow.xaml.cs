using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Activities.Presentation;
using System.Activities.Presentation.Model;
using System.Activities.Presentation.View;
using System.Activities.Presentation.Services;
using System.Activities.Core.Presentation;
using System.Activities.Presentation.Toolbox;
using System.Activities;
using System.Activities.Debugger;
using System.Activities.Statements;
using System.Activities.Presentation.Metadata;
using System.Reflection;
using System.IO;
using Bornander.UI.ViewModels;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    /// <summary>
    /// Логика взаимодействия для DesignWindow.xaml
    /// </summary>
    public partial class DesignWindow : UserControl
    {
        string workflowFilePathName = "tempRun.xaml";

        WorkflowDesigner designer;

        ModelEditingScope modelEditingScope;

        ModelItem rootModelItem;

        UndoEngine undoEngine;

        DesignerView designerView;

        ModelService modelService;

        ToolboxControl nodeToolboxControl;



        designerDebugTracking tracker;

        public DesignWindow()
        {
            InitializeComponent();

            (new DesignerMetadata()).Register();


            this.DataContext = this;

            SettingsViewModel svm = null;
            nodeToolboxControl = new ToolboxControl() { Categories = WpfApp_09_Style_TabControl.TestWFDesigner.toolBox.loadToolbox(out svm) };
            tree.DataContext = svm;
            cmb.DataContext = svm;

            tree.SelectedItemChanged += TreeOfCategories_SelectedItemChanged_A;
            tree.MouseMove += treeView_MouseMove_A;

            //nodePanel.Content = nodeToolboxControl;
        }

        private void Tree_MouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;

            if (menuItem == null)
            {
                return;
            }

            string menuItemValue = menuItem.Header.ToString();

            switch (menuItemValue)
            {
                //---------[Рабочий процесс ]---------------------

                case "Новый":
                    {
                        createWorkflowWindow createWorkflowWindow = new createWorkflowWindow();

                        createWorkflowWindow.ShowDialog();

                        if (!string.IsNullOrEmpty(createWorkflowWindow.templateName))
                        {
                            if(File.Exists(createWorkflowWindow.templateName))loadWorkflowFromFile(createWorkflowWindow.templateName);
                        }
                        createWorkflowWindow.Close();

                        workflowFilePathName = "tempRun.xaml";

                        //this.Title = "Дизайнер процессов: " + workflowFilePathName;
                    }
                    break;

                case "Открыть":
                    Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                    if (saveFileDialog.ShowDialog().Value)
                    {
                        designer.Save(saveFileDialog.FileName);
                        workflowFilePathName = saveFileDialog.FileName;
                        //this.Title = "Дизайнер процессов  -   " + workflowFilePathName;
                    }


                    break;

                case "Сохранить":
                    saveWorkflowToFile();
                    MessageBox.Show("Успешно сохранено");
                    break;


                //---------[подпроцесс ]---------------------
                case "Встроенный подпроцесс":

                    var list = designerTool.getSelectActivityList(designer);
                    Type type = typeof(System.Activities.Statements.Sequence);

                    foreach (var item in list)
                    {
                        if (item.ItemType == type)
                        {
                            openChildWorkflowWindow o = new openChildWorkflowWindow();
                            o.ShowDialog();
                            if (o.activity != null)
                            {
                                DynamicActivity d = o.activity as DynamicActivity;

                                if (d != null)
                                {
                                    foreach (var v in d.Properties)
                                    {
                                        if (v.Value is InArgument<string>)
                                        {
                                            Variable<string> t = new Variable<string>(v.Name);
                                            item.Properties["Variables"].Collection.Add(t);
                                        }



                                    }
                                    item.Properties["Activities"].Collection.Add(d.Implementation());

                                }
                                else
                                {
                                    item.Properties["Activities"].Collection.Add(o.activity);
                                }



                            }
                            o.Close();
                        }

                        break;

                    }
                    break;


                case "вставлять параметр":
                    (new addArgumentWindow(this.designer)).ShowDialog();
                    saveWorkflowToFile();//不Сохранить, параметр已Добавить к,但在Дизайнер процессов上不显示
                    break;

                //---------[действовать ]---------------------


                case "Удалить последний":
                    undoEngine.Undo();
                    break;

                case "Перестроить":
                    undoEngine.Redo();
                    break;

                case "Четкое отслеживание проектирования процессов":
                    desigeerActionList.Items.Clear();
                    break;





                //--------- [отладка] -----------------
                case "Run":

                    saveWorkflowToFile();
                    runWorkflow();

                    break;


                case "Очистить информацию об отслеживании":
                    trackingList.ItemsSource = null;
                    tracker.clearTrackInfo();
                    break;

                //--------- [Проверять] -----------------




                case "XAML":

                    (new Window() { Content = new TextBox() { Text = designer.Text, AcceptsReturn = true, HorizontalScrollBarVisibility = ScrollBarVisibility.Visible, VerticalScrollBarVisibility = ScrollBarVisibility.Visible } }).Show();
                    break;

                case "XAML(无ViewState)":

                    (new Window() { Content = new TextBox() { Text = tool.removeViewState(tool.activityBuilderFromXaml(designer.Text)), AcceptsReturn = true, HorizontalScrollBarVisibility = ScrollBarVisibility.Visible, VerticalScrollBarVisibility = ScrollBarVisibility.Visible } }).Show();
                    break;

                case "Обрабатывать информацию":
                    {
                        ListBox workflowInfo = new ListBox();

                        workflowInfo.Items.Add("Xaml File Path : " + designerTool.getXamlFilePath(designer));

                        workflowInfo.Items.Add("Activity Type : " + tool.activityByXaml(designer.Text).GetType().ToString());




                        (new Window() { Content = workflowInfo }).Show();
                    }
                    break;
                case "Блок-схема пользователя":
                    {
                        displayFlowcharControl f = new displayFlowcharControl();
                        f.showFlowchar(tool.getFlowcharStruct(designer.Text));
                        (new Window() { Content = f }).Show();
                    }
                    break;

                case "Run Информация":
                    (new Window() { Content = new runInfoControl() }).Show();
                    break;

                case "консольный вывод":
                    (new Window() { Content = new controlControl() }).Show();
                    break;


                //--------- [панель инструментов] -----------------

                case "Auto ExpandCollapse":
                    nodeToolboxControl.CategoryItemStyle = new System.Windows.Style(typeof(TreeViewItem))
                    {
                        Setters = { new Setter(TreeViewItem.IsExpandedProperty, false) }
                    };
                    break;
            } // end switch


        }//end

        void loadWorkflowFromFile(string workflowFilePathName)
        {

            desienerPanel.Content = null;
            propertyPanel.Content = null;

            designer = new WorkflowDesigner();


            try
            {
                designer.Load(workflowFilePathName);

                modelService = designer.Context.Services.GetService<ModelService>();

                rootModelItem = modelService.Root;

                undoEngine = designer.Context.Services.GetService<UndoEngine>();

                undoEngine.UndoUnitAdded += delegate (object ss, UndoUnitEventArgs ee)
                {
                    designer.Flush(); //调用Flush使designer.Text得到数据
                    desigeerActionList.Items.Add(string.Format("{0}  ,   {1}", DateTime.Now.ToString(), ee.UndoUnit.Description));
                };

                designerView = designer.Context.Services.GetService<DesignerView>();



                designerView.WorkflowShellBarItemVisibility = ShellBarItemVisibility.Arguments    //如果不使用Activity做根,无法出现 параметр选项
                                                              | ShellBarItemVisibility.Imports
                                                              | ShellBarItemVisibility.MiniMap
                                                              | ShellBarItemVisibility.Variables
                                                               | ShellBarItemVisibility.Zoom
                                                              ;

                desienerPanel.Content = designer.View;

                propertyPanel.Content = designer.PropertyInspectorView;


            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  //end

        void saveWorkflowToFile()
        {
            {
                if (workflowFilePathName == "tempRun.xaml")
                {
                    Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
                    if (saveFileDialog.ShowDialog().Value)
                    {
                        designer.Save(saveFileDialog.FileName);
                        workflowFilePathName = saveFileDialog.FileName;
                        //this.Title = "流程дизайн器  -   " + workflowFilePathName;
                    }
                }
                else
                {
                    designer.Save(workflowFilePathName);
                }

                loadWorkflowFromFile(workflowFilePathName);
            }
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {

        }

        WorkflowApplication instance = null;

        //-----------------------------------------------------

        public void runWorkflow()
        {
            List<string> key = new List<string>();


            DynamicActivity dynamicActivity = tool.activityByXaml(designer.Text) as DynamicActivity;

            foreach (var inArgumen in dynamicActivity.Properties)
            {

                if (inArgumen.Value is InArgument<string>)
                {

                    key.Add(inArgumen.Name);
                }

            }
            tracker = new designerDebugTracking(designer);

            trackingList.ItemsSource = tracker.trackingDataList;

            startWorkflowWindow startWorkflowWindow = new startWorkflowWindow(key);
            startWorkflowWindow.ShowDialog();

            switch (startWorkflowWindow.selectButtonValue)
            {
                case "начальный параметр":

                    instance = engineManager.createInstance(designer.Text, startWorkflowWindow.dictionary, tracker);

                    startWorkflowWindow.Close();
                    break;

                case "Запустить без параметров":
                    instance = engineManager.createInstance(designer.Text, null, tracker);

                    startWorkflowWindow.Close();
                    break;

                case "Отмена":

                    startWorkflowWindow.Close();
                    return;

                default:

                    startWorkflowWindow.Close();
                    return;
            }


            instance.Run();
        } //end

        //
        private void submit_Click(object sender, RoutedEventArgs e)
        {
            string bookName = bookmarkNameTextbox.Text;
            string inputValue = submitTextbox.Text;

            if (instance != null)
            {
                if (instance.GetBookmarks().Count(p => p.BookmarkName == bookName) == 1)
                {
                    instance.ResumeBookmark(bookName, inputValue);
                }
                else
                {
                    foreach (var v in instance.GetBookmarks())
                    {
                        System.Console.WriteLine("--------请从下面选项中选择一BookmarkName---------------------------");
                        System.Console.WriteLine("BookmarkName:{0}:,OwnerDisplayName:{1}", v.BookmarkName, v.OwnerDisplayName);
                        System.Console.WriteLine("================================");
                    }
                }
            }
            else
            {
                MessageBox.Show("Экземпляр не создан");
            }

        }//end

        private void trackingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        TreeNodeViewModel itemNode;
        void TreeOfCategories_SelectedItemChanged_A(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                //string ty = e.NewValue.GetType().Name;
                if (e.NewValue is TreeNodeViewModel)
                {
                    itemNode = e.NewValue as TreeNodeViewModel;
                }
            }

            catch
            {
            }

        }

        private void treeView_MouseMove_A(object sender, MouseEventArgs e)
        {
            try
            {

                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (itemNode == null) return;
                    var decisionType = itemNode.typeActivity;
                    if (decisionType == null) return;
                    DataObject _activityType = null;
                    if (decisionType.AssemblyQualifiedName != null)
                    {
                        _activityType = new DataObject(DragDropHelper.WorkflowItemTypeNameFormat, decisionType.AssemblyQualifiedName);
                    }

                    System.Windows.DragDrop.DoDragDrop((DependencyObject)e.Source, _activityType, DragDropEffects.Copy | DragDropEffects.Link);

                }
            }
            catch (Exception)
            {
            }
        }

    }
}
