using System.Collections.Generic;
using System.Text;
using CustomTreeView.UI.Model;

namespace CustomTreeView.UI.Utils
{
    public static class CheckListElementIdCreator
    {
        public static string CreateSubParagraphId(CheckListElement paragraph)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(paragraph.Id);
            builder.Append(".");
            builder.Append(paragraph.Children?.Count + 1);
            return builder.ToString();
        }
        public static string CreateParagraphInSectionId(CheckListElement section)
        {
            var id = section.Children?.Count ?? 0;
            return (id + 1).ToString();
        }
        public static string CreateParagraphId(ICollection<CheckListElement> checkList)
        {
            return (checkList.Count + 1).ToString();
        }
    }
}
