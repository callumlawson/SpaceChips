//using UnityEngine;
//
//namespace Assets.Scripts.Visualisation.Visualisers
//{
//    class ScannerVisualiser : MonoBehaviour
//    {
//        private const float RotationRate = 5.0f;
//        private Vector2 position;
//
//        public void SetPosition(Vector2 scannerPosition)
//        {
//            position = scannerPosition;
//        }
//
//        void Update()
//        {
//            SetRotation();
//            SetPosition();
//        }
//
//        private void SetPosition()
//        {
//            gameObject.transform.position = position;
//        }
//
//        private void SetRotation()
//        {
//            var rotation = gameObject.transform.rotation;
//            gameObject.transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + RotationRate);
//        }
//    }
//}
