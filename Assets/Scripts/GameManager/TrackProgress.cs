using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackProgress : MonoBehaviour
{
    
    private int percentCorrect = 0;
    private bool pickedIncorrectly = false;
    
    [SerializeField] private GameObject showPercentCorrectButton;
    [SerializeField] private TMP_Text percentCorrectText;

    #region Public

        public int GetPercentCorrect()
        {
            return percentCorrect;
        }

        public void ShowPercentScreen()
        {
            percentCorrectText.text = $"You scored {percentCorrect}%!";
            percentCorrectText.enabled = true;
            showPercentCorrectButton.SetActive(false);
            GetComponent<GameOver>().Hide();
            HidePercentCorrectButton();
        }

        private void HidePercentCorrectButton()
        {
            showPercentCorrectButton.GetComponent<Image>().enabled = false;
            showPercentCorrectButton.GetComponent<Button>().enabled = false;
            showPercentCorrectButton.GetComponentInChildren<TMP_Text>().enabled = false;
        }

        #endregion

    #region Private

        // Start is called before the first frame update
        void Start()
        {
            SubToEvents();
        }
        
        private void SubToEvents()
        {
            GetComponent<AnswerSelection>().OnActiveNumberComplete.AddListener(CorrectSelection);
            GetComponent<AnswerSelection>().OnActiveNumberIncomplete.AddListener(IncorrectSelection);
        }

        private void CorrectSelection()
        {
            //TODO: Make Dyanimc - currnetly statically tracks the percent by adding 10% each time, not ideal, need to make this dynamic.
            pickedIncorrectly = false;
            percentCorrect += 10;
        }

        private void IncorrectSelection()
        {
            if (!pickedIncorrectly)
            {
                pickedIncorrectly = true;
                percentCorrect -= 10;
            }
        }
        
    #endregion
    
}
