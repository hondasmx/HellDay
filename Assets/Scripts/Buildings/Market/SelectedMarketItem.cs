using UnityEngine;
using UnityEngine.UI;

public class SelectedMarketItem : MonoBehaviour
{
    
    public Text itemNameText;
    public Text itemAmountText;
    public Text sellValueText;
    private int sellValue;
    private int itemAmount;
    private Resources.ResourceType selectedItem;

    public void SetValues(Resources.ResourceType _selectedItem)
    {
        itemNameText.text = Resources.GetName(_selectedItem);
        itemAmount = Resources.GetResourceAmount(_selectedItem) / 2;
        sellValue = Resources.GetSellValue(_selectedItem) * itemAmount;
        UpdateValues();
        selectedItem = _selectedItem;
    }

    public void DecreaseValue()
    {
        if (itemAmount <= 0) return;
        itemAmount--;
        sellValue -= Resources.GetSellValue(selectedItem);
        UpdateValues();
    }

    public void IncreaseValue()
    {
        if (Resources.GetResourceAmount(selectedItem) <= itemAmount) return;
        itemAmount++;
        sellValue += Resources.GetSellValue(selectedItem);
        UpdateValues();
    }

    public void SellResources()
    {
        Resources.AddResource(-itemAmount, selectedItem);
        Resources.AddResource(sellValue, Resources.ResourceType.gold);
        itemAmount = 0;
        sellValue = 0;
        UpdateValues();
    }

    private void UpdateValues()
    {
        sellValueText.text = sellValue + "g";
        itemAmountText.text = itemAmount.ToString();
    }
    
}