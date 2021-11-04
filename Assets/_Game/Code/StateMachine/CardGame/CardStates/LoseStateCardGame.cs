using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LoseStateCardGame : CardGameState
{
    public static event Action PlayerLoseStart;
    public static event Action PlayerLoseEnd;

    public override void Enter()
    {
        PlayerLoseStart?.Invoke();
        //
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedCancel += OnPressedCancel;
        //

    }
    public override void Exit()
    {
        PlayerLoseEnd?.Invoke();
        //
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedCancel -= OnPressedCancel;
        //

    }
    void OnPressedConfirm() 
    {
        // restart game
        StateMachine.ChangeState<SetupCardGameState>();
    }
    void OnPressedCancel() 
    {
        // back to menu
        SceneManager.LoadScene(0);
    }
}
