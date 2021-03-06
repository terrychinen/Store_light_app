﻿#pragma checksum "..\..\..\..\UI\Input\UpdateInputForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D5A95ECCA893A5406DE6FB6C4294C7AE5CDB38D0F96335DE9342C32618F56757"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Presentation.UI.Input;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Presentation.UI.Input {
    
    
    /// <summary>
    /// UpdateInputForm
    /// </summary>
    public partial class UpdateInputForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox commodityListBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label cb_provider;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker input_date;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_message;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox commodityStoreListBox;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label txt_total_price;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Presentation;component/ui/input/updateinputform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.commodityListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 67 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
            this.commodityListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.commodityListBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cb_provider = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.input_date = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 4:
            this.txt_message = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.commodityStoreListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 153 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
            this.commodityStoreListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.commodityStoreListBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.txt_total_price = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            
            #line 191 "..\..\..\..\UI\Input\UpdateInputForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

