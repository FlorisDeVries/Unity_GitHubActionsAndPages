using _Common.Extensions;
using Cameras.Resources;
using GameManagement;
using GameManagement.Resources;
using UnityEngine;
using UserInput.Resources;

namespace Cameras
{
    public class CameraFollowTarget : MonoBehaviour
    {
        [SerializeField] private float _maxDistanceFromPlayer = 5;
        private CameraTargetData _cameraTargetData;
        private MouseData _mouseData;
        private GameManager _gameManager; 
        
        private void OnEnable()
        {
            _gameManager = GameManager.Instance;
            _cameraTargetData = CameraTargetData.Instance;
            _mouseData = MouseData.Instance;

            _cameraTargetData.FollowTarget = transform;
        }

        private void OnValidate()
        {
            _cameraTargetData = CameraTargetData.Instance;
            _mouseData = MouseData.Instance;

            _cameraTargetData.FollowTarget = transform;
        }
        
        private void Update()
        {
            var parent = transform.parent;
            var targetPosition = parent.position.MidpointTo(_mouseData.WorldPosition, _maxDistanceFromPlayer);
            transform.position = targetPosition;
        }
    }
}