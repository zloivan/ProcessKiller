using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.ObjectModel;


namespace MainLayer
{
    public class Processes
    {
            public enum SortDirection
            {
                Ascending,
                Discending
            }

            Process[] proc;
            ObservableCollection<Process> _openProc; 
            public Processes()
            {
                proc= Process.GetProcesses();
                _openProc= new ObservableCollection<Process>();
                foreach(var i in proc)
                {
                    _openProc.Add(i);
                }
            }

            public ObservableCollection<Process> ProcessesItems
            {
                get{return _openProc;}
            }
            public void RefreshProcesses()
            {
                proc =  Process.GetProcesses();
                _openProc = new ObservableCollection<Process>();
                foreach (var i in proc)
                {
                    _openProc.Add(i);
                }
            }
            //Timer timer = new Timer(DoCountProcesses, o, 500, 500);
            //ThreadPool.QueueUserWorkItem(o=>DoCountProcesses());
            //var task =  queue
            public Process this[int index]
            {
                get{return _openProc[index];}
            }

            public void KillChosenProcesses(string name)
            {
                for(int i=0;i<_openProc.Count;i++)
                {
                    if(_openProc[i].ProcessName==name)
                        _openProc[i].Kill();
                }
            }

            public IOrderedEnumerable<Process> SortProcessesByName(SortDirection direction)
            {
                if(direction == SortDirection.Ascending)
                {
                    var temp = from c in _openProc
                           orderby c.ProcessName  ascending
                           select c;
                           return temp;
                }
                else
                {
                    var temp = from c in _openProc
                               orderby c.ProcessName descending
                               select c;
                    return temp;
                }
            }
           
           
        public int DoCountProcesses()
        {
          return _openProc.Count;
            
        }

            
            
            
        }

        
    
}
