using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemNamesAndPickup : MonoBehaviour
{
    public Text itemNameText;
    private int goldAmount;
    private int foodAmount;
    private string itemName;


    public void Start()
    {
        itemName = "Gold " + goldAmount;
        itemNameText.text = itemName;
    }

    private void OnMouseUp()
    {
        Resources.AddGold(goldAmount);
        StartCoroutine(PickupText.ShowMessage(itemName));
        StartCoroutine(Destroy());

    }

    private IEnumerator Destroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<Canvas>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}