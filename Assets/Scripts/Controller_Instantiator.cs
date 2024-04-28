using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject instantiatePos;
    public GameObject shieldPowerUp;
    public float respawningTimer;
    public float shieldRespawnTimer;
    private float time = 0;

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2;
        shieldRespawnTimer = 2f;     
    }

    void Update()
    {
        SpawnEnemies();
        ChangeVelocity();
        SpawnShield();
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime;
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f);
    }

    private void SpawnEnemies()
    {
        respawningTimer -= Time.deltaTime;

        if (respawningTimer <= 0)
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform);
            respawningTimer = UnityEngine.Random.Range(2, 6);
        }
    }

    private void SpawnShield()
    {
        shieldRespawnTimer -= Time.deltaTime;


        if (shieldRespawnTimer <= 0)
        {
            if (UnityEngine.Random.Range(0, 5) == 3)
            {
                Instantiate(shieldPowerUp, instantiatePos.transform);
                /*No logro darle una posición diferente en "y" para que no se solape con los enemigos.
                 Si trato de darle una posición absoluta usando Vector3, me tira error de sintaxis.*/

                shieldRespawnTimer = 10f;
            }
            else shieldRespawnTimer = 2f;
        }
    }
}
