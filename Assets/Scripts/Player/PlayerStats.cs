using UnityEngine;

public class PlayerStats : MonoBehaviour
{

	public static float dps = 50;
	public static float currentHp = 100;
	public static float totalHp = 100;
	public static float hpRegenPerSecond = 3;

	private void Update()
	{
		if (currentHp >= totalHp)
		{
			currentHp = totalHp;
		}
		if (currentHp <= 0)
		{
			transform.position = Vector3.zero;
			PlayerMovement.clickedEnemy = null;
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

	public static bool IsHealing()
	{
		return GameObject.Find("Player").transform.position == Vector3.zero;
	}
	
}
