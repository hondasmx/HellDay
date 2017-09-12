using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    public GameObject player;


    public void Damage(float amount = 10)
    {
        PlayerStats.currentHp -= amount;
        GetComponent<Image>().fillAmount = PlayerStats.currentHp / PlayerStats.totalHp;
    }

    private void FixedUpdate()
    {
        //Реген в секунду
        Damage(-PlayerStats.hpRegenPerSecond * Time.deltaTime);


        //А это урон в секунду, пока ебалом торгуешь около врага
        var enemy = PlayerMovement.clickedEnemy;
        if (enemy != null)
        {
            var enemyPosition = enemy.transform;
            var distance = Vector2.Distance(player.transform.position, enemyPosition.transform.position);
            if (distance <= 1f)
            {
                Damage(enemy.GetComponentInChildren<EnemyBehaviour>().dps * Time.deltaTime);
            }
        }
        
        
    }
}