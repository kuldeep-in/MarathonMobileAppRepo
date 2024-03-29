﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyHack.Mobile.Helper
{
    public static class ApplicationProperty
    {
        public static object GetApplicationCurrentProperty(string propertyKey)
        {
            object retValue = null;
            IDictionary<string, object> properties = Application.Current.Properties;
            if (properties.ContainsKey(propertyKey))
            {
                retValue = properties[propertyKey];
            }
            return retValue;
        }

        public static void SetApplicationCurrentProperty(string propertyKey, object obj)
        {
            IDictionary<string, object> properties = Application.Current.Properties;
            if (properties.ContainsKey(propertyKey))
            {
                properties[propertyKey] = obj;
            }
            else
            {
                properties.Add(propertyKey, obj);
            }
        }
    }
}
