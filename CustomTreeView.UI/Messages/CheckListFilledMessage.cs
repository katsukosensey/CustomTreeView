using System.Collections.Generic;
using CustomTreeView.UI.Model;

namespace CustomTreeView.UI.Messages
{
    class CheckListFilledMessage
    {
        public readonly List<CheckListElement> CheckListElements;

        public CheckListFilledMessage(List<CheckListElement> checkListElements)
        {
            CheckListElements = checkListElements;
        }
    }
}
