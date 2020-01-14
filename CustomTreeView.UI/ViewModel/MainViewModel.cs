using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CustomTreeView.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase current;
        public RelayCommand EditCommand { get; set; }
        public RelayCommand ExamCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }
        public ViewModelBase Current
        {
            get
            {
                return current;
            }
            set
            {
                if (current == value)
                    return;
                current = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            ExamCommand = new RelayCommand(OpenExam);
            EditCommand = new RelayCommand(OpenEditor);
            ExitCommand = new RelayCommand(Exit);
            OpenEditor();
        }

        private void OpenEditor()
        {
            if (!(Current is CheckListEditorViewModel))
            {
                Current = new CheckListEditorViewModel();
            }
        }

        private void Exit()
        {
            ViewModelLocator.Cleanup();
            Application.Current.Shutdown(0);
        }

        private void OpenExam()
        {
            if (!(Current is CheckListViewModel))
            {
                Current = new CheckListViewModel();
            }
        }
    }
}