using System;
using UnityEngine;
using UnityEngine.UI;

public class PickupText : MonoBehaviour
{
    #region Singleton

    public static PickupText instance;

    #endregion

    public delegate void ChangePickupText(string name);

    public static ChangePickupText PickupTextChangeCallback;


    void Update()
    {
        if (PickupTextChangeCallback != null)
        {
            GetComponent<Text>().text = "Asdasd" + PickupTextChangeCallback;    
        }
        
    }
}