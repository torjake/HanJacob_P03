using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    [SerializeField] float _pauseDuration = 1.5f;

    public override void Enter()
    {
        print("Enemy Turn: ...Enter");
        EnemyTurnBegan?.Invoke();

        StartCoroutine(EnemyThinkingRoutine(_pauseDuration));
    }
    public override void Exit()
    {
        print("Enemy Turn: Exit...");
    }

    IEnumerator EnemyThinkingRoutine(float pauseDuration) 
    {
        print("Enemy thinking...");
        yield return new WaitForSeconds(pauseDuration);

        print("Enemy performs action");
        EnemyTurnEnded?.Invoke();
        // turn over. Go back to Player.
        StateMachine.ChangeState<PlayerTurnCardGameState>();
    }
}
