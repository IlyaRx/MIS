﻿#pragma checksum "..\..\..\..\View\PoiskPasientPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5FEC0F4A3F8DE9315EAD4A283FA8502641DAD8FF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MISApplication.View;
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


namespace MISApplication.View {
    
    
    /// <summary>
    /// PoiskPasientPage
    /// </summary>
    public partial class PoiskPasientPage : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Poisk;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButPoisk;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listPasient;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton OrderByR;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadButFIO;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadButCNILS;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadButPasport;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\View\PoiskPasientPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton RadButSave;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MISApplication;component/view/poiskpasientpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\PoiskPasientPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Poisk = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ButPoisk = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\View\PoiskPasientPage.xaml"
            this.ButPoisk.Click += new System.Windows.RoutedEventHandler(this.ButPoisk_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.listPasient = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.OrderByR = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.RadButFIO = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.RadButCNILS = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.RadButPasport = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.RadButSave = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            
            #line 155 "..\..\..\..\View\PoiskPasientPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSelect_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

