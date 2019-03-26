﻿#pragma checksum "..\..\..\..\View\WPF\DataPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CDA584B791CCB755BEBA8FD2EE5C0ECF3ED1115D"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using code.View.WPF;
using code.ViewModel;


namespace code.View.WPF {
    
    
    /// <summary>
    /// DataPanel
    /// </summary>
    public partial class DataPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\View\WPF\DataPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer DataTempletScrollViewer;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\WPF\DataPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView DataTempletTree;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\View\WPF\DataPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InsertButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\View\WPF\DataPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveTemplateButton;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\View\WPF\DataPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BookmarkHeader;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\View\WPF\DataPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InsertBookmark;
        
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
            System.Uri resourceLocater = new System.Uri("/code;component/view/wpf/datapanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\WPF\DataPanel.xaml"
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
            this.DataTempletScrollViewer = ((System.Windows.Controls.ScrollViewer)(target));
            
            #line 42 "..\..\..\..\View\WPF\DataPanel.xaml"
            this.DataTempletScrollViewer.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.DataTempletScrollViewer_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataTempletTree = ((System.Windows.Controls.TreeView)(target));
            return;
            case 3:
            this.InsertButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\View\WPF\DataPanel.xaml"
            this.InsertButton.Click += new System.Windows.RoutedEventHandler(this.InsertButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SaveTemplateButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\..\View\WPF\DataPanel.xaml"
            this.SaveTemplateButton.Click += new System.Windows.RoutedEventHandler(this.SaveTemplateButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BookmarkHeader = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.InsertBookmark = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\View\WPF\DataPanel.xaml"
            this.InsertBookmark.Click += new System.Windows.RoutedEventHandler(this.InsertBookmark_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

