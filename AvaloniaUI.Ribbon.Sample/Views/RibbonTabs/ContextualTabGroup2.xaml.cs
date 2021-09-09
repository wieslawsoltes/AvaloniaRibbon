using Avalonia;
using Avalonia.Controls;
using AvaloniaUI.Ribbon;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using System;

namespace AvaloniaUI.Ribbon.Samples.Views
{
    public class ContextualTabGroup2 : RibbonContextualTabGroup
    {
        public ContextualTabGroup2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
