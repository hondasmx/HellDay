using UnityEngine;
using UnityEngine.UI;

public class MarketItem: MonoBehaviour
{
    public Text itemNameText;
    public Text itemAmountText;
    [HideInInspector]
    public string itemName;
    [HideInInspector]
    public string itemAmount;
    [HideInInspector]
    public Resources.ResourceType resourceType;

    public void SetItemName(string _itemName)
    {
        itemName = _itemName;
        itemNameText.text = itemName;
    }

    public void SetItemAmount(string _itemAmount)
    {
        itemAmount = _itemAmount;
        itemAmountText.text = itemAmount;
    }
    
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject.Find("SelectedMarketItem").GetComponent<SelectedMarketItem>().SetValues(resourceType);
        }
    }
    
    
}