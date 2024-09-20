using BranteCalculator.Entities.Characters;
using BranteCalculator.Entities.Events;
using BranteCalculator.Entities.Stats;
using BranteCalculatorWPF;
using BranteCalculatorWPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BranteCalculator.Entities
{
    public class Decision : LocalizibleObject
    {
        public List<Expression<Func<bool>>> Requirements = new List<Expression<Func<bool>>>();
        public List<Expression<Action>> VisibleConsequances = new List<Expression<Action>>();
        public List<Expression<Action>> HiddenConsequances = new List<Expression<Action>>();
        public List<Expression<Action>> Consequances { get => VisibleConsequances.Concat(HiddenConsequances).ToList(); }

        private bool _isChecked;
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (_isChecked != value)
                {
                    _isChecked = value;
                    OnPropertyChanged(nameof(IsChecked));
                }
            }
        }

        public Event Event { get; set; }

        public Decision(string name, List<Expression<Func<bool>>> conditions, List<Expression<Action>> visibleConsequances, List<Expression<Action>> hiddenConsequances) : base(name)
        {
            Name = name;
            Requirements = conditions;
            VisibleConsequances = visibleConsequances;
            HiddenConsequances = hiddenConsequances;
            IsChecked = false;

            _settings.LocaleChanged += OnLocaleChanged;
        }
        private bool? _isAvailable;

        public bool IsAvailable
        {
            get
            {
                if (Event.HasPassed == false) 
                {
                    _isAvailable = null;
                }

                if (_isAvailable == null)
                {
                    _isAvailable = true;
                    foreach (var requirement in Requirements)
                    {
                        var compiledRequirement = requirement.Compile();
                        if (!compiledRequirement())
                        {
                            _isAvailable = false;
                        }
                    }
                }
                return _isAvailable.Value;
            }
        }

        public void Select()
        {
            IsChecked = true;
            foreach (var consequence in Consequances)
            {
                var compiledAction = consequence.Compile();
                compiledAction();

                Event.HasPassed = true;
            }
        }

        public string ConsequancesText
        {
            get
            {
                if (VisibleConsequances == null || Consequances.Count == 0)
                    return string.Empty;

                return string.Join(", ", VisibleConsequances.Select(c => ExpressionTool.ConvertActionExpressionToText(c.Body)));
            }
        }


        public string RequirementsText
        {
            get
            {
                if (Requirements == null || Requirements.Count == 0)
                    return string.Empty;

                string result = string.Join(", ", Requirements.Select(expr => ExpressionTool.ConvertExpressionToText(expr.Body)));
                result = result.Replace("(", "");
                result = result.Replace(")", "");
                return "(" + result + ")";
            }
        }

        public void UpdateAvailability() 
        {
            _isAvailable = null;
            OnPropertyChanged(nameof(IsAvailable));
        }

        protected override void OnLocaleChanged(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(LocalizedName));
            OnPropertyChanged(nameof(RequirementsText));
            OnPropertyChanged(nameof(ConsequancesText));
        }

        public static bool operator ==(Decision a, Decision b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            else if (a is null || b is null)
            {
                return false;
            }
            else
            {
                return a.Name == b.Name && ReferenceEquals(a.Requirements, b.Requirements) && ReferenceEquals(a.Consequances, b.Consequances);
            }
        }

        public static bool operator !=(Decision a, Decision b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            else if (a is null || b is null)
            {
                return true;
            }
            else
            {
                return a.Name != b.Name || !ReferenceEquals(a.Requirements, b.Requirements) || !ReferenceEquals(a.Consequances, b.Consequances);
            }
        }


    }
}
