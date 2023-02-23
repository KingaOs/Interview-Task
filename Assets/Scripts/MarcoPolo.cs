using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MarcoPolo : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _markopoloText;
    [SerializeField]
    GameObject _markoPoloDisplay;
    bool _isActive;
    [SerializeField]
    Text _buttonText;




    public void ShowNumbers()
    {
        if (!_isActive)
        {
            _isActive = true;
            _buttonText.text = "Hide MarkoPolo";
            _markoPoloDisplay.SetActive(true);
            _markopoloText.text = null;

            for (int i = 1; i <= 100; i++)
            {

                if (i % 3 == 0 && i % 5 == 0)
                {

                    _markopoloText.text += "MarkoPolo \n";
                }
                else if (i % 3 == 0)
                {
                    _markopoloText.text += "Marko \n";
                }
                else if (i % 5 == 0)
                {
                    _markopoloText.text += "Polo \n";
                }
                else
                {
                    _markopoloText.text += i + "\n";
                }


            }
        }
        else
        {
            _isActive = false;
            _buttonText.text = "Show MarkoPolo";
            _markoPoloDisplay.SetActive(false);
        }

    }

}
