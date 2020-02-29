using System;
using System.Collections.Generic;

namespace FilteringDemo.Models
{
    public class ParentItem
    {
        public string Name { get; set; }
        public List<string> ChildItems { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public ParentItemStatus Status { get; set; }
    }

    public enum ParentItemStatus
    {
        Status_One,
        Status_Two
    }
}
