using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

	public int dps = 1;

	// Update is called once per frame
	void FixedUpdate () {
		var rb = GetComponent<Rigidbody2D>();
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");
		var movement = new Vector3(moveHorizontal, moveVertical, moveVertical);
		rb.velocity = movement * 3;
	}
}
