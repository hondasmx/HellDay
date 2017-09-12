using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static GameObject clickedEnemy;


    void FixedUpdate()
    {
        if (clickedEnemy != null)
        {
            MoveToEnemy(clickedEnemy);
        }
    }


    public void MoveToEnemy(GameObject enemy)
    {
        //Если не отрегенился или уже в зоне врага - заканчиваем движение (или не начинаем)
        if (PlayerStats.currentHp < PlayerStats.totalHp & PlayerStats.IsHealing()) return;
        if (isInDistance(enemy)) return;
        
        var movement = new Vector2(enemy.transform.position.x - transform.position.x,
            enemy.transform.position.y - transform.position.y);
        transform.Translate(movement * Time.deltaTime);
    }


    private bool isInDistance(GameObject enemy)
    {
        return Vector2.Distance(enemy.transform.position, transform.position) <= 0.9f;
    }
}