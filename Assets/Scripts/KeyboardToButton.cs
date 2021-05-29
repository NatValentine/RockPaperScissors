using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardToButton : MonoBehaviour
{
    // I want pressing a key to be the same as clicking the button that has this script attached.
    public string key;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            gameObject.GetComponent<Button>().onClick.Invoke();
        }
    }
}
