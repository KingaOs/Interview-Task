using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;
    private Agent _agent;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _agent = hit.collider.gameObject.GetComponent<Agent>();

                if(_agent != null)
                {
                    Debug.Log(_agent.gameObject.name);
                }
            }
        }
    }
}
