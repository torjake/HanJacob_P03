using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class WinStateCardGame : CardGameState
{
    public static event Action PlayerWinStart;
    public static event Action PlayerWinEnd;
    public override void Enter()
    {
        PlayerWinStart?.Invoke();
        //
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedCancel += OnPressedCancel;
        //

    }
    public override void Exit()
    {
        PlayerWinEnd?.Invoke();
        //
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedCancel -= OnPressedCancel;
        //

    }
    void OnPressedConfirm() 
    {
        // Replay game
        StateMachine.ChangeState<SetupCardGameState>();
    }
    void OnPressedCancel() 
    {
        // back to main menu
        SceneManager.LoadScene(0);
    }
}
