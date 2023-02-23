using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [SerializeField]
    private int _speed = 2;
    [SerializeField]
    private Transform _spawnArea;
    Vector3 _targetPosition;

    void Start()
    {
        _spawnArea = GameObject.Find("Floor").transform;
        GetRandomDestinationPoint();
    }

    void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);

        if(Vector3.Distance(transform.position, _targetPosition) < 0.001f)
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
}
