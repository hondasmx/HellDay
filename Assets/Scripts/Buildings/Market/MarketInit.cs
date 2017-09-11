using System;
using UnityEngine;

public class MarketInit : MonoBehaviour
{
    public GameObject marketItem;
    public GameObject parentFolder;

    private void Start()
    {
        MarketItemInit();
    }

    public void MarketItemInit()
    {
        var startX = -5.0f;
        var startY = 0.0f;
        foreach (Resources.ResourceType resource in Enum.GetValues(typeof(Resources.ResourceType)))
        {
            if (resource == Resources.ResourceType.gold) continue;

            marketItem.GetComponent<MarketItem>().SetItemAmount(Resources.resources[resource].ToString());
            marketItem.GetComponent<MarketItem>().SetItemName(Resources.GetName(resource));
            marketItem.GetComponent<MarketItem>().resourceType = resource;
            Instantiate(marketItem, new Vector3(startX, startY), Quaternion.identity, parentFolder.transform);
            startX += 2.0f;
            if (startX >= 4.0f)
            {
                startX = -5.0f;
                startY += 1.0f;
            }
        }
    }

    public void Update()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("MarketItem"))
        {
            var resourceType = item.GetComponent<MarketItem>().resourceType;
            item.GetComponent<MarketItem>().SetItemAmount(Resources.resources[resourceType].ToString());
        }
    }

}