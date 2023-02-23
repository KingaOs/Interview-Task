using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject _agent;
    public Queue<GameObject> _agents = new Queue<GameObject>();

    void Start()
    {
        _agent.SetActive(false);
        for (int i = 0; i < 30; i++)
        {
            _agents.Enqueue(Instantiate(_agent, transform.position, Quaternion.identity));
        }
    }


    public GameObject GetPooledGameObject()
    {
        return _agents.Dequeue();
    }



}
