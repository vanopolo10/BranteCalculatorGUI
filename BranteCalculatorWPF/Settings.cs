using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculatorWPF
{
    public class Settings
    {
        private string _locale;
        public string Locale
        {
            get => _locale;
            set
            {
                if (_locale != value)
                {
                    _locale = value;
                    OnLocaleChanged();
                }
            }
        }

        public event EventHandler? LocaleChanged;

        protected void OnLocaleChanged()
        {
            LocaleChanged?.Invoke(this, EventArgs.Empty);
        }

        public Settings(string locale) 
        {
            Locale = locale;
        }
    }
}
