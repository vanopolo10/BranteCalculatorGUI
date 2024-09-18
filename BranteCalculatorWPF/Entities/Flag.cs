﻿using BranteCalculatorWPF;
using BranteCalculatorWPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculator.Entities
{
    public class Flag : LocalizibleObject
    {
        private bool _value;
        public bool Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
                    
        public string DisplayText { get => LocalizedName; }

        private static MainViewModel _viewModel = MainWindow.ViewModel;

        public Flag(string name) : base(name)
        {
            Name = name;
            Value = false;
        }

        public static bool operator ==(Flag a, bool b)
        {
            return a.Value == b;
        }

        public static bool operator !=(Flag a, bool b)
        {
            return a.Value != b;
        }

        public void Check() 
        {
            Value = true;
            _viewModel.Flags.Add(this);
        }
    }
}