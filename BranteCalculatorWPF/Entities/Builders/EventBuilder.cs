using BranteCalculator.Entities.Events;
using BranteCalculatorWPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculator.Entities.Builders
{
    public class EventBuilder
    {
        private readonly string _name;
        private readonly bool _isVariableTime;
        private readonly List<Expression<Func<bool>>> _requirements = new List<Expression<Func<bool>>>();
        private readonly List<Expression<Func<bool>>> _hiddenRequirements = new List<Expression<Func<bool>>>();
        private readonly List<Decision> _decisions = new List<Decision>();

        public EventBuilder(string name)
        {
            _name = name;
            _isVariableTime = false;
        }

        public EventBuilder(string name, bool isVariableTime)
        {
            _name = name;
            _isVariableTime = isVariableTime;
        }

        public EventBuilder WithRequirement(Expression<Func<bool>> requirement)
        {
            _requirements.Add(requirement);
            return this;
        }

        public EventBuilder WithHiddenRequirement(Expression<Func<bool>> requirement)
        {
            _hiddenRequirements.Add(requirement);
            return this;
        }

        public EventBuilder WithDecision(string name, Action<DecisionBuilder> decisionBuilderAction)
        {
            var decisionBuilder = new DecisionBuilder(name);
            decisionBuilderAction(decisionBuilder);
            _decisions.Add(decisionBuilder.Build());
            return this;
        }

        public Event Build()
        {
            Event gameEvent = new Event(_name, _isVariableTime, _requirements, _hiddenRequirements, _decisions);
            foreach(Decision decision in gameEvent.Decisions) 
            {
                decision.Event = gameEvent;
            }

            return gameEvent;
        }
    }
}
