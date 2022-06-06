using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControledeLuzes : MonoBehaviour {

    public string _playerTag = "Player";

    private void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == _playerTag)
        {
            Light lite = GetComponent<Light>();
            lite.enabled = true;
        }
    }

    private void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.tag == _playerTag)
        {
            Light lite = GetComponent<Light>();
            lite.enabled = false;
        }
    }
}
