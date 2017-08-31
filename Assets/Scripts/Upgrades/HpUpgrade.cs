using System;
using UnityEngine;
using UnityEngine.UI;

public class HpUpgrade : MonoBehaviour
{
    public int[] levelValues = {110, 122, 136, 154, 174, 199, 229, 265, 308, 360};
    public int[] levelUpCost = {50, 115, 200, 309, 452, 638, 879, 1193, 1601, 2131};
    public Text buttonText;
    public Text currentLevelValueText;
    public Text levelUpValue;
    public int currentLevel;

    private void Start()
    {
        PlayerStats.SetDps(levelValues[currentLevel]);
        UpdateText();
    }

    public void LevelUp()
    {
        if (isEnoughResourcesForLevelUp())
        {
            Resources.AddResource(-levelUpCost[currentLevel], Resources.ResourceType.gold);
            currentLevel++;
            PlayerStats.SetHp(levelValues[currentLevel]);
            UpdateText();
        }
    }

    private bool isEnoughResourcesForLevelUp()
    {
        return levelUpCost[currentLevel] <= Resources.resources[Resources.ResourceType.gold];
    }

    private void UpdateText()
    {
        levelUpValue.text = "+" + (levelValues[currentLevel + 1] - levelValues[currentLevel]);
        currentLevelValueText.text = "Current HP: " + PlayerStats.totalHp;
        buttonText.text = levelUpCost[currentLevel].ToString();
    }
}