#pragma checksum "C:\Users\LaptopAZ.vn\source\repos\Sqlite_demo\AppSqlite\Pages\DemoTrans\List.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D4F230904B9AA10E649894A3EC2D1C6C1D18E95B80BCCAAA178D69EB4D4C93BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppSqlite.Pages.DemoTrans
{
    partial class List : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_FrameworkElement_Tag(global::Windows.UI.Xaml.FrameworkElement obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.Tag = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class List_obj11_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IList_Bindings
        {
            private global::AppSqlite.Entity.Category dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj11;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj11TextDisabled = false;
            private static bool isobj11TagDisabled = false;

            public List_obj11_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 32 && columnNumber == 20)
                {
                    isobj11TextDisabled = true;
                }
                else if (lineNumber == 32 && columnNumber == 41)
                {
                    isobj11TagDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 11: // Pages\DemoTrans\List.xaml line 32
                        this.obj11 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.TextBlock)target);
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj11.Target as global::Windows.UI.Xaml.Controls.TextBlock).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::AppSqlite.Entity.Category) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IList_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::AppSqlite.Entity.Category)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::AppSqlite.Entity.Category obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_Name(obj.Name, phase);
                        this.Update_Id(obj.Id, phase);
                    }
                }
            }
            private void Update_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\DemoTrans\List.xaml line 32
                    if (!isobj11TextDisabled)
                    {
                        if ((this.obj11.Target as global::Windows.UI.Xaml.Controls.TextBlock) != null)
                        {
                            XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text((this.obj11.Target as global::Windows.UI.Xaml.Controls.TextBlock), obj, null);
                        }
                    }
                }
            }
            private void Update_Id(global::System.Int32 obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Pages\DemoTrans\List.xaml line 32
                    if (!isobj11TagDisabled)
                    {
                        if ((this.obj11.Target as global::Windows.UI.Xaml.Controls.TextBlock) != null)
                        {
                            XamlBindingSetters.Set_Windows_UI_Xaml_FrameworkElement_Tag((this.obj11.Target as global::Windows.UI.Xaml.Controls.TextBlock), obj, null);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\DemoTrans\List.xaml line 23
                {
                    this.start = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 3: // Pages\DemoTrans\List.xaml line 24
                {
                    this.end = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 4: // Pages\DemoTrans\List.xaml line 25
                {
                    this.searchCategory = (global::Windows.UI.Xaml.Controls.DropDownButton)(target);
                }
                break;
            case 5: // Pages\DemoTrans\List.xaml line 39
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Search_Click;
                }
                break;
            case 6: // Pages\DemoTrans\List.xaml line 40
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.Reset_Click;
                }
                break;
            case 7: // Pages\DemoTrans\List.xaml line 41
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Tapped += this.MigrateData_Tapped;
                }
                break;
            case 8: // Pages\DemoTrans\List.xaml line 43
                {
                    this.dataTransaction = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 9: // Pages\DemoTrans\List.xaml line 29
                {
                    this.listCategory = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.listCategory).SelectionChanged += this.listViewCategory_SelectionChanged;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 11: // Pages\DemoTrans\List.xaml line 32
                {                    
                    global::Windows.UI.Xaml.Controls.TextBlock element11 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                    List_obj11_Bindings bindings = new List_obj11_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element11.DataContext);
                    element11.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element11, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element11, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

