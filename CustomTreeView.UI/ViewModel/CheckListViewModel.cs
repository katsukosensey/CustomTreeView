using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CustomTreeView.UI.Messages;
using CustomTreeView.UI.Model;
using CustomTreeView.UI.Utils;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CustomTreeView.UI.ViewModel
{
    public class CheckListViewModel : ViewModelBase
    {
        private ObservableCollection<CheckListElementController> checkList;

        public ObservableCollection<CheckListElementController> CheckList
        {
            get { return checkList; }
            set { Set(ref checkList, value); }
        }

        public CheckListViewModel()
        {
            CheckList = new ObservableCollection<CheckListElementController>();
            CheckListAggregator.CreateCheckList().ForEach(x => CheckList.Add(new CheckListElementController(x)));
            Messenger.Default.Register<CheckListCheckedMessage>(this, value => CheckListFillComplete());
            CheckListFillComplete();
        }


        public override void Cleanup()
        {
            Messenger.Default.Unregister<CheckListCheckedMessage>(this, value => CheckListFillComplete());

            base.Cleanup();
        }

        public void CheckListFillComplete()
        {
            if (CheckList.Any(x => !x.IsChecked && x.CheckListElement.Pickable))
            {
                return;
            }
            foreach (var checkListElementController in CheckList)
            {
                if (checkListElementController.Children == null)
                {
                    continue;
                }

                if (checkListElementController.Children.Any(x => !x.IsChecked && x.CheckListElement.IsEnabled))
                {
                    return;
                }
            }
            lock (CheckList)
            {
                var list = new List<CheckListElement>();
                foreach (var checkListElementController in CheckList.ToArray())
                {
                    var element = checkListElementController.CheckListElement;
                    if (checkListElementController.Children != null)
                    {
                        element.Children?.Clear();
                        if (element.Children == null)
                        {
                            list.Add(element);
                            continue;
                        }

                        foreach (var listElementController in checkListElementController.Children)
                        {
                            element.Children.Add(listElementController.CheckListElement);
                        }
                    }

                    list.Add(element);
                }
                Messenger.Default.Send(new CheckListFilledMessage(list));
            }
        }
    }
}
