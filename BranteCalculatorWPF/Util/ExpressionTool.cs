using BranteCalculator.Entities.Characters;
using BranteCalculator.Entities.Stats;
using BranteCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BranteCalculatorWPF.Util
{
    public static class ExpressionTool
    {
        public static string ConvertExpressionToText(Expression expression)
        {
            if (expression is BinaryExpression binaryExpr)
            {
                string left = ConvertExpressionToText(binaryExpr.Left);
                string right = ConvertExpressionToText(binaryExpr.Right);

                string operatorSymbol = GetOperatorSymbol(binaryExpr.NodeType);


                if (binaryExpr.NodeType == ExpressionType.Equal && right == "False")
                {
                    return $"{MainWindow.Localizer.GetLocalizedString(MainWindow.Settings.Locale, "LOGICAL_OPERATION_NOT")} {left}";
                }
                else if (binaryExpr.NodeType == ExpressionType.Equal && right == "True")
                {
                    return left;
                }
                else
                {
                    return $"({left} {operatorSymbol} {right})";
                }
            }
            else if (expression is MemberExpression memberExpr)
            {
                return GetMemberValueText(memberExpr);
            }
            else if (expression is ConstantExpression constantExpr)
            {
                return constantExpr.Value?.ToString() ?? null;
            }
            else if (expression is MethodCallExpression methodCallExpr)
            {
                string methodName = methodCallExpr.Method.Name;
                string arguments = string.Join(", ", methodCallExpr.Arguments.Select(arg => ConvertExpressionToText(arg)));
                return $"{methodName}({arguments})";
            }
            else if (expression is UnaryExpression unaryExpr)
            {
                string operand = ConvertExpressionToText(unaryExpr.Operand);
                return $"{GetOperatorSymbol(unaryExpr.NodeType)}{operand}";
            }
            else
            {
                return expression.ToString();
            }
        }

        public static string ConvertActionExpressionToText(Expression expression)
        {
            if (expression is MethodCallExpression methodCallExpr)
            {
                string methodName = methodCallExpr.Method.Name;
                string targetName = GetMemberValueText(methodCallExpr.Object as MemberExpression);
                string argument = methodCallExpr.Arguments.Count > 0 ? ConvertExpressionToText(methodCallExpr.Arguments[0]) : string.Empty;

                if (methodName == "Add")
                {
                    return $"{targetName} {(int.Parse(argument) > 0 ? "+" : "")}{argument}";
                }
                else if (methodName == "Set")
                {
                    return $"{targetName} = {argument}";
                }
                else if (methodName == "Check")
                {
                    return $"{targetName}";
                }
            }
            return expression.ToString();
        }

        private static string GetOperatorSymbol(ExpressionType expressionType)
        {
            return expressionType switch
            {
                ExpressionType.Equal => "=",
                ExpressionType.NotEqual => "≠",
                ExpressionType.GreaterThan => ">",
                ExpressionType.GreaterThanOrEqual => "≥",
                ExpressionType.LessThan => "<",
                ExpressionType.LessThanOrEqual => "≤",
                ExpressionType.AndAlso => MainWindow.Localizer.GetLocalizedString(MainWindow.Settings.Locale, "LOGICAL_OPERATION_AND"),
                ExpressionType.OrElse => MainWindow.Localizer.GetLocalizedString(MainWindow.Settings.Locale, "LOGICAL_OPERATION_OR"),
                ExpressionType.Not => MainWindow.Localizer.GetLocalizedString(MainWindow.Settings.Locale, "LOGICAL_OPERATION_NOT"),
                _ => throw new NotSupportedException($"Unsupported expression type: {expressionType}")
            };
        }

        private static string GetMemberValueText(MemberExpression memberExpr)
        {
            LocalizibleObject gameObject = GetExpressionValue(memberExpr) as LocalizibleObject;
            if (gameObject != null)
            {
                return gameObject.LocalizedName;
            }

            return memberExpr.Member.Name;
        }

        private static object GetValue(MemberExpression memberExpr)
        {
            if (memberExpr.Expression is ConstantExpression constant)
            {
                var field = memberExpr.Member as FieldInfo;
                return field.GetValue(constant.Value);
            }
            else if (memberExpr.Expression is MemberExpression parentMemberExpr)
            {
                var parentObject = GetValue(parentMemberExpr);
                var propertyInfo = memberExpr.Member as PropertyInfo;
                return propertyInfo?.GetValue(parentObject);
            }
            return null;
        }

        private static object GetExpressionValue(Expression expr)
        {
            if (expr is ConstantExpression constantExpr)
            {
                return constantExpr.Value;
            }
            else if (expr is MemberExpression memberExpr)
            {
                var parentObject = GetExpressionValue(memberExpr.Expression);
                var member = memberExpr.Member;

                if (member is PropertyInfo property)
                {
                    return property.GetValue(parentObject);
                }
                else if (member is FieldInfo field)
                {
                    return field.GetValue(parentObject);
                }
            }
            else if (expr is MethodCallExpression methodCallExpr)
            {
                var instance = GetExpressionValue(methodCallExpr.Object);
                var arguments = new object[methodCallExpr.Arguments.Count];
                for (int i = 0; i < arguments.Length; i++)
                {
                    arguments[i] = GetExpressionValue(methodCallExpr.Arguments[i]);
                }

                var method = methodCallExpr.Method;
                return method.Invoke(instance, arguments);
            }
            else if (expr is ParameterExpression parameterExpr)
            {
                throw new NotSupportedException("ParameterExpression requires evaluation in a specific context.");
            }

            return null;
        }
    }
}