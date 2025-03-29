using UnityEngine;

namespace _Common.StateMachines
{
    public abstract class MonoBehaviourState<T> : BaseState<T> where T : MonoBehaviour
    {
        protected new readonly Transform transform;
        protected readonly GameObject gameObject;
        
        protected MonoBehaviourState(T owner) : base(owner)
        {
            transform = owner.transform;
            gameObject = owner.gameObject;
        }
    }
}