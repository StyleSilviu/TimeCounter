using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using TimeCount.PieControl;

namespace TimeCount.Pie
{
    public static class PieCollectionHelper
    {
        public static double GetTotal(this ObservableCollection<PieSegment> collection)
        {
            return collection.Sum((a) => { return a.Value; });
        }
    }
}
