using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PickupText : MonoBehaviour
{
    private static Text pickUpText;

    private void Start()
    {
        pickUpText = GetComponent<Text>();
    }

    public static IEnumerator ShowMessage(string itemName)
    {
        pickUpText.text = "Picked up " + itemName;
        yield return new WaitForSeconds(1);
        pickUpText.text = "";
    }

}