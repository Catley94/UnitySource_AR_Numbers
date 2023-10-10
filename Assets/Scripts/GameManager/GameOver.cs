using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] private TMP_Text endGameCongratulationsText;
    [SerializeField] private GameObject showPercentCorrectButton;

    private bool _gameOver;
    public UnityEvent OnGameOver = new UnityEvent();

    #region Public

    public void Show()
    {
        endGameCongratulationsText.enabled = true;
        showPercentCorrectButton.GetComponent<Image>().enabled = true;
        showPercentCorrectButton.GetComponent<Button>().enabled = true;
        showPercentCorrectButton.GetComponentInChildren<TMP_Text>().enabled = true;
        _gameOver = true;
        OnGameOver?.Invoke();
    }
    
    public void Hide()
    {
        endGameCongratulationsText.enabled = false;
    }

    public bool IsGameOver()
    {
        return _gameOver;
    }

    #endregion
    
    #region Private

    private void Start()
    {
        // showPercentCorrectButton.GetComponent<Image>().enabled = false;
        // showPercentCorrectButton.GetComponent<Button>().enabled = false;
        // showPercentCorrectButton.GetComponentInChildren<TMP_Text>().enabled = false;
    }

    #endregion
}
