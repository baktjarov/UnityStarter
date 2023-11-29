using UnityEngine;

namespace Characters
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private Transform _objectToRotate;
        [SerializeField] private Transform _cameraObject;
        [SerializeField] private float _sensitivity = 0.25f;
        [SerializeField] private float _minCameraAngle = -65f;
        [SerializeField] private float _maxCameraAngle = 65f;
        private float _currentCameraYAngle;

        public void Update()
        {
            if (_objectToRotate == null)
            {
                _objectToRotate = GetComponent<Transform>();
            }

            Rotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        private void Rotate(float xAngle, float yAngle)
        {
            xAngle = xAngle * _sensitivity; 
            _objectToRotate.Rotate(new Vector3(0, xAngle, 0)); 

            yAngle = yAngle * _sensitivity; 
            _currentCameraYAngle = _currentCameraYAngle - yAngle;

            _currentCameraYAngle = Mathf.Clamp(_currentCameraYAngle, _minCameraAngle, _maxCameraAngle);
            _cameraObject.localRotation = Quaternion.Euler(_currentCameraYAngle, 0, 0);
        }
    }
}