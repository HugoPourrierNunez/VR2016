using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollisionActivateButton : MonoBehaviour {

    [SerializeField]
    Button button;

	void OnCollisionEnter()
    {
        button.onClick.Invoke();
    }
}
