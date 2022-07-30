﻿using System;
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
    /// Логика взаимодействия для runInfoControl.xaml
    /// </summary>
    public partial class runInfoControl : UserControl
    {
        public runInfoControl()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(runInfoControl_Loaded);
        }

        void runInfoControl_Loaded(object sender, RoutedEventArgs e)
        {
            runInfoDataGrid.ItemsSource = null;
            runInfoDataGrid.ItemsSource = engineManager.runInfoList.ToList();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            engineManager.runInfoList.Clear();
            runInfoDataGrid.ItemsSource = null;
            runInfoDataGrid.ItemsSource = engineManager.runInfoList.ToList();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            runInfoDataGrid.ItemsSource = null;
            runInfoDataGrid.ItemsSource = engineManager.runInfoList.ToList();
        }
    }
}
