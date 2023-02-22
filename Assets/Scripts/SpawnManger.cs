using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField]
    [Range(3, 5)]
    int _numOfAgentsAtStart;
    [SerializeField]
    [Range(2, 6)]
    int _timeBetweenSpawning;
    [SerializeField]
    [Range(1, 30)]
    int _maxNumOfAgentAtOnce;

    [SerializeField]
    GameObject _agentPrefab;
    [SerializeField]
    GameObject[] _spawnPoints;
    int _numbOfAgent;

    // Start is called before the first frame update
    void Start()
    {
        InnitSpawn();
    }

    void InnitSpawn()
    {
        for (int i = 0; i < _numOfAgentsAtStart; i++)
        {
            var randomSprawnPoint = Random.Range(0, _spawnPoints.Length);
            Debug.Log(randomSprawnPoint);
            Instantiate(_agentPrefab, _spawnPoints[randomSprawnPoint].transform.position, Quaternion.identity);
        }

        _numbOfAgent = _numOfAgentsAtStart;

       StartCoroutine(StartSpawning());
    }



    IEnumerator StartSpawning()
    {

        while (true)
        {
            yield return new WaitUntil(() => _numbOfAgent < _maxNumOfAgentAtOnce);

            var randomSprawnPoint = Random.Range(0, _spawnPoints.Length);
            Instantiate(_agentPrefab, _spawnPoints[randomSprawnPoint].transform.position, Quaternion.identity);
            _numbOfAgent++;

            yield return new WaitForSeconds(_timeBetweenSpawning);

        }
    }
}
