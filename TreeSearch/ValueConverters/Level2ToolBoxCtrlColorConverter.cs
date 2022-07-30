using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Bornander.UI.ViewModels;
using WpfApp_09_Style_TabControl;

namespace Bornander.UI.ValueConverters
{
    [ValueConversion(typeof(TreeNodeViewModel), typeof(ImageSource))]
    internal class Level2ToolBoxCtrlColorConverter : IValueConverter
    {

        static Level2ToolBoxCtrlColorConverter()
        {

        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return Binding.DoNothing;

            var viewModel = value as TreeNodeViewModel;
            if (viewModel == null)
                return Binding.DoNothing;
            if (viewModel.BitmapName == "") return Binding.DoNothing;
            return Binding.DoNothing;
            //return ToolBox.ColorBackground(ToolBox._ThemeName);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
            //throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(TreeNodeViewModel), typeof(ImageSource))]
    internal class Level2ToolBoxCtrlColorConverterFore : IValueConverter
    {

        static Level2ToolBoxCtrlColorConverterFore()
        {

        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return Binding.DoNothing;

            var viewModel = value as TreeNodeViewModel;
            if (viewModel == null)
                return Binding.DoNothing;
                        
            return new SolidColorBrush(Colors.BlueViolet);

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
            //throw new NotImplementedException();
        }
    }

}
