﻿

#pragma checksum "C:\Users\user\Desktop\FYP27thApril\NormalVersion\UniversalApp\CrystalClearUniversal\CrystalClearUniversal\CrystalClearUniversal.Windows\MeterReading.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "516AA8B85CF8D438F08030F663B776F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrystalClearUniversal
{
    partial class MeterReading : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 54 "..\..\MeterReading.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.RadioButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 60 "..\..\MeterReading.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.RadioButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 78 "..\..\MeterReading.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBox)(target)).TextChanged += this.billAmountTextBox_TextChanged;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 106 "..\..\MeterReading.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Save_Btn;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 107 "..\..\MeterReading.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.View_History_Btn;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


