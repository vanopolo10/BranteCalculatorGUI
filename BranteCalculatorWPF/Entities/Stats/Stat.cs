using BranteCalculatorWPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculator.Entities.Stats
{
    public class Stat : LocalizibleObject
    {
        private int _value;

        public int MinValue { get; }
        public int MaxValue { get; }

        public int Value
        {
            get => _value;
            set  
            {
                _value = Math.Clamp(value, MinValue, MaxValue);             
                OnPropertyChanged(nameof(Value));
            }
        }

        public string DisplayText { get => LocalizedName + " = " + Value; }

        public Stat(string name, int value, int minValue, int maxValue) : base(name)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("MinValue cannot be greater than MaxValue");
            }

            Name = name;
            MinValue = minValue;
            MaxValue = maxValue;
            Value = value;
        }

        // Overriding addition
        public static Stat operator +(Stat a, int b)
        {
            a.Value += b;
            return a;
        }


        public static Stat operator -(Stat a, int b)
        {
            a.Value -= b;
            return a;
        }

        public static bool operator >(Stat a, int b)
        {
            return a.Value > b;
        }

        public static bool operator <(Stat a, int b)
        {
            return a.Value < b;
        }

        public static bool operator >=(Stat a, int b)
        {
            return a.Value >= b;
        }

        public static bool operator <=(Stat a, int b)
        {
            return a.Value <= b;
        }

        public static bool operator ==(Stat a, int b)
        {
            return a.Value == b;
        }

        public static bool operator !=(Stat a, int b)
        {
            return a.Value != b;
        }

        public virtual void Add(int a) 
        {
            Value += a;
        }      
    }
}
