using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    
    private Button[] buttons;
    
    private GameObject gameManager;

    #region Public

        public void DisableAllButtons()
        {
            foreach (Button _button in buttons)
            {
                _button.interactable = false;
            }
        }
        
        public void EnableAllButtons()
        {
            if (!gameManager.GetComponent<GameOver>().IsGameOver())
            {
                foreach (Button _button in buttons)
                {
                    _button.interactable = true;
                }
            }
            else
            {
                ClearAllButtonText();
            }
        }

    #endregion
    
    #region Private

        // Start is called before the first frame update
        void Start()
        {
            SetupReferences();
            SubToEvents();
        }

        private void SubToEvents()
        {
            gameManager.GetComponent<AvailableNumbers>().OnNewActiveNumber.AddListener(OnNewNumber);
            gameManager.GetComponent<GameOver>().OnGameOver.AddListener(DisableAllButtons);
        }

        private void ClearAllButtonText()
        {
            foreach (Button _button in buttons)
            {
                _button.GetComponentInChildren<TMP_Text>().text = "";
            }
        }

        private int GenerateRandomAlternativeNumber()
        {
            return Random.Range(1, 11);
        }

        private void OnNewNumber(int activeNumber)
        {
            
            for (int i = 0; i < buttons.Length; i++)
            {
                SetupButton(i, activeNumber);
            }

            SetupCorrectOptionButton(activeNumber);
        }

        private void SetupCorrectOptionButton(int activeNumber)
        {
            int randomIndex = Random.Range(0, buttons.Length);
            SetButtonText(randomIndex, IntToNameString(activeNumber));
            ResetButtonListeners(randomIndex);
            AddActiveNumberCompleteListener(randomIndex);
        }

        private void AddActiveNumberCompleteListener(int randomIndex)
        {
            transform.GetChild(randomIndex).GetComponent<Button>().onClick.AddListener(gameManager
                .GetComponent<AnswerSelection>().ActiveNumberCompleted);
        }

        private void SetupButton(int childIndex, int activeNumber)
        {
            string numberString = IntToNameString(GenerateRandomAlternativeNumber());
            
            while(numberString == IntToNameString(activeNumber))
            {
                numberString = IntToNameString(GenerateRandomAlternativeNumber());
            }
            
            SetButtonText(childIndex, numberString);
            ResetButtonListeners(childIndex);
            AddActiveNumberIncompleteListener(childIndex);
        }

        private void AddActiveNumberIncompleteListener(int childIndex)
        {
            transform.GetChild(childIndex).GetComponent<Button>().onClick.AddListener(gameManager
                .GetComponent<AnswerSelection>().ActiveNumberIncomplete);
        }

        private void ResetButtonListeners(int childIndex)
        {
            transform.GetChild(childIndex).GetComponent<Button>().onClick.RemoveAllListeners();
        }

        private void SetButtonText(int childIndex, string numberString)
        {
            transform.GetChild(childIndex).GetComponentInChildren<TMP_Text>().text = numberString;
        }

        private string IntToNameString(int number)
        {
            string numberString = "";
            
            switch (number)
            {
                case 1:
                    numberString = "One";
                    break;
                case 2:
                    numberString = "Two";
                    break;
                case 3:
                    numberString = "Three";
                    break;
                case 4:
                    numberString = "Four";
                    break;
                case 5:
                    numberString = "Five";
                    break;
                case 6:
                    numberString = "Six";
                    break;
                case 7:
                    numberString = "Seven";
                    break;
                case 8:
                    numberString = "Eight";
                    break;
                case 9:
                    numberString = "Nine";
                    break;
                case 10:
                    numberString = "Ten";
                    break;
                default:
                    numberString = "";
                    Debug.LogWarning($"Number not found {number}");
                    break;
            }
            return numberString;
        }

        private void SetupReferences()
        {
            buttons = GetComponentsInChildren<Button>();
            gameManager = GameObject.Find("GameManager");
        }

    #endregion
    
    
    
    

}
