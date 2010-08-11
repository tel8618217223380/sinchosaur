using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Threading;

namespace Client
{
   public class Localization
    {

       static public void Init()
       {
           Thread.CurrentThread.CurrentUICulture = new CultureInfo(GetPropertiesCulture());
       }

        //метод для установки локализации формы "на лету"  
        static public void LocalizeForm(Form someForm, string culture)
        {
            CultureInfo cultureInfo = new CultureInfo(culture); 
            Type someFormType = someForm.GetType();
            ResourceManager res = new ResourceManager(someFormType);

            //зададим список свойств объектов, которые будем извлекать из файла ресурсов  
            string[] properties = { "Text", "Location" };

            foreach (string propertyName in properties)
            {
                //выбор всех свойств класса формы, извлечение из файла ресурсов значения, и их установка  
                foreach (FieldInfo fieldInfo in someFormType.GetFields(BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance))
                {
                    PropertyInfo propertyInfo = fieldInfo.FieldType.GetProperty(propertyName);
                    if (propertyInfo == null)
                        continue;
                    object objProperty = res.GetObject(fieldInfo.Name + '.' + propertyInfo.Name, cultureInfo);
                    if (objProperty == null) continue;
                    object field = fieldInfo.GetValue(someForm);
                    if (field != null)
                        propertyInfo.SetValue(field, objProperty, null);
                }
                //код для установки свойств самих форм  
                PropertyInfo propertyInfo1 = someFormType.GetProperty(propertyName);
                if (propertyInfo1 == null)
                    continue;
                object objProperty1 = res.GetObject("$this." + propertyInfo1.Name, cultureInfo);
                if (objProperty1 == null) continue;
                propertyInfo1.SetValue(someForm, objProperty1, null);
            }
        }

        //установка культуры
        static public void SetNewCulture(string culture)
        {
            Properties.Settings.Default.Locale = culture;
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        //возвращает культуру в конфиг файле 
        static public string GetPropertiesCulture()
        {
            return Properties.Settings.Default.Locale;
        }


        //получение значение одного свойства
        static public string GetFormCultureString(Form someForm, string propertyName)
        {
            ResourceManager res = new ResourceManager(someForm.GetType());
            object objProperty = res.GetObject(propertyName, Thread.CurrentThread.CurrentUICulture);
            if (objProperty == null) return "";

            return (string)objProperty;
 
        }  


    }
}
