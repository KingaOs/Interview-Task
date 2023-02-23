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
    private Animator _animator;
    private bool _isDead;
    private Collider _collider;

    private ObjectPooling _objectPooling;
    private UIManager _uiManager;

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

    private bool _isSelected;
    public bool IsSelected
    {
        get
        {
            return _isSelected;
        }
        set
        {
            _isSelected = value;
        }
    }

    void Start()
    {
        _uiManager = GameObject.Find("DisplayInfo").GetComponent<UIManager>();
        _objectPooling = GameObject.Find("SpawnManager").GetComponent<ObjectPooling>();
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManger>();
        _spawnArea = GameObject.Find("Floor").transform;
        _animator.SetFloat("Speed", _speed);
        GetRandomDestinationPoint();
    }

    void Update()
    {
        float step = _speed * Time.deltaTime;

        if (!_isDead)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);

            transform.LookAt(_targetPosition);
        }

        if (Vector3.Distance(transform.position, _targetPosition) < 0.001f)
        {
            GetRandomDestinationPoint();
        }
    }

    void GetRandomDestinationPoint()
    {
        var randomPos = _spawnArea.transform.position + new Vector3(
              Random.Range(-_spawnArea.transform.localScale.x / 2, _spawnArea.transform.localScale.x / 2), 0,
              Random.Range(-_spawnArea.transform.localScale.z / 2, _spawnArea.transform.localScale.z / 2));
        _targetPosition = randomPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Agent"))
        {
            Health--;

            if (IsSelected == true)
            {
                _uiManager.UpdateAgentInfo(this);

                if (Health < 1)
                {
                    _uiManager.HideAgentInfo();
                    Death();
                }
            }
            else if (Health < 1)
            {
                Death();
            }
        }
    }

    void Death()
    {
        _collider.enabled = false;
        _isDead = true;
        _animator.SetTrigger("Death");
        _spawnManager.NumberOfAgent--;

    }

    public void DeactiveAgentAfterAnim()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _isDead = false;
        _collider.enabled = true;
        _objectPooling._agents.Enqueue(gameObject);
    }
}
