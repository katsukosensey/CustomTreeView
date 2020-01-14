using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CustomTreeView.UI.Model;
using CustomTreeView.UI.Utils;
using CustomTreeView.UI.ViewModel;

namespace CustomTreeView.UI.View
{
    /// <summary>
    /// Логика взаимодействия для CheckListEditorView.xaml
    /// </summary>
    public partial class CheckListEditorView
    {
        public CheckListEditorView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            ((CheckListEditorViewModel)DataContext).RefreshAllCheckListAction += RefreshAllCheckList;
            ((CheckListEditorViewModel)DataContext).RefreshCheckListSectionAction += RefreshCheckListSection;
            ((CheckListEditorViewModel)DataContext).SelectCheckListElementAction += SelectCheckListElement;
        }

        private void RefreshAllCheckList()
        {
            TreeView.Items.Refresh();
        }
        private void RefreshCheckListSection(CheckListElement element)
        {
            TreeViewItem tvi = TreeView.ItemContainerGenerator.ContainerFromItemRecursive(element);
            tvi?.Items.Refresh();
        }
        private void SelectCheckListElement(CheckListElement element)
        {
            var tvi = TreeView.ItemContainerGenerator.ContainerFromItemRecursive(element);
            if (tvi != null)
            {
                tvi.IsSelected = true;
            }
        }

        public void Reset(object sender, RoutedEventArgs args)
        {
            if (TreeView.ItemContainerGenerator.ContainerFromItemRecursive(TreeView.SelectedItem) is TreeViewItem selectedTreeViewItem) 
                selectedTreeViewItem.IsSelected = false;
        }


        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null) return;
            ((CheckListEditorViewModel) DataContext).SelectedCheckListElement = (CheckListElement) e.NewValue;
            var container = TreeView.ItemContainerGenerator.ContainerFromItemRecursive(TreeView.SelectedItem);
            var parent = GetSelectedTreeViewItemParent(container);
            ((CheckListEditorViewModel)DataContext).SelectedCheckListElementParent = (CheckListElement) parent?.DataContext; 
        }

        private void TreeViewSelectedItemChanged(object sender, RoutedEventArgs e)
        {
            if (sender is TreeViewItem item)
            {
                item.BringIntoView();
                e.Handled = true;
            }
        }

        public TreeViewItem GetSelectedTreeViewItemParent(TreeViewItem item)
        {
            if (item == null) return null;
            DependencyObject parent = VisualTreeHelper.GetParent(item);
            while (!(parent is TreeViewItem || parent is TreeView))
            {
                parent = VisualTreeHelper.GetParent(parent ?? throw new InvalidOperationException());
            }

            return parent as TreeViewItem;
        }
        public static TreeViewItem FindAncestor(DependencyObject dependencyObject)
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as TreeViewItem;
            return parentT ?? FindAncestor(parent);
        }

        private void UIElement_OnGotFocus(object sender, RoutedEventArgs e)
        {
            FindAncestor((DependencyObject)sender).IsSelected = true;
        }
    }
}
