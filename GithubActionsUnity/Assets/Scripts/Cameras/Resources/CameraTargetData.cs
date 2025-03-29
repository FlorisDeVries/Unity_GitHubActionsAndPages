using _Common.BaseClasses;
using UnityEngine;

namespace Cameras.Resources
{
    [CreateAssetMenu(fileName = "CameraTargetData", menuName = "Cameras/CameraTargetData")]
    public class CameraTargetData : ASingletonResource<CameraTargetData>
    {
        protected override string ResourcePath => "Cameras/CameraTargetData";

        public Transform FollowTarget;
    }
}
