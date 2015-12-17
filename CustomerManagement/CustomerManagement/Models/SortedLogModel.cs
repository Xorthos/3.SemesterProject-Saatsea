using Proxy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace CustomerManagement.Models
{
    public class SortedLogModel
    {
        public List<Log> Logs { get; set; }

        public LogState? CurrentState { get; set;}
        public SortCriteria SortCriteria { get; set; }

      public SortedLogModel()
      {
          SortCriteria = SortCriteria.Both;
      }

        public void Sort(IEnumerable<Log> logs)
        {
            Logs = (List<Log>)logs;
            FilterState();
            FilterCriteria();
        }

        private void FilterCriteria()
        {
            switch (SortCriteria)
            {
                case SortCriteria.Both:
                    return;
                    break;
                case SortCriteria.Export:
                    Logs = Logs.Where(c => !c.Import).ToList();
                    break;
                case SortCriteria.Import:
                    Logs = Logs.Where(c => c.Import).ToList();
                    break;

            }
                
        }

        private void FilterState()
        {
            if (CurrentState == null)
            {
                return;
            }
            else
            {
                Logs = (List<Log>) Logs.Where(c => c.LogState.Equals(CurrentState)).ToList();
            }
        }
    }
}