using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOverMessage : MonoBehaviour
{

    #region Public

    public void PlayPromptToSelectNumber()
    {
        //TODO: Play voice over "Choose the correct option from the available buttons"
    }

    public void PlayCorrectSelection()
    {
        //TODO: Play voice over "Congratulations, you got it right!"
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
            GetComponent<AvailableNumbers>().OnNewActiveNumber.AddListener(OnNewNumber);
        }

        private void OnNewNumber(int activeNumber)
        {
            //TODO: Play voice over "Say the number out loud"
        }
        

        #endregion
    
    
}
