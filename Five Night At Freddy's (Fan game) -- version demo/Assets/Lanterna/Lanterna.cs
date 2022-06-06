using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Light), typeof(AudioSource))]
public class Lanterna : MonoBehaviour
{
    public AudioClip Som;
    public float tempodeduracao = 300f;
    private float porcentagem = 100;
    private bool on;
    private float tempo;

    void Update()
    {
        Light lite = GetComponent<Light>();
        tempo += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && tempo >= 0.3f && porcentagem > 0)
        {
            on = !on;
            GetComponent<AudioSource>().PlayOneShot(Som);
            tempo = 0;
        }

        if (on)
        {
            lite.enabled = true;
            porcentagem -= Time.deltaTime * (100 / tempodeduracao);
        }

        else
        {
            lite.enabled = false;
        }

        porcentagem = Mathf.Clamp(porcentagem, 0, 100);

        if (porcentagem == 0)
        {
            lite.intensity = Mathf.Lerp(lite.intensity, 0, Time.deltaTime * 2);
        }

        if (porcentagem > 0 && porcentagem < 25)
        {
            lite.intensity = Mathf.Lerp(lite.intensity, 0.3f, Time.deltaTime);
        }

        if (porcentagem > 25 && porcentagem < 75)
        {
            lite.intensity = Mathf.Lerp(lite.intensity, 0.7f, Time.deltaTime);
        }

        if (porcentagem > 75 && porcentagem <= 100)
        {
            lite.intensity = Mathf.Lerp(lite.intensity, 1, Time.deltaTime);
        }
    }
}