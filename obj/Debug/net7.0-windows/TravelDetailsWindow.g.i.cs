﻿#pragma checksum "..\..\..\TravelDetailsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49613562EF5A51C76A229E7A2F9416BEE3509460"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
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
using TravelPal;
using TravelPal.ViewModels;


namespace TravelPal {
    
    
    /// <summary>
    /// TravelDetailsWindow
    /// </summary>
    public partial class TravelDetailsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPackingList;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvTravelSelected;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvTravelPackList;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTravelInfo;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditTravel;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveTravel;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveItem;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\TravelDetailsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TravelPal;component/traveldetailswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TravelDetailsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lblPackingList = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lvTravelSelected = ((System.Windows.Controls.ListView)(target));
            
            #line 59 "..\..\..\TravelDetailsWindow.xaml"
            this.lvTravelSelected.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvTravelSelected_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lvTravelPackList = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.tbxTravelInfo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnEditTravel = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\TravelDetailsWindow.xaml"
            this.btnEditTravel.Click += new System.Windows.RoutedEventHandler(this.btnEditTravel_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnRemoveTravel = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\TravelDetailsWindow.xaml"
            this.btnRemoveTravel.Click += new System.Windows.RoutedEventHandler(this.btnRemoveTravel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnRemoveItem = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\..\TravelDetailsWindow.xaml"
            this.btnRemoveItem.Click += new System.Windows.RoutedEventHandler(this.btnRemoveItem_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 140 "..\..\..\TravelDetailsWindow.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

