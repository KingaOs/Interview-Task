using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;
    private Agent _agent;
    private UIManager _uiManager;
    private GameObject _previousAgent;
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
                    _agent.IsSelected = true;

                    _uiManager.ShowAgentInfo(_agent);

                    if (_previousAgent != null)
                    {
                        _previousAgent.GetComponent<Outline>().enabled = false;

                        _previousAgent.GetComponent<Agent>().IsSelected = false;
                    }

                    _agent.gameObject.GetComponent<Outline>().enabled = true;

                    _previousAgent = _agent.gameObject;
                }
                else
                {
                    if (_previousAgent != null)
                        _previousAgent.GetComponent<Outline>().enabled = false;

                    _uiManager.HideAgentInfo();
                }
            }

        }
    }
}
