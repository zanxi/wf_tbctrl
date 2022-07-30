using System;
using System.Collections.Generic;
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

namespace WpfApp_09_Style_TabControl.TestWFDesigner
{
    /// <summary>
    /// Логика взаимодействия для nodeControl.xaml
    /// </summary>
    public partial class nodeControl : UserControl
    {
        public nodeControl()
        {
            InitializeComponent();
        }
        public nodeControl(node node)
        {
            InitializeComponent();
            showFlowchar(node);
        }

        void showFlowchar(node node)
        {
            this.Background = System.Windows.Media.Brushes.Red;
            Canvas.SetLeft(this, node.ShapeSize.x);
            Canvas.SetTop(this, node.ShapeSize.y);
            this.Width = node.ShapeSize.width;
            this.Height = node.ShapeSize.height;
            this.displayName.Text = node.DisplayName;
        }
    }
}
