using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCard : MonoBehaviour
{

    private void OnEnable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan += OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded += OnPlayerTurnEnded;
        //
        
    }

    private void OnDisable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan -= OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded -= OnPlayerTurnEnded;
    }

    void OnPlayerTurnBegan() 
    {
        
    }
    void OnPlayerTurnEnded() 
    {

    }
}
