using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CustomTreeView.UI.Model;
using CustomTreeView.UI.Utils;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CustomTreeView.UI.ViewModel
{
    class CheckListEditorViewModel : ViewModelBase
    {
        private ObservableCollection<CheckListElement> checkList;
        private CheckListElement selectedCheckListElement;
        /// <summary>
        /// [rootIndex, needUpdateChild, childIndex]
        /// </summary>
        public Action<CheckListElement> RefreshCheckListSectionAction;
        public Action RefreshAllCheckListAction;
        public Action<CheckListElement> SelectCheckListElementAction;
        public ObservableCollection<CheckListElement> CheckList
        {
            get { return checkList; }
            set { Set(ref checkList, value); }
        }

        public RelayCommand AddSectionCommand { get; set; }
        public RelayCommand AddParagraphCommand { get; set; }
        public RelayCommand AddSubParagraphCommand { get; set; }
        public RelayCommand RemoveElementCommand { get; set; }
        public RelayCommand RemoveAllElementsCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public CheckListElement SelectedCheckListElement
        {
            get => selectedCheckListElement;
            set
            {
                Set(ref selectedCheckListElement, value);
                RaisePropertyChanged(nameof(HasSelectedElement));
                RaisePropertyChanged(nameof(CanAddSection));
                RaisePropertyChanged(nameof(CanAddParagraph));
                RaisePropertyChanged(nameof(CanAddSubParagraph));
                RaisePropertyChanged(nameof(HasAnyCheckListElements));
            }
        }

        public CheckListElement SelectedCheckListElementParent { get; set; }

        public bool CanAddSection => SelectedCheckListElement == null;

        public bool CanAddParagraph => SelectedCheckListElement == null ||
                                       SelectedCheckListElement != null && !SelectedCheckListElement.Pickable;
        public bool CanAddSubParagraph => SelectedCheckListElement != null && SelectedCheckListElement.Pickable && SelectedCheckListElement.Level < 2;
        public bool HasSelectedElement => SelectedCheckListElement != null;
        public bool HasAnyCheckListElements => CheckList.Count > 0;

        public CheckListEditorViewModel()
        {
            CheckList = new ObservableCollection<CheckListElement>(CheckListAggregator.CreateCheckList());
            AddSectionCommand = new RelayCommand(AddSection);
            AddParagraphCommand = new RelayCommand(AddParagraph);
            AddSubParagraphCommand = new RelayCommand(AddSubParagraph);
            RemoveElementCommand = new RelayCommand(Remove);
            RemoveAllElementsCommand = new RelayCommand(RemoveAll);
            ResetCommand = new RelayCommand(Reset);
            SaveCommand = new RelayCommand(Save);
            RefreshAllCheckListAction?.Invoke();
        }

        private void Reset()
        {
            SelectedCheckListElementParent = null;
            SelectedCheckListElement = null;
        }

        private void Save()
        {
            CheckListAggregator.SaveCheckList(CheckList.ToList());
        }

        private void RemoveAll()
        {
            CheckList.Clear();
            SelectedCheckListElement = null;
            RaisePropertyChanged(nameof(CheckList));
            RaisePropertyChanged(nameof(SelectedCheckListElement));
            RefreshAllCheckListAction?.Invoke();
        }
        private void Remove()
        {
            if (!SelectedCheckListElement.Pickable || SelectedCheckListElementParent == null)
            {
                CheckList.Remove(SelectedCheckListElement);
            }
            else
            {
                SelectedCheckListElementParent.RemoveChild(SelectedCheckListElement);
            }
            SelectedCheckListElement = null;
            RefreshAllCheckListAction?.Invoke();
        }

        private void AddSubParagraph()
        {
            var element = new CheckListElement(CheckListElementIdCreator.CreateSubParagraphId(SelectedCheckListElement), "Введите текст подпункта", 2);
            SelectedCheckListElement.Children.Add(element);
            RaisePropertyChanged(nameof(CheckList));
            RefreshCheckListSectionAction?.Invoke(SelectedCheckListElement);
            SelectCheckListElementAction?.Invoke(element);
        }
        
        private void AddParagraph()
        {
            var text = "Введите текст пункта";
            CheckListElement element;
            //если выбран раздел, то добавляем пункт в него
            if (SelectedCheckListElement != null && !SelectedCheckListElement.Pickable)
            {
                element = new CheckListElement(CheckListElementIdCreator.CreateParagraphInSectionId(SelectedCheckListElement), text, 1, children: new List<CheckListElement>());
                SelectedCheckListElement.Children.Add(element);
                RefreshCheckListSectionAction?.Invoke(SelectedCheckListElement);
                SelectedCheckListElementParent = SelectedCheckListElement;
            }
            else
            {
                element = new CheckListElement(CheckListElementIdCreator.CreateParagraphId(CheckList), text, children: new List<CheckListElement>());
                CheckList.Add(element);
                RefreshAllCheckListAction?.Invoke();
            }
            SelectCheckListElementAction?.Invoke(element);
        }

        private void AddSection()
        {
            var element = new CheckListElement(null, "Введите название раздела", pickable: false, children: new List<CheckListElement>());
            CheckList.Add(element);
            RefreshAllCheckListAction?.Invoke();
            SelectCheckListElementAction?.Invoke(element);
        }
    }
}
