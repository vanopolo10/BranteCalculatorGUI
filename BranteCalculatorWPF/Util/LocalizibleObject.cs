using BulbulatorLocalization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculatorWPF.Util
{
    public abstract class LocalizibleObject : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(LocalizedName));
            }
        }

        protected static Settings _settings;
        protected static Localizer _localizer;

        public string LocalizedName { get => _localizer.GetLocalizedString(_settings.Locale, Name) ?? Name; }
 
        public LocalizibleObject(string name)
        {
            Name = name;
            _settings = MainWindow.Settings;
            _localizer = MainWindow.Localizer;

            _settings.LocaleChanged += OnLocaleChanged;
        }
       
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnLocaleChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(LocalizedName));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }     
    }
}
