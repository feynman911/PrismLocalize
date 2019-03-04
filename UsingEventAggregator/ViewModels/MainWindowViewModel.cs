using Prism.Mvvm;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

using System.Globalization;
using System.Reflection;

namespace UsingEventAggregator.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            LocalizeDictionary.Instance.Culture = new CultureInfo("en-US");
        }
    }

    public static class LocalizationProvider
    {
        public static T GetLocalizedValue<T>(string key)
        {
            return LocExtension.GetLocalizedValue<T>
                (Assembly.GetCallingAssembly().GetName().Name + ":Resources:" + key);
        }
    }
}
