﻿#pragma checksum "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5F103AB4228ED70B39554FF99BD7DF4F83A262FEBD2079AD29B806E19851DADD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Presentation.UI.Commodity_Store;
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


namespace Presentation.UI.Commodity_Store {
    
    
    /// <summary>
    /// CreateStoreCommodityForm
    /// </summary>
    public partial class CreateStoreCommodityForm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_store;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb_commodity;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_stock;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_active;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_inactive;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/ui/commodity_store/createstorecommodityform.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml"
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
            this.cb_store = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.cb_commodity = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.txt_stock = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.rb_active = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rb_inactive = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            
            #line 82 "..\..\..\..\UI\Commodity_Store\CreateStoreCommodityForm.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
