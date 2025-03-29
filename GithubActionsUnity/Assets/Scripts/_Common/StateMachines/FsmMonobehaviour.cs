using System.Collections.Generic;
using UnityEngine;

namespace _Common.StateMachines
{
    public abstract class FsmMonobehaviour<TState, TOwner, TStateType> : MonoBehaviour where TStateType : BaseState<TOwner>
    {
        public FiniteStateMachine<TState, TOwner, TStateType> StateMachine { get; protected set; }
        
        protected virtual void OnEnable()
        {
            InitializeStateMachine();
        }

        protected virtual void OnDisable()
        {
            StateMachine.Cleanup();
        }
        
        protected void SetStateMachine(Dictionary<TState, TStateType> states)
        {
            StateMachine = new FiniteStateMachine<TState, TOwner, TStateType>(states);
        }

        protected void SetState(TState state, TStateType stateType)
        {
            StateMachine.SetState(state, stateType);
        }

        protected abstract void InitializeStateMachine();
        
        protected virtual void FixedUpdate()
        {
            StateMachine?.FixedUpdate();
        }
        
        protected virtual void Update()
        {
            StateMachine?.Update(Time.deltaTime);
        }
        
        protected virtual  void OnCollisionEnter2D(Collision2D other)
        {
            StateMachine?.OnCollisionEnter2D(other);
        }
    }
}