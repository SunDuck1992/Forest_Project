using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefab;
    [SerializeField] private Transform[] _pointOfSpawn;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private int _countWawe;
   
    private void Start()
    {
        SpawnEnemy();
    }

    private IEnumerator Spawn()
    {
        var waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        for (int i = 0; i < _countWawe; i++)
        {
            foreach (var point in _pointOfSpawn)
            {
                Instantiate(_enemyPrefab[RandomNumber()], point.transform.position, Quaternion.identity);
                yield return waitForSeconds;
            }
        }
    }

    private void SpawnEnemy()
    {
        StartCoroutine(Spawn());
    }

    private int RandomNumber()
    {
        int randomNumber = Random.Range(0, _enemyPrefab.Count);
        return randomNumber;
    }
}
