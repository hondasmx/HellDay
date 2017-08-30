using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

	
	
    public static GameObject clickedEnemy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * 3;
        if (clickedEnemy != null)
        {
            MoveToEnemy(clickedEnemy);
        }
    }


    public void MoveToEnemy(GameObject enemy)
    {
        if (isInDistance(enemy)) return;
        var movement = new Vector2(enemy.transform.position.x - transform.position.x , enemy.transform.position.y - transform.position.y);
        transform.Translate(movement * Time.deltaTime);
    }


    private bool isInDistance(GameObject enemy)
    {
        return Vector2.Distance(enemy.transform.position, transform.position) <= 0.9f;
    }
    
    
}