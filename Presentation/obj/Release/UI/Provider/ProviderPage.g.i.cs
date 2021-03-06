﻿#pragma checksum "..\..\..\..\UI\Provider\ProviderPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "91FDE3C72E5CC5A7F4C3FA2AA6ABAB21FE6F4FD8D49B109FF1BE862580BB7065"
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
using Presentation.UI.Provider;
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


namespace Presentation.UI.Provider {
    
    
    /// <summary>
    /// ProviderPage
    /// </summary>
    public partial class ProviderPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\UI\Provider\ProviderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\UI\Provider\ProviderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_id;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\UI\Provider\ProviderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_name;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\UI\Provider\ProviderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_ruc;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\UI\Provider\ProviderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_address;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\UI\Provider\ProviderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_phone;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\UI\Provider\ProviderPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox providerListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/ui/provider/providerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Provider\ProviderPage.xaml"
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
            this.txt_search = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\UI\Provider\ProviderPage.xaml"
            this.txt_search.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Search_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rb_id = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.rb_name = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.rb_ruc = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rb_address = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rb_phone = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            
            #line 63 "..\..\..\..\UI\Provider\ProviderPage.xaml"
            ((System.Windows.Controls.Grid)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.ProviderListBox_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.providerListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            
            #line 123 "..\..\..\..\UI\Provider\ProviderPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateProvider_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

