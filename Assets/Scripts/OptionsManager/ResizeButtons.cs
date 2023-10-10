using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeButtons : MonoBehaviour
{
    #region Private

        private void Start()
        {
            foreach (Transform _button in transform)
            {
                _button.localScale = new Vector3(Screen.width * 0.0025f, Screen.width * 0.0025f, 1f);
            }
        }

    #endregion
}
