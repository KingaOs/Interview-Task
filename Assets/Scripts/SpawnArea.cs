using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField]
    private GameObject _spawnArea;
    [SerializeField]
    [Range(10,50)]
    private int _spawnAreaLength;
    [SerializeField]
    [Range(10, 50)]
    private int _spawnAreaWidth;


    void Start()
    {
        _spawnArea.transform.localScale = new Vector3(_spawnAreaLength, transform.localScale.y, _spawnAreaWidth);
    }
}
