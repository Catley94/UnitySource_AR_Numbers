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
            
            List<int> buttonIndexesUpdated = new List<int>();
            
            while(alternativeOption1 == activeNumberToString)
            {
                alternativeOption1 = IntToString(GenerateRandomAlternativeNumber());
            }
            
            while(alternativeOption2 == activeNumberToString)
            {
                alternativeOption2 = IntToString(GenerateRandomAlternativeNumber());
            }

            for (int i = 0; i < buttons.Length - 1; i++)
            {
                int randomIndex = Random.Range(0, buttons.Length);
                
                while(buttonIndexesUpdated.Contains(randomIndex))
                {
                    randomIndex = Random.Range(0, buttons.Length);
                }
                
                buttonIndexesUpdated.Add(randomIndex);
                transform.GetChild(randomIndex).GetComponent<TMP_Text>().text = alternativeOption1;
            }
            
            

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
