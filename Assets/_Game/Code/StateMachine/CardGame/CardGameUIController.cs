using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardGameUIController : MonoBehaviour
{
    [SerializeField] Text _enemyThinkingTextUI = null;
    [SerializeField] Text _playerTurnCountTextUI = null;
    [SerializeField] Text _PlayerWonTextUI = null;
    [SerializeField] Text _playerLoseTextUI = null;

    int _playerTurnCount = 0;

    private void OnEnable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan += OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded += OnEnemyTurnEnded;
        //
        PlayerTurnCardGameState.PlayerTurnBegan += OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded += OnPlayerTurnEnded;
        //
        LoseStateCardGame.PlayerLoseStart += OnPlayerLoseBegan;
        LoseStateCardGame.PlayerLoseEnd += OnPlayerLoseEnded;
        //
        WinStateCardGame.PlayerWinStart += OnPlayerWinBegan;
        WinStateCardGame.PlayerWinEnd += OnPlayerWinEnded;
    }
    private void OnDisable()
    {
        EnemyTurnCardGameState.EnemyTurnBegan -= OnEnemyTurnBegan;
        EnemyTurnCardGameState.EnemyTurnEnded -= OnEnemyTurnEnded;
        //
        PlayerTurnCardGameState.PlayerTurnBegan -= OnPlayerTurnBegan;
        PlayerTurnCardGameState.PlayerTurnEnded -= OnPlayerTurnEnded;
        //
        LoseStateCardGame.PlayerLoseStart -= OnPlayerLoseBegan;
        LoseStateCardGame.PlayerLoseEnd -= OnPlayerLoseEnded;
        //
        WinStateCardGame.PlayerWinStart -= OnPlayerWinBegan;
        WinStateCardGame.PlayerWinEnd -= OnPlayerWinEnded;
    }

    private void Start()
    {
        //make sure text is disabled on start
        _enemyThinkingTextUI.gameObject.SetActive(false);
        _playerTurnCountTextUI.gameObject.SetActive(false);
        _playerLoseTextUI.gameObject.SetActive(false);
        _PlayerWonTextUI.gameObject.SetActive(false);
    }
    void OnEnemyTurnBegan()
    {
        _enemyThinkingTextUI.gameObject.SetActive(true);
    }
    void OnEnemyTurnEnded() 
    {
        _enemyThinkingTextUI.gameObject.SetActive(false);
    }
    //----
    void OnPlayerTurnBegan ()
    {
        _playerTurnCountTextUI.gameObject.SetActive(true);
        _playerTurnCount++;

        _playerTurnCountTextUI.text = "Player Turn: " + _playerTurnCount.ToString();
    }
    void OnPlayerTurnEnded() 
    {
        _playerTurnCountTextUI.gameObject.SetActive(false);
    }
    //----
    void OnPlayerLoseBegan() 
    {
        _playerLoseTextUI.gameObject.SetActive(true);
    }
    void OnPlayerLoseEnded() 
    {
        _playerLoseTextUI.gameObject.SetActive(false);
    }
    //----
    void OnPlayerWinBegan() 
    {
        _PlayerWonTextUI.gameObject.SetActive(true);
    }
    void OnPlayerWinEnded() 
    {
        _PlayerWonTextUI.gameObject.SetActive(false);
    }
}
