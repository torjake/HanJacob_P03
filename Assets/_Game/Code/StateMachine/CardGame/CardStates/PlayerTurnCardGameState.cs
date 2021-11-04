using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTurnCardGameState : CardGameState
{

    public static event Action PlayerTurnBegan;
    public static event Action PlayerTurnEnded;
    //
    int _currentCard = 1;
    int _numberOfCards = 3;
    //
    [SerializeField] GameObject _loseCard = null;
    [SerializeField] GameObject _winCard = null;
    [SerializeField] GameObject _SkipCard = null;
    [SerializeField] GameObject _cardManager = null;
    

    public override void Enter()
    {
        print("Player Turn: ...Entering");

        // brodcast PlayerTurnBegan
        PlayerTurnBegan?.Invoke();
        // move cards up
        _cardManager.transform.position = new Vector3(1, -1.34f, 0);
        // hook into events
        StateMachine.Input.PressedConfirm += OnPressedConfirm;
        StateMachine.Input.PressedLeft += LeftPress;
        StateMachine.Input.PressedRight += RightPress;
    }
    public override void Exit()
    {
        // brodcast PlayerTurnEnded
        PlayerTurnEnded?.Invoke();
        // move cards down
        _cardManager.transform.position = new Vector3(1, -4.47f, 0);
        // unhook from event
        StateMachine.Input.PressedConfirm -= OnPressedConfirm;
        StateMachine.Input.PressedLeft -= LeftPress;
        StateMachine.Input.PressedRight -= RightPress;

        print("Player Turn: Exiting...");
    }
    void LeftPress() 
    {
        if (_currentCard <= 1)
        {
            _currentCard = _numberOfCards;
        }
        else 
        {
            _currentCard -= 1;
        }
        
    }
    void RightPress() 
    {
        if (_currentCard >= _numberOfCards)
        {
            _currentCard = 1;
        }
        else 
        {
            _currentCard += 1;
        }
        
    }
    void OnPressedConfirm() 
    {
        if(_currentCard == 1)
            StateMachine.ChangeState<LoseStateCardGame>();

        if (_currentCard == 2)
            StateMachine.ChangeState<WinStateCardGame>();

        if (_currentCard == 3)
            StateMachine.ChangeState<EnemyTurnCardGameState>();
    }

    private void Update()
    {
        if (_currentCard == 1) 
        {
            print("Lose Card Selected");
        }
        if (_currentCard == 2)
        {
            print("Win Card Selected");
        }
        if (_currentCard == 3)
        {
            print("Skip Card Selected");
        }
    }
}
