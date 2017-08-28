using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemNamesAndPickup : MonoBehaviour
{
    public Text itemNameText;
    public Text itemPickupText;
    private string[] firstNames = {"Sword", "Axe", "Dildo", "Polearm"};
    private string[] lastNames = {"Stringth", "Agility", "Madness", "Speed", "Weakness"};
    private string itemName;


    public void Start()
    {
        //itemPickupText = GameObject.Find("UI/ItemPickupText").GetComponent<Text>();
        var firstNameIndex = Random.Range(0, firstNames.Length);
        var lastNameIndex = Random.Range(0, lastNames.Length);
        var firstName = firstNames[firstNameIndex];
        var lastName = lastNames[lastNameIndex];
        itemName = firstName + " of " + lastName;
        itemNameText.text = itemName;
    }

    private void OnMouseUp()
    {
        StartCoroutine(ItemPickUp());
       
    }

    IEnumerator ItemPickUp()
    {
        
        gameObject.SetActive(false);
        //itemPickupText.text = "Picked up " + itemName;
        PickupText.PickupTextChangeCallback += UpdateIO;
        yield return new WaitForSeconds(1);
        itemPickupText.text = "";
        
        //Destroy(gameObject);
    }

    public void UpdateIO(string name)
    {
        print(name);
    }
}