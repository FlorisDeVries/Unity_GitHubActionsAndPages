using Unity.Cinemachine;
using UnityEngine;
using UserInput.Resources;

namespace Cameras
{
    public class CameraZoom : MonoBehaviour
    {
        [Header("Camera Distance")]
        [SerializeField]
        private float _lerpMultiplier = 5f;

        [SerializeField]
        private float _zoomMultiplier = 2f;

        [SerializeField]
        private Vector2 _minMaxCameraDistance = new(20, 40);

        private CinemachinePositionComposer _followProperties;
        private float _targetDistance;

        private void OnEnable()
        {
            _followProperties= GetComponent<CinemachinePositionComposer>();
            _targetDistance = _followProperties.CameraDistance;

            GameplayInputActions.Instance.ZoomAction.OnValueChanged += Zoom;
        }

        private void OnDisable()
        {
            GameplayInputActions.Instance.ZoomAction.OnValueChanged -= Zoom;
        }

        private void Zoom(float zoomValue)
        {
            _targetDistance -= Mathf.Clamp(zoomValue, -1, 1) * _zoomMultiplier;
            _targetDistance = Mathf.Clamp(_targetDistance, _minMaxCameraDistance.x, _minMaxCameraDistance.y);
        }

        private void Update()
        {
            _followProperties.CameraDistance = Mathf.Lerp(_followProperties.CameraDistance, _targetDistance,
                _lerpMultiplier * Time.deltaTime);
        }
    }
}