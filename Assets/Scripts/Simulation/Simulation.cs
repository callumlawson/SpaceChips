using System;
using System.Timers;
using UnityEngine;

//Dis be prototype and evil!

internal class Simulation
{
    private const int IntervalInMillis = 20;
    private readonly Timer timer = new Timer();

    public Simulation()
    {
        SetupClock();
    }

    public event Action ClockEdge;
    public event Action AfterClockEdge;

    public void Start()
    {
        timer.Enabled = true;
        Debug.Log("Simulation Started");
    }

    public void Stop()
    {
        timer.Enabled = false;
        Debug.Log("Simulation Stopped");
    }

    private void SetupClock()
    {
        timer.Interval = IntervalInMillis;
        timer.Elapsed += OnClockEdge;
    }

    private void OnClockEdge(object source, ElapsedEventArgs e)
    {
        ClockEdge.Invoke();
        AfterClockEdge.Invoke();
    }
}

//For Later fun times
//
//internal struct WorkItem : IComparable<WorkItem>
//{
//    public int WorkTime;
//    public Action WorkAction;
//
//    public int CompareTo(WorkItem other)
//    {
//        return WorkTime.CompareTo(other.WorkTime);
//    }
//}
//        public void AfterDelay(int delay, Action workAction)
//        {
//            Insert(
//                new WorkItem
//                {
//                    WorkTime = CurrentTime + delay,
//                    WorkAction = workAction
//                }
//                );
//        }
//
//        private void Insert(WorkItem workItem)
//        {
//            Agenda.Add(workItem);
//            Agenda.Sort();
//        }
//
//        private void Next()
//        {
//            var currentWorkItem = Agenda.First();
//            CurrentTime = currentWorkItem.WorkTime;
//            Agenda.First().WorkAction();
//            Agenda.RemoveAt(0);
//        }
//
//        public void Run()
//        {
//            AfterDelay(0, () => Debug.Log("Simulation Started"));
//
//            while (Agenda.Any())
//            {
//                Next();
//            }
//        }