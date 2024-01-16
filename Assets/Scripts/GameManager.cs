using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject energyBall;
    [SerializeField] GameObject flyer;
    [SerializeField] GameObject scarab;
    [SerializeField] GameObject battleCruiser;
    [SerializeField] GameObject nairan;
    [SerializeField] GameObject dreadnought;
    [SerializeField] GameObject Bosses;
    [SerializeField] GameObject asteroids;

    [SerializeField] GameObject pauseMenu;

    protected ObjectPool energyBallPool;
    [SerializeField] string energyBallPoolName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }
    void Start()
    {
        GameObject op = GameObject.Find(energyBallPoolName);
        energyBallPool = op.GetComponent<ObjectPool>();

        StartCoroutine(SpawnEnemyCoroutine());
    }
    //private IEnumerator SpawnEnemyCoroutine()
    //{

    //    //SpawnEnemies(boss, 1, true, arrayPoolEnemy[3]);

    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn(4, 1);
    //    AsteroidSpawner(3);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn(4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    AsteroidSpawner(4);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn(4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn(4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    AsteroidSpawner(5);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn(4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    EnergyBallSpawn( 4, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    AsteroidSpawner(3);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    AsteroidSpawner(3);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn(2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn(2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn(2, 1);
    //    AsteroidSpawner(3);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn(2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(1f);
    //    SpawnEnemies(scarab, 2, 1);
    //    EnergyBallSpawn( 2, 1);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(flyer, 2, 2);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 2, 2);
    //    AsteroidSpawner(6);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 2, 2);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 2, 2);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 5, 2);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 5, 2);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 5, 2);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 5, 2);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(flyer, 5, 2);
    //    AsteroidSpawner(5);
    //    yield return new WaitForSeconds(3f);
    //    SpawnEnemies(battleCruiser, 2, 3);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(battleCruiser, 2, 3);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(nairan, 1, 1);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(nairan, 1, 1);
    //    SpawnEnemies(nairan, 1, 1);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(nairan, 1, 1);
    //    SpawnEnemies(battleCruiser, 2, 3);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(flyer, 5, 2);
    //    SpawnEnemies(energyBall, 4, 1);
    //    SpawnEnemies(battleCruiser, 2, 3);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(flyer, 5, 2);
    //    AsteroidSpawner(3);
    //    SpawnEnemies(energyBall, 4, 1);
    //    SpawnEnemies(battleCruiser, 2, 3);
    //    yield return new WaitForSeconds(5f);
    //    SpawnEnemies(flyer, 5, 2);
    //    SpawnEnemies(energyBall, 4, 1);
    //    SpawnEnemies(battleCruiser, 2, 3);
    //    yield return new WaitForSeconds(5f);
    //    AsteroidSpawner(5);

    //    SpawnEnemies(Bosses, 2, 1);

    //}

    private IEnumerator SpawnEnemyCoroutine()
    {
        
        AsteroidSpawner(5);
        EnergyBallSpawn(3, 1);
        yield return new WaitForSeconds(3f);
        EnergyBallSpawn(3, 1);
        AsteroidSpawner(2);
        yield return new WaitForSeconds(4f);
        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);
        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        SpawnEnemies(flyer, 2, 2);
        yield return new WaitForSeconds(5f);
        AsteroidSpawner(2);
        yield return new WaitForSeconds(4f);
        SpawnEnemies(flyer, 2, 2);
        AsteroidSpawner(3);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(flyer, 2, 2);
        yield return new WaitForSeconds(5f);

        SpawnEnemies(dreadnought, 2, 3);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(5f);

        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);
        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);

        SpawnEnemies(nairan, 2, 1);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);

        SpawnEnemies(flyer, 4, 2);
        EnergyBallSpawn(2, 1);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(nairan, 2, 1);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(flyer, 4, 2);
        AsteroidSpawner(2);
        EnergyBallSpawn(2, 1);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(dreadnought, 2, 3);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);
        AsteroidSpawner(5);
        EnergyBallSpawn(3, 1);
        yield return new WaitForSeconds(3f);
        EnergyBallSpawn(3, 1);
        AsteroidSpawner(2);
        yield return new WaitForSeconds(4f);
        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);
        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        SpawnEnemies(flyer, 2, 2);
        yield return new WaitForSeconds(5f);
        AsteroidSpawner(2);
        yield return new WaitForSeconds(4f);
        SpawnEnemies(flyer, 2, 2);
        AsteroidSpawner(3);
        yield return new WaitForSeconds(5f);
        SpawnEnemies(flyer, 2, 2);
        yield return new WaitForSeconds(5f);

        SpawnEnemies(dreadnought, 2, 3);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(5f);

        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);
        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);

        SpawnEnemies(nairan, 2, 1);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(scarab, 2, 1);
        EnergyBallSpawn(1, 1);
        yield return new WaitForSeconds(3f);

        SpawnEnemies(flyer, 4, 2);
        EnergyBallSpawn(2, 1);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(nairan, 2, 1);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(flyer, 4, 2);
        AsteroidSpawner(2);
        EnergyBallSpawn(2, 1);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(7f);

        SpawnEnemies(energyBall, 2, 1);
        yield return new WaitForSeconds(3f);
        SpawnEnemies(scarab, 2, 1);
        yield return new WaitForSeconds(3f);
        SpawnEnemies(flyer, 2, 2);
        yield return new WaitForSeconds(3f);
        SpawnEnemies(battleCruiser, 1, 3);
        yield return new WaitForSeconds(6f);
        SpawnEnemies(nairan, 2, 1);
        yield return new WaitForSeconds(6f);
        SpawnEnemies(dreadnought, 2, 1); // or SpawnEnemies(dreadnought, 2, 3);
        yield return new WaitForSeconds(15f);

        AsteroidSpawner(3);
        SpawnEnemies(Bosses, 1, 1);
    }

    void SpawnEnemies(GameObject enemyPrefab, int numberOfEnemies, int type)
    {
        if (type == 1)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int dicey = Random.Range(8, 16);
                int dicex = Random.Range(-10, 10);

                float valx = (float)dicex;
                float valy = (float)dicey;

                Vector3 spawnPosition = new Vector3(valx, valy, 1f);

                //spawnPosition = new Vector3(dice2, dice, 0);
                //spawnPosition = Random.insideUnitCircle.normalized * 5;
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
        }
        if (type == 2)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int dicey = Random.Range(0, 8);
                int dicex = Random.Range(18, 20);

                float valx = (float)dicex;
                float valy = (float)dicey;

                Vector3 spawnPosition = new Vector3(valx, valy, 1f);

                //spawnPosition = new Vector3(dice2, dice, 0);
                //spawnPosition = Random.insideUnitCircle.normalized * 5;
                Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
            }
        }

        if (type == 3)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int dicey = Random.Range(0, 8);
                int dicex = Random.Range(-8, 8);

                float valx = (float)dicex;
                float valy = (float)dicey;

                Vector3 spawnPosition = new Vector3(valx, valy, 1f);

                //spawnPosition = new Vector3(dice2, dice, 0);
                //spawnPosition = Random.insideUnitCircle.normalized * 5;
                Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0, 0, 90));
            }
        }
    }
    
    void EnergyBallSpawn(int numberOfEnemies, int type)
    {
        if (type == 1)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int dicey = Random.Range(8, 16);
                int dicex = Random.Range(-10, 10);

                float valx = (float)dicex;
                float valy = (float)dicey;

                Vector3 spawnPosition = new Vector3(valx, valy, 1f);

             
                energyBallPool.GetObject(true, spawnPosition, Vector3.zero);
            }
        }
        if (type == 2)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int dicey = Random.Range(0, 8);
                int dicex = Random.Range(18, 20);

                float valx = (float)dicex;
                float valy = (float)dicey;

                Vector3 spawnPosition = new Vector3(valx, valy, 1f);

     
                energyBallPool.GetObject(true, spawnPosition, new Vector3(0, 0, 90));
            }
        }

        if (type == 3)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int dicey = Random.Range(0, 8);
                int dicex = Random.Range(-8, 8);

                float valx = (float)dicex;
                float valy = (float)dicey;

                Vector3 spawnPosition = new Vector3(valx, valy, 1f);

                //spawnPosition = new Vector3(dice2, dice, 0);
                //spawnPosition = Random.insideUnitCircle.normalized * 5;
                energyBallPool.GetObject(true, spawnPosition, new Vector3(0, 0, 90));
            }
        }
    }

    private void AsteroidSpawner(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int dicey = Random.Range(8, 16);
            int dicex = Random.Range(-10, 10);

            float valx = (float)dicex;
            float valy = (float)dicey;

            Vector3 spawnPosition = new Vector3(valx, valy, 1f);

            Instantiate(asteroids, spawnPosition, Quaternion.identity);
           
        }
    }
}
