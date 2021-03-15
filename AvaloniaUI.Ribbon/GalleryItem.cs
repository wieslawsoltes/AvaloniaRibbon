using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaUI.Ribbon
{
    public class GalleryItem : ListBoxItem
    {
        public static readonly StyledProperty<object> IconProperty = RibbonButton.IconProperty.AddOwner<GalleryItem>();

        public object Icon
        {
            get => GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}
