using UnityEngine;
using UnityEngine.UI;

public class Resources : MonoBehaviour
{
    public static Text goldAmountText;
    public static Text foodAmountText;
    public static int goldAmount = 1000;
    public static int foodAmount = 100;

    private void Start()
    {
        SetGoldText();
        SetFoodText();
    }

    public static void AddFood(int amount)
    {
        foodAmount += amount;
        SetFoodText();
    }

    public static void AddGold(int amount)
    {
        goldAmount += amount;
        SetGoldText();
    }

    public static void SetGoldText()
    {
        GameObject.Find("UI/GoldAmountText").GetComponent<Text>().text = "Gold: " + goldAmount;
    }

    public static void SetFoodText()
    {
        GameObject.Find("UI/FoodAmountText").GetComponent<Text>().text = "Food: " + foodAmount;
    }
}