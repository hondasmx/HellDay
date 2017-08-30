using UnityEngine;

public class OnEnemyClick : MonoBehaviour {

	
	
	// Update is called once per frame
	private void OnMouseOver()
	{
		if (Input.GetMouseButton(0))
		{
			PlayerMovement.clickedEnemy = gameObject;
		}
	}
	
	
}
