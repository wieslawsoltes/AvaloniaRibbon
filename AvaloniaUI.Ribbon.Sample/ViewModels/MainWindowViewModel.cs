using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using ReactiveUI;

namespace AvaloniaUI.Ribbon.Samples.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public void OnClickCommand(object parameter)
        {
            string paramString = "[NO CONTENT]";
            
            if (parameter != null)
            {
                if (parameter is string str)
                    paramString = str;
                else
                    paramString = parameter.ToString();
            }

            Console.WriteLine("OnClickCommand invoked: " + paramString);
            LastActionText = paramString;
        }

        string _lastActionText = "none";

        public string LastActionText
        {
            get => _lastActionText;
            set
            {
                _lastActionText = value;
                NotifyPropertyChanged();
            }
        }

        bool _showContextualGroup1 = true;

        public bool ShowContextualGroup1
        {
            get => _showContextualGroup1;
            set
            {
                _showContextualGroup1 = value;
                NotifyPropertyChanged();
            }
        }

        bool _showContextualGroup2 = false;

        public bool ShowContextualGroup2
        {
            get => _showContextualGroup2;
            set
            {
                _showContextualGroup2 = value;
                NotifyPropertyChanged();
            }
        }

        bool _showContextualGroup3 = false;

        public bool ShowContextualGroup3
        {
            get => _showContextualGroup3;
            set
            {
                _showContextualGroup3 = value;
                NotifyPropertyChanged();
            }
        }



        bool _isRibbonCollapsed = false;

        public bool IsRibbonCollapsed
        {
            get => _isRibbonCollapsed;
            set
            {
                _isRibbonCollapsed = value;
                NotifyPropertyChanged();
            }
        }



        bool _isRibbonVertical = false;

        public bool IsRibbonVertical
        {
            get => _isRibbonVertical;
            set
            {
                _isRibbonVertical = value;
                if (_isRibbonVertical)
                    RibbonOrientation = Avalonia.Layout.Orientation.Vertical;
                else
                    RibbonOrientation = Avalonia.Layout.Orientation.Horizontal;
                NotifyPropertyChanged();
            }
        }

        Avalonia.Layout.Orientation _ribbonOrientation = Avalonia.Layout.Orientation.Horizontal;
        public Avalonia.Layout.Orientation RibbonOrientation
        {
            get => _ribbonOrientation;
            set
            {
                _ribbonOrientation = value;
                NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        string _help = "Help requested!";
        public void HelpCommand(object parameter)
        {
            Console.WriteLine(_help);
            LastActionText = _help;
        }
    }
}
