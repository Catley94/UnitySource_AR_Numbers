using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorrectSelectionMessage : MonoBehaviour
{
    #region Public

        public void Show()
        {
            GetComponent<TMP_Text>().enabled = true;
        }

        public void Hide()
        {
            GetComponent<TMP_Text>().enabled = false;
        }

    #endregion
}
