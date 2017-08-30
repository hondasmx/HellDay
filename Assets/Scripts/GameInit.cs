using System.Collections;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public GameObject enemy;

    // Use this for initialization
    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        Vector2[] enemyPositions = {new Vector2(-6, -3), new Vector2(-4, -3), new Vector2(-2, -3), new Vector2(0, -3) };
        foreach (var position in enemyPositions)
        {
            Instantiate(enemy, position, Quaternion.identity);
        }
        
    }
}