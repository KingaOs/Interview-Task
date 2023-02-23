using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField]
    private int _speed = 2;
    [SerializeField]
    private Transform _spawnArea;
    private Vector3 _targetPosition;
    private SpawnManger _spawnManager;

    private int _health = 3;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManger>();
        _spawnArea = GameObject.Find("Floor").transform;
        GetRandomDestinationPoint();
    }

    void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);

        if (Vector3.Distance(transform.position, _targetPosition) < 0.001f)
        {
            GetRandomDestinationPoint();
        }
    }

    void GetRandomDestinationPoint()
    {
        var randomPos = _spawnArea.transform.position + new Vector3(
              Random.Range(-_spawnArea.transform.localScale.x / 2, _spawnArea.transform.localScale.x / 2), _spawnArea.transform.localScale.y,
              Random.Range(-_spawnArea.transform.localScale.z / 2, _spawnArea.transform.localScale.z / 2));
        _targetPosition = randomPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            _health--;
            if (_health < 1)
                Death();
        }
    }

    void Death()
    {
        _spawnManager.NumberOfAgent--;
        Destroy(this.gameObject);
    }
}
