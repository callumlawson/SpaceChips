using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Visualisation.NewStyle
{
    class ScannerComponentView : TypedComponentView<BasicTurret>
    {
        private const float RotationRate = 3.0f;

        protected override void Initialize()
        {
        }

        private void Update()
        {
            SetPosition();
            SetRotation();
        }

        private void SetPosition()
        {
            gameObject.transform.position = new Vector2(Ship.PositionX, Ship.PositionY);
        }

        private void SetRotation()
        {
            var rotation = gameObject.transform.rotation;
            gameObject.transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + RotationRate);
        }
    }
}
