using UnityEngine;

public class GameInit : MonoBehaviour
{

	public GameObject enemy;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Random.Range(2,4); i++)
		{
			var position = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));
			Instantiate(enemy, position, Quaternion.identity);
		}
	}

}
