using Prism.Mvvm;
using WPFLocalizeExtension.Engine;
using WPFLocalizeExtension.Extensions;

using System.Globalization;
using System.Reflection;
using System.Collections.ObjectModel;

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
            //OSの言語設定を使用
            LocalizeDictionary.Instance.Culture = new CultureInfo(CultureInfo.CurrentCulture.Name);
            //en-USに変更する時
            //LocalizeDictionary.Instance.Culture = new CultureInfo("en-US");
            CultureInfos = LocalizeDictionary.Instance.MergedAvailableCultures;
        }

        private ObservableCollection<CultureInfo> cultureInfos;
        public ObservableCollection<CultureInfo> CultureInfos
        {
            get { return cultureInfos; }
            set { SetProperty(ref cultureInfos, value); }
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


}
