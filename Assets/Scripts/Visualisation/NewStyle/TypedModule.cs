using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Visualisation.NewStyle
{
    abstract class TypedModule <TComponentType> : MonoBehaviour, IModule
    {
        protected TComponentType componentModel;
        protected Ship ship;

        public void Initialize(Ship ship, Component basicTurret)
        {
            //Shenaggans + cast
            Initialize();
        }

        protected abstract void Initialize();
    }
}
