﻿#pragma checksum "..\..\..\UserControls\Manager_Account_UserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CB9CC4E17ED70626B2DB8BFD2FF488C70994E9D7409CCB354BCC0763BECF21B7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bookstore.UserControls;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Bookstore.UserControls {
    
    
    /// <summary>
    /// Manager_Account_UserControl
    /// </summary>
    public partial class Manager_Account_UserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_Account;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditAccount_Button;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteAccount_Button;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ManagerAccount_ListView;
        
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
            System.Uri resourceLocater = new System.Uri("/Bookstore;component/usercontrols/manager_account_usercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
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
            
            #line 8 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
            ((Bookstore.UserControls.Manager_Account_UserControl)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Add_Account = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
            this.Add_Account.Click += new System.Windows.RoutedEventHandler(this.Add_Account_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditAccount_Button = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
            this.EditAccount_Button.Click += new System.Windows.RoutedEventHandler(this.EditAccount_Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeleteAccount_Button = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
            this.DeleteAccount_Button.Click += new System.Windows.RoutedEventHandler(this.DeleteAccount_Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ManagerAccount_ListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 6:
            
            #line 27 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\..\UserControls\Manager_Account_UserControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

