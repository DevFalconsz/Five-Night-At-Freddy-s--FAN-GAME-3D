using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Principal : MonoBehaviour
{
    public string _playerTag = "Player";
    Animator anim;

    private void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.tag == _playerTag)
        {
            anim = GetComponent<Animator>();
            anim.SetTrigger("Abrir");
        }
    }

    private void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.tag == _playerTag)
        {
            anim = GetComponent<Animator>();
            anim.SetTrigger("Fechar");
        }
    }
}
