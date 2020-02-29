using FilteringDemo.Models;
using FilteringDemo.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FilteringDemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ParentItem> ParentItems { get; set; }

        public MainWindowViewModel()
        {
            ParentItems = new ObservableCollection<ParentItem>();

            LoadDummyParentItems();
        }

        private ICommand _filterChildren;
        public ICommand FilterChildren => _filterChildren ?? (_filterChildren = new RelayCommand(p => ApplyChildFilter()));

        private void ApplyChildFilter()
        {
            //TODO: Filter?
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
