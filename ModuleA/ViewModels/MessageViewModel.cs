using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Reflection;
using UsingEventAggregator.Core;
using WPFLocalizeExtension.Extensions;

namespace ModuleA.ViewModels
{
    public class MessageViewModel : BindableBase
    {
        public MessageViewModel() { }

        //Module間でデータをやり取りするためのイベントアグリゲータ
        IEventAggregator _ea;

        private string _message = "";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            //現在のcultureのresourcesを抜き出す
            Message = LocalizationProvider.GetLocalizedValue<string>("MESSAGE2SEND");
            _ea.GetEvent<MessageSentEvent>().Publish(Message);


        }

        //Resourcesから値を取り出すスタティッククラス
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
