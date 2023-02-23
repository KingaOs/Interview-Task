using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;
    private Agent _agent;
    private UIManager _uiManager;
    void Start()
    {
        _camera = GetComponent<Camera>();
        _uiManager = GameObject.Find("DisplayInfo").GetComponent<UIManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _agent = hit.collider.gameObject.GetComponent<Agent>();

                if (_agent != null)
                {
                    _uiManager.ShowAgentInfo(_agent);
                }
                else
                {
                    _uiManager.HideAgentInfo();
                }
            }

        }
    }
}
