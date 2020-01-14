using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CustomTreeView.UI.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

namespace CustomTreeView.UI.Model
{
    public class CheckListElementController : INotifyPropertyChanged
    {
        private bool isChecked;
        public CheckListElement CheckListElement { get; set; }
        public RelayCommand<string> CheckCommand { get; set; }
        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CheckListElementController> Children { get; set; }
        public CheckListElementController(CheckListElement checkListElement)
        {
            CheckListElement = checkListElement;
            CheckCommand = new RelayCommand<string>(OnCheckCommand);
            Children = new ObservableCollection<CheckListElementController>();
            checkListElement.Children?.ForEach(x => Children.Add(new CheckListElementController(x)));
            OnPropertyChanged(nameof(Children));
        }

        private void OnCheckCommand(string s)
        {
            var value = bool.Parse(s);
            IsChecked = true;
            CheckListElement.MarkingOfMade = value;
            OnPropertyChanged(nameof(CheckListElement));
            Messenger.Default.Send(new CheckListCheckedMessage());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
