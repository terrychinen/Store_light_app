﻿#pragma checksum "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "164AC9E1016A1AAD0E60699DDDBF6EB0308229B0826DF30D38513A1FA9EF222A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Presentation.UI.Order;
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
using Xceed.Wpf.Toolkit.Chart;
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


namespace Presentation.UI.Order {
    
    
    /// <summary>
    /// UpdatePurchaseOrderForm
    /// </summary>
    public partial class UpdatePurchaseOrderForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_commodity;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal FontAwesome.WPF.ImageAwesome spin;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox commodityListBox;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_provider;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker order_date;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker expected_date;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.DateTimePicker receive_date;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_pending;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_waiting;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_received;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_cancel;
        
        #line default
        #line hidden
        
        
        #line 158 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_message;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/ui/order/updatepurchaseorderform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
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
            this.cb_commodity = ((System.Windows.Controls.ComboBox)(target));
            
            #line 41 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
            this.cb_commodity.KeyDown += new System.Windows.Input.KeyEventHandler(this.cb_commodity_KeyDown);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
            this.cb_commodity.KeyUp += new System.Windows.Input.KeyEventHandler(this.cb_commodity_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 42 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddQuantity_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.spin = ((FontAwesome.WPF.ImageAwesome)(target));
            return;
            case 4:
            
            #line 49 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
            ((System.Windows.Controls.Grid)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Grid_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.commodityListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.cb_provider = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.order_date = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 8:
            this.expected_date = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 9:
            this.receive_date = ((Xceed.Wpf.Toolkit.DateTimePicker)(target));
            return;
            case 10:
            this.rb_pending = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this.rb_waiting = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 12:
            this.rb_received = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 13:
            this.rb_cancel = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 14:
            this.txt_message = ((System.Windows.Controls.TextBox)(target));
            return;
            case 15:
            this.txt_total_price = ((System.Windows.Controls.Label)(target));
            return;
            case 16:
            
            #line 174 "..\..\..\..\UI\Order\UpdatePurchaseOrderForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
