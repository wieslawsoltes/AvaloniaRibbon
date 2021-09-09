using Avalonia;
using Avalonia.Controls;
using AvaloniaUI.Ribbon;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using System;

namespace AvaloniaUI.Ribbon.Samples.Views
{
    public class MainRibbon : Ribbon
    {
        public MainRibbon()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
