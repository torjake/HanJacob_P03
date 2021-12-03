using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTurnCardGameState : CardGameState
{

    public static event Action PlayerTurnBegan;
    public static event Action PlayerTurnEnded;

    public static event Action PlayerAttack;
    //
    int _currentCard = 1;
    int _numberOfCards = 3;
    //
    [SerializeField] GameObject _loseCard = null;
    [SerializeField] GameObject _winCard = null;
    [SerializeField] GameObject _SkipCard = null;
    [SerializeField] GameObject _cardManager = null;
    //
    public float _playerHealth = 10;
    //
    public GameObject _attackMarker;
    public GameObject _defendMarker;
    public GameObject _healMarker;
    //private EnemyTurnCardGameState _enem;

    bool _isDefending;
    private void Start()
    {
        //_enem = GetComponent<EnemyTurnCardGameState>();
        //_enem.Attack += TakeDamage();
        EnemyTurnCardGameState.AttackPlayer += TakeDamage;
    }
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
        StateMachine.Input.PressedMouseOne += LeftMousePressed;
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
        StateMachine.Input.PressedMouseOne -= LeftMousePressed;
        //

        print("Player Turn: Exiting...");
    }
    void TakeDamage() 
    {
        if (_isDefending == false)
        {
            _playerHealth -= 3;
        }
        else 
        {
            _playerHealth += 1;
            _isDefending = false;
        }
        //
    }
    void LeftMousePressed() 
    {
        /*
        Ray _myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _cardHitInfo;

        if (Physics.Raycast(_myRay, out _cardHitInfo, 100)) 
        {
            
        }
        */
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
        //
        if (_currentCard == 1) 
        {
            _isDefending = false;
            PlayerAttack?.Invoke();
            StateMachine.ChangeState<EnemyTurnCardGameState>();
            
        }
        //StateMachine.ChangeState<LoseStateCardGame>();

        if (_currentCard == 2) 
        {
            _isDefending = true;
            StateMachine.ChangeState<EnemyTurnCardGameState>();
        }
        //StateMachine.ChangeState<WinStateCardGame>();

        if (_currentCard == 3) 
        {
            _isDefending = false;
            _playerHealth += 1;
            StateMachine.ChangeState<EnemyTurnCardGameState>();
        }
            //StateMachine.ChangeState<EnemyTurnCardGameState>();
    }

    private void Update()
    {
        if (_currentCard == 1) 
        {
            //attack
            _attackMarker.SetActive(true);
            _defendMarker.SetActive(false);
            _healMarker.SetActive(false);
        }
        if (_currentCard == 2)
        {
            //defend
            _attackMarker.SetActive(false);
            _defendMarker.SetActive(true);
            _healMarker.SetActive(false);
        }
        if (_currentCard == 3)
        {
            //heal
            _attackMarker.SetActive(false);
            _defendMarker.SetActive(false);
            _healMarker.SetActive(true);
        }
        //
        if (_playerHealth <= 0)
        {
            StateMachine.ChangeState<LoseStateCardGame>();
        }
    }
}
