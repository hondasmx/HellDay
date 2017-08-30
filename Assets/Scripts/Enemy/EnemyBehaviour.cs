using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float totalHp = 100;
    public float dps = 10;
    public float currentHp;
    public GameObject itemPrefab;
    public GameObject enemy;
    public bool isAlive = true;
//    public GameObject spawnTimer;


    // Use this for initialization
    void Start()
    {
        currentHp = totalHp;
    }

    private void Update()
    {
        var player = GameObject.Find("Player");
        var distance = Vector2.Distance(enemy.transform.position, player.transform.position);
        GetComponent<Image>().fillAmount = currentHp / totalHp;
        if (distance <= 1f && PlayerMovement.clickedEnemy != null && isAlive)

        {
            currentHp -= PlayerStats.dps * Time.deltaTime;
        }
        if (currentHp <= 0)
        {
            StartCoroutine(WaitForRespawn());
        }
        ToggleVisibility();

    }


    private IEnumerator WaitForRespawn()
    {
        PlayerMovement.clickedEnemy = null;
        currentHp = totalHp;
        isAlive = false;
        var positionX = transform.position.x + Random.Range(-1, 1);
        var positionY = transform.position.y + Random.Range(-1, 1);
        Instantiate(itemPrefab, new Vector2(positionX, positionY), Quaternion.identity);
        yield return new WaitForSeconds(5);
        isAlive = true;
    }

    private void ToggleVisibility()
    {
        if (isAlive)
        {
            enemy.GetComponent<CircleCollider2D>().enabled = true;
            enemy.GetComponent<SpriteRenderer>().enabled = true;
            enemy.GetComponentInChildren<Canvas>().enabled = true;
//            Instantiate(spawnTimer, gameObject.transform.position, Quaternion.identity);
        }
        else
        {
            enemy.GetComponent<CircleCollider2D>().enabled = false;
            enemy.GetComponent<SpriteRenderer>().enabled = false;
            enemy.GetComponentInChildren<Canvas>().enabled = false;
//            Destroy(spawnTimer);
        }
    }
}