using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    Text _nameText;
    [SerializeField]
    Text _healthText;


    public void ShowAgentInfo(Agent agent)
    {
        _nameText.gameObject.SetActive(true);
        _healthText.gameObject.SetActive(true);
        _nameText.text = "Name: " + agent.Name;
        _healthText.text = "Health: " + agent.Health;
    }

    public void HideAgentInfo()
    {
        _nameText.gameObject.SetActive(false);
        _healthText.gameObject.SetActive(false);
    }

    public void UpdateAgentInfo(Agent agent)
    {
        _nameText.text = "Name: " + agent.Name;
        _healthText.text = "Health: " + agent.Health;
    }
}
