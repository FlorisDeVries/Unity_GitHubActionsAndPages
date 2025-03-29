using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Common.Unity.Resources
{
    [CreateAssetMenu(fileName = "SceneSelfReference", menuName = "Project/GameManagement/SceneSelfReference")]
    public class SceneSelfReference : UnityScene
    {
        public override string Name => SceneManager.GetActiveScene().name;
    }
}