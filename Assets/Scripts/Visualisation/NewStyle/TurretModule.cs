﻿using System;
using UnityEngine;

namespace Assets.Scripts.Visualisation.NewStyle
{
    class TurretModule : TypedModule<BasicTurret>
    {
        private const float LazerLength = 200.0f;
        private LineRenderer lazer;

        protected override void Initialize()
        {
            componentModel.LazerFired += VisualiseLazerFiring;
        }

        void Start()
        {
            lazer = GetComponent<LineRenderer>();
            if (lazer == null)
            {
                Debug.LogError("Turret visualiser expected a line renderer but did not find one.");
            }
        }

        public void Update()
        {
            gameObject.transform.position = new Vector2(ship.PositionX, ship.PositionY);
        }
      
        public void VisualiseLazerFiring()
        {
            VisualiseLazerFiring(gameObject.transform.position, gameObject.transform.position + (gameObject.transform.rotation * Vector3.forward * LazerLength));
            Invoke("TurnOffTheLazor", 1.0f);
        }

        private void VisualiseLazerFiring(Vector2 origin, Vector2 destination)
        {
            lazer.SetPosition(0, new Vector3(origin.x, origin.y));
            lazer.SetPosition(1, new Vector3(destination.x, destination.y));
        }

        //Called by invoke method
        private void TurnOffTheLazor()
        {
            lazer.SetPosition(0, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0));
            lazer.SetPosition(1, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0));
        }
    }
}
