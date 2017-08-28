using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public int totalHp = 100;
    public int currentHp;
    public GameObject enemyToRemove;
    public GameObject itemPrefab;

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
        if (currentHp <= 0)
        {
            Destroy(enemyToRemove);
            
        }
        
    }

    public void Damage(int amount = 10)
    {
        currentHp -= amount;
        var i = (float) amount / 100;
        GetComponent<Image>().fillAmount -= i;
    }

    private void OnDestroy()
    {
        var positionX = transform.position.x + Random.Range(-1, 1);
        var positionY = transform.position.y + Random.Range(-1, 1);
        Instantiate(itemPrefab, new Vector2(positionX, positionY), Quaternion.identity);
    }
}