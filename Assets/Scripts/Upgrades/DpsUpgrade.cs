using UnityEngine;
using UnityEngine.UI;

public class DpsUpgrade : MonoBehaviour
{

	public int[] levelValues = {18, 22, 26, 31, 37, 45, 54, 64, 77, 93};
	public int[] levelUpCost = {100, 210, 331, 464, 611, 772, 949, 1144, 1358, 1594};
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
			PlayerStats.SetDps(levelValues[currentLevel]);
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
		currentLevelValueText.text = "Current DPS: " + PlayerStats.dps;
		buttonText.text = levelUpCost[currentLevel].ToString();
	}
}
