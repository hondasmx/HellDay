using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public int totalHp = 100;
    public int currentHp;

    // Use this for initialization
    void Start()
    {
        currentHp = totalHp;
    }

    private void Update()
    {
        var playerPosition = GameObject.Find("Player");
        var distance = Vector2.Distance(gameObject.transform.position, playerPosition.transform.position);
        if (distance < 1.5f)
        {
            Damage(playerPosition.GetComponent<PlayerBehaviour>().dps);    
        }
        
    }

    public void Damage(int amount = 10)
    {
        currentHp -= amount;
        var i = (float) amount / 100;
        GetComponent<Image>().fillAmount -= i;
    }
}