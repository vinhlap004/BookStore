﻿#pragma checksum "..\..\..\UserControls\Sale_Report_UserControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A085EDE2298EDC19AC9956151D35BC48BC7A856389F49283A82EB5CE6A0BCCD3"
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
    /// Sale_Report_UserControl
    /// </summary>
    public partial class Sale_Report_UserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton DateMode;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton MonthMode;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton YearMode;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton TotalMode;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AmountSold_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RevenueWithTax_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RevenueWithoutTax_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Profit_TextBlock;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView SaleReport_ListView;
        
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
            System.Uri resourceLocater = new System.Uri("/Bookstore;component/usercontrols/sale_report_usercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
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
            this.DateMode = ((System.Windows.Controls.RadioButton)(target));
            
            #line 15 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
            this.DateMode.Checked += new System.Windows.RoutedEventHandler(this.DateMode_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MonthMode = ((System.Windows.Controls.RadioButton)(target));
            
            #line 16 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
            this.MonthMode.Checked += new System.Windows.RoutedEventHandler(this.MonthMode_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.YearMode = ((System.Windows.Controls.RadioButton)(target));
            
            #line 17 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
            this.YearMode.Checked += new System.Windows.RoutedEventHandler(this.YearMode_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TotalMode = ((System.Windows.Controls.RadioButton)(target));
            
            #line 18 "..\..\..\UserControls\Sale_Report_UserControl.xaml"
            this.TotalMode.Checked += new System.Windows.RoutedEventHandler(this.TotalMode_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AmountSold_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.RevenueWithTax_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.RevenueWithoutTax_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.Profit_TextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.SaleReport_ListView = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

