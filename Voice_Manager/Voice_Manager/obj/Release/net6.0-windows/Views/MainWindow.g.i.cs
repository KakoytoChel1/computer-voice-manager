﻿#pragma checksum "..\..\..\..\Views\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "495AEC1AA15DFE4930B685BC909FF4F898BA8AB9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hardcodet.Wpf.TaskbarNotification;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using Voice_Manager;
using Voice_Manager.Models;
using Voice_Manager.ViewModels;


namespace Voice_Manager {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Voice_Manager.MainWindow window;
        
        #line default
        #line hidden
        
        
        #line 301 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textMessageBox;
        
        #line default
        #line hidden
        
        
        #line 470 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FileNothing;
        
        #line default
        #line hidden
        
        
        #line 494 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox fileListBox;
        
        #line default
        #line hidden
        
        
        #line 611 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border AddFileItemMenu;
        
        #line default
        #line hidden
        
        
        #line 673 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilePath;
        
        #line default
        #line hidden
        
        
        #line 728 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FileCommand;
        
        #line default
        #line hidden
        
        
        #line 796 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border EditFileItemMenu;
        
        #line default
        #line hidden
        
        
        #line 859 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FilePathEdit;
        
        #line default
        #line hidden
        
        
        #line 914 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FileCommandEdit;
        
        #line default
        #line hidden
        
        
        #line 995 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SiteNothing;
        
        #line default
        #line hidden
        
        
        #line 1019 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox siteListBox;
        
        #line default
        #line hidden
        
        
        #line 1136 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border AddSiteItemMenu;
        
        #line default
        #line hidden
        
        
        #line 1199 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteUrl;
        
        #line default
        #line hidden
        
        
        #line 1254 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteCommand;
        
        #line default
        #line hidden
        
        
        #line 1322 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border EditSiteItemMenu;
        
        #line default
        #line hidden
        
        
        #line 1386 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteUrlEdit;
        
        #line default
        #line hidden
        
        
        #line 1441 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SiteCommandEdit;
        
        #line default
        #line hidden
        
        
        #line 1522 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AnswerNothing;
        
        #line default
        #line hidden
        
        
        #line 1546 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox answerListBox;
        
        #line default
        #line hidden
        
        
        #line 1662 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border AddAnswerItemMenu;
        
        #line default
        #line hidden
        
        
        #line 1725 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AssistantAnswer;
        
        #line default
        #line hidden
        
        
        #line 1780 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnswerCommand;
        
        #line default
        #line hidden
        
        
        #line 1848 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border EditAnswerItemMenu;
        
        #line default
        #line hidden
        
        
        #line 1912 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnswerEdit;
        
        #line default
        #line hidden
        
        
        #line 1967 "..\..\..\..\Views\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnswerCommandEdit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Voice_Manager;component/views/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.window = ((Voice_Manager.MainWindow)(target));
            return;
            case 2:
            
            #line 41 "..\..\..\..\Views\MainWindow.xaml"
            ((Hardcodet.Wpf.TaskbarNotification.TaskbarIcon)(target)).TrayLeftMouseDown += new System.Windows.RoutedEventHandler(this.TaskbarIcon_TrayLeftMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 89 "..\..\..\..\Views\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 90 "..\..\..\..\Views\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textMessageBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.FileNothing = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.fileListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.AddFileItemMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.FilePath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.FileCommand = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.EditFileItemMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 12:
            this.FilePathEdit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.FileCommandEdit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 14:
            this.SiteNothing = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.siteListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 16:
            this.AddSiteItemMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 17:
            this.SiteUrl = ((System.Windows.Controls.TextBox)(target));
            return;
            case 18:
            this.SiteCommand = ((System.Windows.Controls.TextBox)(target));
            return;
            case 19:
            this.EditSiteItemMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 20:
            this.SiteUrlEdit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 21:
            this.SiteCommandEdit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 22:
            this.AnswerNothing = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 23:
            this.answerListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 24:
            this.AddAnswerItemMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 25:
            this.AssistantAnswer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 26:
            this.AnswerCommand = ((System.Windows.Controls.TextBox)(target));
            return;
            case 27:
            this.EditAnswerItemMenu = ((System.Windows.Controls.Border)(target));
            return;
            case 28:
            this.AnswerEdit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 29:
            this.AnswerCommandEdit = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
