using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    protected bool InTransition { get; private set; }

    State _currentState;
    protected State _previosState;

    public void ChangeState<T>() where T : State 
    {
        T targetState = GetComponent<T>();
        if (targetState == null) 
        {
            print("State null error");
            return;
        }
        InitiateStateChange(targetState);
    }
    public void RevertState() 
    {
        if (_previosState != null) 
        {
            InitiateStateChange(_previosState);
        }
    }
    void InitiateStateChange(State targetState) 
    {
        Transition(targetState);
    }
    void Transition(State newState) 
    {
        // start transition
        InTransition = true;
        // transitioning
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
        // end transition
        InTransition = false;
    }
    private void Update()
    {
        if (CurrentState != null && !InTransition) 
        {
            CurrentState.Tick();
        }
    }
}
