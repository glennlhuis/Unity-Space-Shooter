using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private GameObject _tripleshotPrefab;
    
    

    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //spawn enemies every 5 secs  

    IEnumerator SpawnEnemyRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 postoSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
            float timetoSpawn = Random.Range(1.0f, 3.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, postoSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(timetoSpawn);

        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while(_stopSpawning == false)
        {
            Vector3 postoSpawn = new Vector3(Random.Range(-9f, 9f), 7, 0);
            Instantiate(_tripleshotPrefab, postoSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8));
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }

}
