using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clock : MonoBehaviour
{
    public Text TextSegundos;
    public Text TextMinutos;
    public int LimiteDosSegundos;
    public float Segundos;
    public int Minutos;

    private void FixedUpdate()
    {
        TextSegundos.text = Segundos.ToString("00");
        TextMinutos.text = Minutos.ToString("00");
        Segundos += Time.deltaTime / 02f;
        if (Segundos >= LimiteDosSegundos)
        {
            Minutos++;
            Segundos = 0;
        }
        if (Minutos == 12)
        {
            Minutos = 0;
        }
    }
}
