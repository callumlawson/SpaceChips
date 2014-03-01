using System;
using UnityEngine;

namespace Assets.Scripts.Visualisation.NewStyle
{
    class TurretComponentView : TypedComponentView<BasicTurret>
    {
        private const float LazerLength = 200.0f;
        private LineRenderer lazer;

        protected override void Initialize()
        {
            ComponentModel.LazerFired += VisualiseLazerFiring;
        }

        void Start()
        {
            lazer = GetComponent<LineRenderer>();
            if (lazer == null)
            {
                Debug.LogError("Turret visualiser expected a line renderer but did not find one.");
            }
        }

        private void Update()
        {
            SetPosition();
        }

        private void SetPosition()
        {
            gameObject.transform.position = new Vector2(Ship.PositionX, Ship.PositionY);
        }

        private void VisualiseLazerFiring()
        {
            VisualiseLazerFiring(gameObject.transform.position, gameObject.transform.position + (gameObject.transform.rotation * Vector3.right * LazerLength));
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
