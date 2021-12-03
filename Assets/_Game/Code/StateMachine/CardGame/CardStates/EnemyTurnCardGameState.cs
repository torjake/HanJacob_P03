using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyTurnCardGameState : CardGameState
{
    public static event Action EnemyTurnBegan;
    public static event Action EnemyTurnEnded;

    public static event Action AttackPlayer;

    [SerializeField] float _pauseDuration = 1.5f;

    public int _enemyHealth = 10;

    bool _wasAttacked;

    private void Start()
    {
        PlayerTurnCardGameState.PlayerAttack += EnemyTakeDamage;
    }
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
        if (_enemyHealth <= 0)
        {
            EnemyTurnEnded?.Invoke();
            StateMachine.ChangeState<WinStateCardGame>();
        }
        else 
        {
            int _picker = Random.Range(0, 3);
            if (_picker == 0)
            {
                Attack();
            }
            else if (_picker == 1)
            {
                Defend();
            }
            else
            {
                Heal();
            }
            EnemyTurnEnded?.Invoke();
            // turn over. Go back to Player.
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
    }
    public void Attack() 
    {
        AttackPlayer?.Invoke();
        _wasAttacked = false;
    }
    public void Defend() 
    {
        if (_wasAttacked == true) 
        {
            _enemyHealth += 4;
            _wasAttacked = false;
        }
    }
    public void Heal() 
    {
        _enemyHealth += 2;
        _wasAttacked = false;
    }
    private void EnemyTakeDamage() 
    {
        _enemyHealth -= 3;
        _wasAttacked = true;
    }
}
