using _Common.StateMachines.Interfaces;
using UnityEngine;

namespace _Common.StateMachines
{
    public abstract class BaseState<TOwner> : IState
    {
        protected readonly TOwner owner;
        protected readonly Transform transform;

        protected BaseState(TOwner owner)
        {
            this.owner = owner;
            transform = owner is Component component ? component.transform : null;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public virtual void Enter()
        {
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public virtual void Exit()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual void Update(float deltaTime)
        {
        }

        public virtual void OnCollisionEnter2D(Collision2D other)
        {
        }

        public virtual void OnDisable()
        {
            Exit();
        }
    }
}