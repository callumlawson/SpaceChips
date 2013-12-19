using System;
using System.Timers;
using UnityEngine;

//Dis be prototype and evil!

namespace Assets.Scripts.Simulation
{
    internal class Simulation
    {
        public event Action ClockEdge;

        private readonly Timer timer = new Timer();
        private const int IntervalInMillis = 20;

        public Simulation()
        {
            SetupClock();
        }

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
        }
    }
}

//For Later
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