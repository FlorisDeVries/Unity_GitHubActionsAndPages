using Cameras.Resources;
using UnityEngine;

namespace Cameras
{
    public class CopyFollowTarget : MonoBehaviour
    {
        private CameraTargetData _cameraTargetData;

        private void OnEnable()
        {
            _cameraTargetData = CameraTargetData.Instance;
        }
        
        private void Update()
        {
            if (!_cameraTargetData.FollowTarget) return;

            transform.position = _cameraTargetData.FollowTarget.position;
        }

        private void OnValidate()
        {
            _cameraTargetData = CameraTargetData.Instance;
            if (Application.isPlaying || !_cameraTargetData.FollowTarget) return;

            transform.position = _cameraTargetData.FollowTarget.position;
        }
    }
}