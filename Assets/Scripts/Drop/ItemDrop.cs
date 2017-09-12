using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour
{
    public Text itemNameText;
    public int resourceAmount;
    public Resources.ResourceType resourceType;
    public int dropChance;
    
    private string itemName;

    public void Start()
    {
        var chance = Random.Range(0, 100);
        if (chance > dropChance)
        {
            Destroy(gameObject);
        }
        itemName = Resources.GetName(resourceType);
        itemNameText.text = itemName + resourceAmount;
    }

    private void OnMouseUp()
    {
        Resources.AddResource(resourceAmount, resourceType);
        StartCoroutine(PickupText.ShowMessage(itemName + " " + resourceAmount));
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