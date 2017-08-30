using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public static float dps = 30;
	public static float currentHp = 100;
	public static float totalHp = 100;
	public static float hpRegenPerSecond = 3;

	private void Update()
	{
		if (currentHp >= totalHp)
		{
			currentHp = totalHp;
		}
	}

	public static void SetDps(float amount)
	{
		dps = amount;
	}

	public static void SetHp(float amount)
	{
		totalHp = amount;
	}
}
