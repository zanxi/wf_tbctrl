using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    /// <summary>
    /// Логика взаимодействия для createWorkflowWindow.xaml
    /// </summary>
    public partial class createWorkflowWindow : Window
    {
        public createWorkflowWindow()
        {
            InitializeComponent();

            loadTemplate();
        }

        void loadTemplate()
        {
            templateListBox.Items.Add(@"TestWFDesigner\activityBuilder.xaml");
            templateListBox.Items.Add(@"C:\_downloads__\activityBuilder.xaml");
            //templateListBox.Items.Add(@"template\状态机.xaml");
            //templateListBox.Items.Add(@"template\流程图.xaml");

            //templateInfo.Text = tool.xamlFromFile(@"TestWFDesigner\readme.txt");
        }

        public string templateName = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
            {
                return;
            }

            string buttonValue = button.Content.ToString();

            switch (buttonValue)
            {
                case "Отмена":
                    templateName = "";
                    this.Visibility = System.Windows.Visibility.Hidden;
                    break;


                case "Build":
                    if (templateListBox.SelectedItem != null)
                    {
                        templateName = templateListBox.SelectedItem.ToString();
                        if (!File.Exists(templateName)) ;

                        this.Visibility = System.Windows.Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Пожалуйста, выберите шаблон");
                    }
                    break;

            }


        }

        private void templateListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (templateListBox.SelectedItem != null)
            {
                templateInfo.Text = "Загрузите шаблон";//tool.xamlFromFile(templateListBox.SelectedItem.ToString() + ".txt");
            }
        }



    }
}
