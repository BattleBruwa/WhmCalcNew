using System.Diagnostics;
using System.Windows;

namespace WhmCalcNew.Engine.ThemeChanger
{
    class ThemeChanger
    {
        public static void ChangeTheme(ref bool themeState)
        {
            ResourceDictionary DarkTheme = new ResourceDictionary() { Source = new Uri("Visual/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute) };

            ResourceDictionary LightTheme = new ResourceDictionary() { Source = new Uri("Visual/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute) };

            if (themeState == true)
            {
                App.Current.Resources.MergedDictionaries.Add(LightTheme);

                App.Current.Resources.MergedDictionaries.Remove(DarkTheme);

                themeState = false;

                Debug.WriteLine("Смена темы на светлую");
            }
            else if (themeState == false)
            {
                App.Current.Resources.MergedDictionaries.Add(DarkTheme);

                App.Current.Resources.MergedDictionaries.Remove(LightTheme);

                themeState = true;

                Debug.WriteLine("Смена темы на темную");
            }
        }
    }
}
