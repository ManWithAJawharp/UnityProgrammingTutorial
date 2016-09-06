using UnityEngine;
using System.Collections;

public class GlobalStateManager : MonoBehaviour
{
    public enum State
    {
        FlashyIntro, ThreeHourCutscene, Game, Pause, GameOver
    }

    //  Delegate: reference to a method with arguments (State newState, State oldState) and return type void
    public delegate void OnStateChangeEvent(State newState, State oldState);
    /// <summary>Occurs on state change, do not use SetState in this.</summary>
    public static event OnStateChangeEvent OnStateChanged;

    private State currentState = State.FlashyIntro;

    public State CurrentState
    {
        get { return currentState; }
    }

    public void SetState(State newState)
    {
        //  Don't change the current state to itself.
        if (currentState == newState) return;

        //  Keep track of the previous state.
        State oldState = currentState;
        //  Assign the current state.
        currentState = newState;

        //  Call OnStateChanged event if it has at least one subscriber.
        if (OnStateChanged != null)
        {
            //  Pass new and previous state as arguments.
            OnStateChanged(newState, oldState);
        }
    }
}