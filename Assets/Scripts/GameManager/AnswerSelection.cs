using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnswerSelection : MonoBehaviour
{
   
    [SerializeField] private CorrectSelectionMessage correctSelectionMessage;
    [SerializeField] private IncorrectSelectionMessage incorrectSelectionMessage;
    [SerializeField] private MainNumber mainNumber;
    [SerializeField] private OptionsManager optionsManager;
    [SerializeField] private float buttonsDisabledForXSeconds;
    
    [HideInInspector] public UnityEvent OnActiveNumberComplete = new UnityEvent();
    [HideInInspector] public UnityEvent OnActiveNumberIncomplete = new UnityEvent();
    

    #region Public

        
        public void ActiveNumberIncomplete()
        {
            StartCoroutine(ShowMessageIncorrect());
        }
        
        public void ActiveNumberCompleted()
        {
            StartCoroutine(ShowMessageCorrect());
        }

    #endregion
    
    #region Private

    private IEnumerator ShowMessageCorrect()
    {
        optionsManager.DisableAllButtons();
        mainNumber.Hide();
        correctSelectionMessage.Show();
        yield return new WaitForSeconds(buttonsDisabledForXSeconds);
        correctSelectionMessage.Hide();
        mainNumber.Show();
        OnActiveNumberComplete?.Invoke();
        optionsManager.EnableAllButtons();
    }
    
    private IEnumerator ShowMessageIncorrect()
    {
        optionsManager.DisableAllButtons();
        mainNumber.Hide();
        incorrectSelectionMessage.Show();
        yield return new WaitForSeconds(buttonsDisabledForXSeconds);
        incorrectSelectionMessage.Hide();
        mainNumber.Show();
        OnActiveNumberIncomplete?.Invoke();
        optionsManager.EnableAllButtons();
    }

    #endregion
    
}
