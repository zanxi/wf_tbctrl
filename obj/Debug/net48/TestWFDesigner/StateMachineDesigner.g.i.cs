// Updated by XamlIntelliSenseFileGenerator 30.07.2022 14:25:49
#pragma checksum "..\..\..\..\TestWFDesigner\StateMachineDesigner.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C05BE9A757FB517C243FD14D9CD99B7EC3A525C8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Machine;
using Machine.Design;
using Machine.Design.FreeFormEditing;
using System;
using System.Activities;
using System.Activities.Presentation;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace XHEActivity_Editor.ToolBoxCtrl.TestWFDesigner
{


    /// <summary>
    /// StateMachineDesigner
    /// </summary>
    public partial class StateMachineDesigner : System.Activities.Presentation.ActivityDesigner, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden


#line 64 "..\..\..\..\TestWFDesigner\StateMachineDesigner.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContentPresenter stateMachineContentPresenter;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp_09_Style_TabControl;V1.0.0.0;component/testwfdesigner/statemachinedesigne" +
                    "r.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\TestWFDesigner\StateMachineDesigner.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.stateMachineDesigner = ((XHEActivity_Editor.ToolBoxCtrl.TestWFDesigner.StateMachineDesigner)(target));
                    return;
                case 2:

#line 45 "..\..\..\..\TestWFDesigner\StateMachineDesigner.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.stateMachineContentPresenter = ((System.Windows.Controls.ContentPresenter)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Activities.Presentation.ActivityDesigner stateMachineDesigner;
    }
}

