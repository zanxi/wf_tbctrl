using Bornander.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_09_Style_TabControl
{
    /// <summary>
    /// Логика взаимодействия для UserTree2.xaml
    /// </summary>
    /// 
    //  https://help.syncfusion.com/wpf/treeview/customizing-data-templates

    public partial class UserTree2 : UserControl
    {
        //SettingsViewModel settings; = new SettingsViewModel();
        public UserTree2()
        {
            InitializeComponent();

            var n1 = new TreeNodeViewModel("General", new[] {
                new TreeNodeViewModel("Appearance", new [] {
                    new TreeNodeViewModel("FontsAndColors.exe"),
                    new TreeNodeViewModel("LabelDecorations.txt")
                }),
                new TreeNodeViewModel("Compilers", new [] {
                    new TreeNodeViewModel("C#", new [] {
                        new TreeNodeViewModel("Binary.exe"),
                        new TreeNodeViewModel("ReadMe.txt"),
                        new TreeNodeViewModel("Image.jpg"),
                        new TreeNodeViewModel("Archive.zip")
                    }),
                    new TreeNodeViewModel("C++", new [] {
                        new TreeNodeViewModel("Binary.exe"),
                        new TreeNodeViewModel("Image.jpg"),
                        new TreeNodeViewModel("ReadMe.txt"),
                        new TreeNodeViewModel("Archive.zip")
                    }),
                    new TreeNodeViewModel("VB.NET", new [] {
                        new TreeNodeViewModel("Binary.exe"),
                        new TreeNodeViewModel("Image.jpg"),
                        new TreeNodeViewModel("ReadMe.txt"),
                        new TreeNodeViewModel("Archive.zip")
                    })
                })
            });


            var n2 = new TreeNodeViewModel("Run/Debug", new[] {
                new TreeNodeViewModel("Launching", new [] {
                    new TreeNodeViewModel("Launch configurations"),
                    new TreeNodeViewModel("Default launchers")
                }),
                new TreeNodeViewModel("Perspectives.jpg")
             });

            var settings = new SettingsViewModel(new[] { n1, n2 });
            //settings.

            //treeSearch.DataContext = settings;

            DataContext = settings;


            //DataContext = new ViewModel2();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                if (e.NewValue is TreeViewItem)
                {
                    TreeViewItem item = e.NewValue as TreeViewItem;                    
                    if (item != null)
                    {
                        TreeViewItem parentCategory = item.Parent as TreeViewItem;
                        if ((item.Parent as TreeViewItem) != null)
                        {
                            TreeViewItem parentCategory1 = parentCategory.Parent as TreeViewItem;
                            if ((parentCategory.Parent as TreeViewItem) != null)
                            {
                    
                            }
                        }
                    }
                }
                else
                {
                }
            }
            catch { }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //treeSearch.cle

            var n1 = new TreeNodeViewModel("FontsAndColors.exe");
            var settings = new SettingsViewModel();
            settings.Add(new[] { n1,n1,n1 });

            ObservableCollection<TreeNodeViewModel> child =
                new ObservableCollection<TreeNodeViewModel>();
            child.Add(new TreeNodeViewModel("423423"));
            child.Add(new TreeNodeViewModel("weer.jpg"));
            child.Add(new TreeNodeViewModel("3434.png"));
            child.Add(new TreeNodeViewModel("ertreter")); 

            var n2 = new TreeNodeViewModel("Fonts",child);
            var n3 =  new TreeNodeViewModel("FontsAndColors.exe", new[] { n2 });
            //n2.ad;
            
            settings.Add(new[] { n2 });
            settings.Add(new[] { n3 });


            cmb.DataContext = settings;
            tree.DataContext = settings;

            

        }
    }
}
