using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace _Common.StateMachines
{
    public class FiniteStateMachine<TStateType, TOwner, TState> where TState : BaseState<TOwner>
    {
        private readonly Dictionary<TStateType, TState> _states;
        public TState CurrentState { get; private set; }
        public TStateType CurrentStateType { get; private set; }
        public UnityAction OnStateChanged = delegate { };

        public FiniteStateMachine(Dictionary<TStateType, TState> states)
        {
            _states = states;
        }

        public void ChangeState(TStateType nextState, bool force = false)
        {
            if (!force && CurrentStateType.Equals(nextState))
            {
                return;
            }

            if (!_states.ContainsKey(nextState))
            {
                throw new ArgumentOutOfRangeException(nameof(nextState),
                    "State was not found in the states dictionary");
            }

            CurrentState?.Exit();
            CurrentStateType = nextState;
            CurrentState = _states[nextState];
            CurrentState?.Enter();
            OnStateChanged.Invoke();
        }
        
        public void SetState(TStateType stateType, TState state)
        {
            _states[stateType] = state;
        }

        public void FixedUpdate()
        {
            CurrentState?.FixedUpdate();
        }
        
        public void Update(float deltaTime)
        {
            CurrentState?.Update(deltaTime);
        }

        public void Cleanup()
        {
            CurrentState?.Exit();
            
            foreach (var state in _states)
            {
                state.Value.OnDisable();
            }
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            CurrentState?.OnCollisionEnter2D(other);
        }
    }
}