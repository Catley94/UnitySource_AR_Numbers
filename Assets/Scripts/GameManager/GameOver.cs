using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] private TMP_Text endGameCongratulationsText;

    private bool _gameOver;
    public UnityEvent OnGameOver = new UnityEvent();

    #region Public

    public void Show()
    {
        endGameCongratulationsText.enabled = true;
        _gameOver = true;
        OnGameOver?.Invoke();
    }

    public bool IsGameOver()
    {
        return _gameOver;
    }

    #endregion
    
    #region Private

    

    #endregion
}
