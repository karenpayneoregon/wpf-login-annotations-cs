﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace ValidationCoreLibrary
{
    public class GenericValidationRule<T> : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string result = string.Empty;
            BindingGroup bindingGroup = (BindingGroup)value;
            foreach (var item in bindingGroup.Items.OfType<T>())
            {
                Type type = item.GetType();
                // First we find all properties that have attributes.
                foreach (var propertyInfo in type.GetProperties())
                {
                    foreach (var attribute in Attribute.GetCustomAttributes(propertyInfo, true))
                    {
                        // We continue if we found a data annotation
                        if (attribute is System.ComponentModel.DataAnnotations.ValidationAttribute validationAttribute)
                        {
                            if (bindingGroup.TryGetValue(item, propertyInfo.Name, out object itemValue))
                            {
                                if (itemValue == DependencyProperty.UnsetValue)
                                {
                                    itemValue = null;
                                }

                                // We set the error message if the validation of the property fails.
                                if (!validationAttribute.IsValid(itemValue))
                                {
                                    if (!string.IsNullOrWhiteSpace(result))
                                    {
                                        result += Environment.NewLine;
                                    }

                                    if (string.IsNullOrEmpty(validationAttribute.ErrorMessage))
                                    {
                                        result += $"Validation on {propertyInfo.Name} failed!";
                                    }
                                    else
                                    {
                                        result += validationAttribute.ErrorMessage;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            return !string.IsNullOrWhiteSpace(result) ? new ValidationResult(false, result) : ValidationResult.ValidResult;
        }
    }
}
