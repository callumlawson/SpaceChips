using System;
using UnityEngine;

//Dis be prototype and evil!


//ShipBrain - this contains the chips   Add chip  Kill the brain
public class Simulation
{
    private bool isRunning = false;

    public Simulation(EngineEvents engineEvents)
    {
        engineEvents.OnUpdate += OnUpdate;
    }

    public event Action ClockEdge;
    public event Action AfterClockEdge;

    public void Start()
    {
        isRunning = true;
        Debug.Log("Simulation Started");
    }

    public void Stop()
    {
        isRunning = false;
        Debug.Log("Simulation Stopped");
    }

    private void OnUpdate()
    {
        if (isRunning)
        {
            ClockEdge.Invoke();
            AfterClockEdge.Invoke();
        }
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