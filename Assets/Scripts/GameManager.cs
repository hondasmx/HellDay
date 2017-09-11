using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject marketView;
    public GameObject selectedMarketItem;
    public GameObject marketItems;
    
    public void CloseMarket()
    {
        marketView.SetActive(false);
        selectedMarketItem.SetActive(false);
        marketItems.SetActive(false);
    }

    public void OpenMarket()
    {
        marketView.SetActive(true);
        selectedMarketItem.SetActive(true);
        marketItems.SetActive(true);
    }
}