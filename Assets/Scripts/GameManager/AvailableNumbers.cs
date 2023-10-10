using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AvailableNumbers : MonoBehaviour
{
    
    public List<int> availableNumbers = new List<int>(){1,2,3,4,5,6,7,8,9,10};
    private int _activeNumber = -1;
    
    [SerializeField] private TMP_Text activeNumberText;
    
    [HideInInspector] public UnityEvent<int> OnNewActiveNumber = new UnityEvent<int>();
    
    #region Public

        public int GetActiveNumberOnScreen()
        {
            return _activeNumber;
        }

        public List<int> GetRemainingNumbers()
        {
            return availableNumbers;
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
            availableNumbers.Remove(_activeNumber);
            SelectNextNumber();
        }

        private void IncorrectSelection()
        {
            
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

        private void SelectNextNumber()
        {
            if (availableNumbers.Count == 0)
            {
                /*
                 * If all numbers have been shown and completed.
                 * Show congratulations text and hide the active number text.
                 */
                activeNumberText.enabled = false;
                GetComponent<GameOver>().Show();
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
                _activeNumber = newRandomNumber;
                activeNumberText.text = _activeNumber.ToString();
                OnNewActiveNumber?.Invoke(_activeNumber);
            }
        }
    
    #endregion
    
        
}
