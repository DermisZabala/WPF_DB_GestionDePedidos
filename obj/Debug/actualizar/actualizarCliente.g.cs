﻿#pragma checksum "..\..\..\actualizar\actualizarCliente.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3EF66EF605FA786ABC08D6E8B11E5CA0E8E00453B44FE54715AB3FF168704959"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPF_DB_GestionPedidos.actualizar;


namespace WPF_DB_GestionPedidos.actualizar {
    
    
    /// <summary>
    /// actualizarCliente
    /// </summary>
    public partial class actualizarCliente : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\actualizar\actualizarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ActualizarNombreCliente;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\actualizar\actualizarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox DireccionCliente;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\actualizar\actualizarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PoblacionCliente;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\actualizar\actualizarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumeroDeTelefono;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\actualizar\actualizarCliente.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EnviarFormulario;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF_DB_GestionPedidos;component/actualizar/actualizarcliente.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\actualizar\actualizarCliente.xaml"
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
            this.ActualizarNombreCliente = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.DireccionCliente = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PoblacionCliente = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NumeroDeTelefono = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.EnviarFormulario = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\actualizar\actualizarCliente.xaml"
            this.EnviarFormulario.Click += new System.Windows.RoutedEventHandler(this.EnviarFormulario_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

