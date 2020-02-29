using FilteringDemo.Models;
using FilteringDemo.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace FilteringDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ParentItem> ParentItems { get; set; }

        private ParentItem _selectedParentItem;
        public ParentItem SelectedParentItem
        {
            get { return _selectedParentItem; }
            set { SetProperty(ref _selectedParentItem, value); }
        }

        public MainWindowViewModel()
        {
            ParentItems = new ObservableCollection<ParentItem>();

            LoadDummyParentItems();
        }

        private ICommand _filterChildrenCommand;
        public ICommand FilterChildrenCommand => _filterChildrenCommand ?? (_filterChildrenCommand = new RelayCommand(param => FilterChildren((string)param), param => CanFilterChildren((string)param)));

        private ICommand _clearChildrenFilterCommand;
        public ICommand ClearChildrenFilterCommand => _clearChildrenFilterCommand ?? (_clearChildrenFilterCommand = new RelayCommand(p => FilterChildren(null), p => CanClearFilterChildren()));

        private bool CanFilterChildren(string filter) => SelectedParentItem != null && filter.Length > 0;
        private bool CanClearFilterChildren() => SelectedParentItem != null;

        private void FilterChildren(string filter)
        {
            if (filter == null)
            {
                CollectionViewSource.GetDefaultView(SelectedParentItem.ChildItems).Filter = null;
            }
            else
            {
                CollectionViewSource.GetDefaultView(SelectedParentItem.ChildItems).Filter = item => (item as string).Contains(filter);
            }
        }



        private void LoadDummyParentItems()
        {
            for (var i = 0; i < 20; i++)
            {
                ParentItems.Add(new ParentItem()
                {
                    Name = $"Parent Item {i}",
                    CreatedOn = DateTime.Now.AddHours(i),
                    IsActive = i % 2 == 0 ? true : false,
                    Status = i % 2 == 0 ? ParentItemStatus.Status_Two : ParentItemStatus.Status_One,
                    ChildItems = new List<string>() { $"Child one_{i}", $"Child two_{i}", $"Child three_{i}", $"Child four_{i}" }
                });
            }
        }
    }
}
