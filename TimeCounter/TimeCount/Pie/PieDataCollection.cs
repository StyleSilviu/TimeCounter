using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
//pie classe declaration
using TimeCount.PieControl;


namespace TimeCount.Pie
{
    public class PieDataCollection<T> : ObservableCollection<T> where T : PieSegment
    {
        public string CollectionName { get; set; }
    }
}