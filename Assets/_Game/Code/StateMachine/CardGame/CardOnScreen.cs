using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOnScreen : MonoBehaviour
{
    [SerializeField] GameObject _cardManager = null;
    //
    bool _isPlayerState = false;
    private void OnEnable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan += OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded += OnPlayerTurnEnded;
    }

    private void OnDisable()
    {
        PlayerTurnCardGameState.PlayerTurnBegan -= OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded -= OnPlayerTurnEnded;
    }

    void OnPlayerTurnBegan() 
    {
        _cardManager.transform.position = new Vector3(1, -0.04f, 0);
        _isPlayerState = true;
    }
    void OnPlayerTurnEnded() 
    {
        _cardManager.transform.position = new Vector3(1, -2.96f, 0);
        _isPlayerState = false;
    }
}
