using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float totalHp = 100;
    public float dps = 10;
    public float currentHp;
    public GameObject[] itemPrefabs;
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
        if (PlayerMovement.clickedEnemy != null)
        {
            if (distance <= 1f && isAlive && transform.parent.transform.parent.transform.parent.transform ==
                PlayerMovement.clickedEnemy.transform)
            {
                currentHp -= PlayerStats.dps * Time.deltaTime;
            }
        }
        else
        {
            currentHp = totalHp;
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
        foreach (var prefab in itemPrefabs)
        {
            var positionX = transform.position.x + Random.Range(-1.0f, 1.0f);
            var positionY = transform.position.y + Random.Range(-1.0f, 1.0f);
            Instantiate(prefab, new Vector2(positionX, positionY), Quaternion.identity);
        }

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
        }
        else
        {
            enemy.GetComponent<CircleCollider2D>().enabled = false;
            enemy.GetComponent<SpriteRenderer>().enabled = false;
            enemy.GetComponentInChildren<Canvas>().enabled = false;
        }
    }
}