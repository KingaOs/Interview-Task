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

    [SerializeField]
    private Transform _spawnArea;

    private List<string> _names = new List<string> { "Emmyth Mirabalar", "Hagred Ulawenys", "Katyr Bryneiros", "Naertho Liabanise", "Tarathiel Wysazorwyn",
        "Sakaala Heilamin", "Daratrine Liabanise", "Hagre Shafaren", "Rathal Wyngwyn", "Thalanil Uriran", "Violet Hensley", "Kasey Baker", "Barry May",
        "Cordell Dominguez", "Helga Beasley", "Chris Hopkins", "Shawn Vance", "Basil Spear", "Donnie Cruz", "Sung Bowers", "Arturo Hahn", "Darwin Roberson",
        "Edwin Alvarez", "Romeo Roman", "Tracy Mcclure", "Jim Ramsey", "Renaldo Middleton", "Lucius Riggs", "Eddie Fuentes" };

    private int _numbOfAgent;
    public int NumberOfAgent
    {
        get
        {
            return _numbOfAgent;
        }
        set
        {
            _numbOfAgent = value;
        }
    }

    void Start()
    {
        PlaceSpawnPoints();
        InnitSpawn();
    }

    void PlaceSpawnPoints()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Vector3 randomPos = _spawnArea.transform.position + new Vector3(
            Random.Range(-_spawnArea.transform.localScale.x / 2, _spawnArea.transform.localScale.x / 2), _spawnArea.transform.localScale.y,
            Random.Range(-_spawnArea.transform.localScale.z / 2, _spawnArea.transform.localScale.z / 2));
            _spawnPoints[i].transform.position = randomPos;
        }

    }


    void InnitSpawn()
    {
        for (int i = 0; i < _numOfAgentsAtStart; i++)
        {
            var randomSprawnPoint = Random.Range(0, _spawnPoints.Length);
            var agent = Instantiate(_agentPrefab, _spawnPoints[randomSprawnPoint].transform.position, Quaternion.identity);
            AssignAgentName(agent);
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
            var agent = Instantiate(_agentPrefab, _spawnPoints[randomSprawnPoint].transform.position, Quaternion.identity);
            _numbOfAgent++;
            AssignAgentName(agent);
            yield return new WaitForSeconds(_timeBetweenSpawning);

        }
    }

    void AssignAgentName(GameObject agent)
    {
        var randomNameIndex = Random.Range(0, _names.Count);
        agent.GetComponent<Agent>().Name = _names[randomNameIndex];
    }

}
