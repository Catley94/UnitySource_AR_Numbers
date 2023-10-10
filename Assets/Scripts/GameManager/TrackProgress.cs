using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrackProgress : MonoBehaviour
{

    //TODO: Serializing for debugging
    [SerializeField] private int percentCorrect = 0;
    [SerializeField] private int round = 0;
    [SerializeField] private bool pickedIncorrectly = false;
    
    [SerializeField] private GameObject showPercentCorrectButton;
    [SerializeField] private TMP_Text percentCorrectText;

    #region Public

        public int GetPercentCorrect()
        {
            return percentCorrect;
        }

        public void ShowPercentScreen()
        {
            //TODO: Update Percent screen text
            percentCorrectText.text = $"You scored {percentCorrect}%!";
            //TODO: Show Percent Screen
            percentCorrectText.enabled = true;
            //TODO: Hide Percent Button
            showPercentCorrectButton.SetActive(false);
            //TODO: Hide end game text
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
            //Statically tracks the percent by adding 10% each time, not ideal, need to make this dynamic.
            round++;
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
