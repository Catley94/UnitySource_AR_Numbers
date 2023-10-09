using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    
    //Serialised for debugging
    [SerializeField] private Button[] buttons;

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
        foreach (Button _button in buttons)
        {
            _button.interactable = true;
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
            GameObject.Find("GameManager").GetComponent<AvailableNumbers>().OnNewActiveNumber.AddListener(OnNewNumber);
        }

        private int GenerateRandomAlternativeNumber()
        {
            return Random.Range(0, 11);
        }

        private void OnNewNumber(int activeNumber)
        {
            string activeNumberToString = IntToString(activeNumber);
            string alternativeOption1 = IntToString(GenerateRandomAlternativeNumber());
            string alternativeOption2 = IntToString(GenerateRandomAlternativeNumber());
            string alternativeOption3 = IntToString(GenerateRandomAlternativeNumber());
            
            List<int> buttonIndexesUpdated = new List<int>();
            
            while(alternativeOption1 == activeNumberToString)
            {
                alternativeOption1 = IntToString(GenerateRandomAlternativeNumber());
            }
            
            while(alternativeOption2 == activeNumberToString)
            {
                alternativeOption2 = IntToString(GenerateRandomAlternativeNumber());
            }
            
            while(alternativeOption3 == activeNumberToString)
            {
                alternativeOption3 = IntToString(GenerateRandomAlternativeNumber());
            }

            SetupFirstButton(alternativeOption1);

            SetupSecondButton(alternativeOption2);

            SetupThirdButton(alternativeOption3);

            SetupCorrectOptionButton(activeNumberToString);
        }

        private void SetupCorrectOptionButton(string activeNumberToString)
        {
            int randomIndex = Random.Range(0, buttons.Length);
            transform.GetChild(randomIndex).GetComponentInChildren<TMP_Text>().text = activeNumberToString;
            transform.GetChild(randomIndex).GetComponent<Button>().onClick.RemoveAllListeners();
            transform.GetChild(randomIndex).GetComponent<Button>().onClick.AddListener(GameObject.Find("GameManager")
                .GetComponent<AnswerSelection>().ActiveNumberCompleted);
        }

        private void SetupThirdButton(string alternativeOption3)
        {
            transform.GetChild(2).GetComponentInChildren<TMP_Text>().text = alternativeOption3;
            transform.GetChild(2).GetComponent<Button>().onClick.RemoveAllListeners();
            transform.GetChild(2).GetComponent<Button>().onClick.AddListener(GameObject.Find("GameManager")
                .GetComponent<AnswerSelection>().ActiveNumberIncomplete);
        }

        private void SetupSecondButton(string alternativeOption2)
        {
            transform.GetChild(1).GetComponentInChildren<TMP_Text>().text = alternativeOption2;
            transform.GetChild(1).GetComponent<Button>().onClick.RemoveAllListeners();
            transform.GetChild(1).GetComponent<Button>().onClick.AddListener(GameObject.Find("GameManager")
                .GetComponent<AnswerSelection>().ActiveNumberIncomplete);
        }

        private void SetupFirstButton(string alternativeOption1)
        {
            transform.GetChild(0).GetComponentInChildren<TMP_Text>().text = alternativeOption1;
            transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();
            transform.GetChild(0).GetComponent<Button>().onClick.AddListener(GameObject.Find("GameManager")
                .GetComponent<AnswerSelection>().ActiveNumberIncomplete);
        }

        private string IntToString(int number)
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
                    break;
            }
            return numberString;
        }

        private void SetupReferences()
        {
            buttons = GetComponentsInChildren<Button>();
        }

    #endregion
    
    
    
    

}
