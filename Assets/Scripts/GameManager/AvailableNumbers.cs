using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AvailableNumbers : MonoBehaviour
{
    
    public List<int> availableNumbers = new List<int>(){1,2,3,4,5,6,7,8,9,10};
    //SerializeField for Debugging Purposes
    [SerializeField] int activeNumber = -1;
    
    [SerializeField] private TMP_Text activeNumberText;
    [SerializeField] private TMP_Text endGameCongratulationsText;
    
    public UnityEvent<int> OnNewActiveNumber = new UnityEvent<int>();
    
    #region Public

        public int GetActiveNumberOnScreen()
        {
            return activeNumber;
        }

        public List<int> GetRemainingNumbers()
        {
            return availableNumbers;
        }
        
        public void SelectNextNumber()
        {
            if (availableNumbers.Count == 0)
            {
                /*
                 * If all numbers have been shown and completed.
                 * Show congratulations text and hide the active number text.
                 */
                activeNumberText.enabled = false;
                endGameCongratulationsText.enabled = true;
            }
            else
            {
                /*
                 * Select random number from availableNumbers list.
                 * Set activeNumber to the new random number.
                 * Update number on screen in AR space.
                 * Invoke event
                 */
                int newRandomNumber = GetNewNumber();
                activeNumber = newRandomNumber;
                activeNumberText.text = activeNumber.ToString();
                OnNewActiveNumber?.Invoke(activeNumber);
            }
        }

    #endregion

    #region Private

        // Start is called before the first frame update
        void Start()
        {
            SubToEvents();
            SelectNextNumber();
        }

        private void SubToEvents()
        {
            GetComponent<AnswerSelection>().OnActiveNumberComplete.AddListener(CorrectSelection);
            GetComponent<AnswerSelection>().OnActiveNumberIncomplete.AddListener(IncorrectSelection);
        }

        private void CorrectSelection()
        {
            availableNumbers.Remove(activeNumber);
            SelectNextNumber();
        }

        private void IncorrectSelection()
        {
            GetComponent<AvailableNumbers>().SelectNextNumber();
        }

        private int GetNewNumber()
        {
            if (availableNumbers.Count > 0)
            {
                int randomIndex = Random.Range(0, availableNumbers.Count);
                return availableNumbers[randomIndex];
            }

            return -1;
        }

        // Update is called once per frame
        void Update()
        {
                
        }
    
    #endregion
    
        
}
