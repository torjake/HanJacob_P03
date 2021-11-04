using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetupCardGameState : CardGameState
{
    [SerializeField] int _startingCardNumber = 10;
    [SerializeField] int _numberOfPlayers = 2;

    bool _activated = false;

    public override void Enter()
    {
        print("Setup: ...Entering");
        print("Creating " + _numberOfPlayers + " players.");
        print("Creating deck with " + _startingCardNumber + " cards.");
        // Cant change state while still in Enter() /Exit() transition
        // Dont put ChangeState<> here
        _activated = false;
    }

    public override void Tick()
    {
        // this should probably be controlled by input or something other then a bool but it works so
        if (_activated == false)
        {
            _activated = true;
            StateMachine.ChangeState<PlayerTurnCardGameState>();
        }
    }

    public override void Exit()
    {
        _activated = false;
        print("Setup: Exiting...");
    }

}
