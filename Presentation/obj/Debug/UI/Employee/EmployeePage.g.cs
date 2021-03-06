﻿#pragma checksum "..\..\..\..\UI\Employee\EmployeePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "70057DB4DC6F665A7F6400F4F3FD7F65612C1801D429D05F9B141B00FF5CB0EF"
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
using Presentation.UI.Employee;
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


namespace Presentation.UI.Employee {
    
    
    /// <summary>
    /// EmployeePage
    /// </summary>
    public partial class EmployeePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\UI\Employee\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\UI\Employee\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_id;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\UI\Employee\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_name;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\UI\Employee\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rb_username;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\UI\Employee\EmployeePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox employeeListBox;
        
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
            System.Uri resourceLocater = new System.Uri("/Presentation;component/ui/employee/employeepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\Employee\EmployeePage.xaml"
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
            
            #line 39 "..\..\..\..\UI\Employee\EmployeePage.xaml"
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
            this.rb_username = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.employeeListBox = ((System.Windows.Controls.ListBox)(target));
            
            #line 71 "..\..\..\..\UI\Employee\EmployeePage.xaml"
            this.employeeListBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.EmployeeListBox_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 100 "..\..\..\..\UI\Employee\EmployeePage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateEmployee_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

