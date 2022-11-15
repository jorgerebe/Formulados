using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animaciónVolante : MonoBehaviour {

    public Animator animator;
    public float tiempo;
    public AudioSource Leva;
    public Button pantalla;

    public bool BotónVolante;
    public bool BotónAtrásAnimaciónVolante;
    public GameObject VolanteBotón;
    public GameObject Textos;
    public GameObject Guantes;

    int a;

    public GameObject xx;

    public GameObject[] BotonAtrás;
    public GameObject[] prueba;

    public GameObject[] Textoss;

    public GameObject VolanteObject;
    public GameObject[] Botoncillos;

    public Toggle MostrarRespuestaCorrecta;

    // Use this for initialization
    void Start () {
        prueba[0].SetActive(false);
        prueba[1].SetActive(false);
        prueba[2].SetActive(false);
        prueba[3].SetActive(false);
        BotonAtrás[0].SetActive(false);
        Textoss[0].SetActive(false);
        Textoss[1].SetActive(false);
        Textoss[2].SetActive(false);


        if (PlayerPrefs.GetInt("a") == 1)
        {
            if (PlayerPrefs.GetInt("MostrarRespuesta") == 1)
            {
                MostrarRespuestaCorrecta.isOn = true; ;
            }

            if (PlayerPrefs.GetInt("MostrarRespuesta") == 0)
            {
                MostrarRespuestaCorrecta.isOn = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {

        animator.SetBool("BotónVolante", BotónVolante);
        animator.SetBool("BotónnAtrásAnimaciónVolante", BotónAtrásAnimaciónVolante);

        if (MostrarRespuestaCorrecta.isOn == true)
        {
            PlayerPrefs.SetInt("MostrarRespuesta", 1);
        }
        else if (MostrarRespuestaCorrecta.isOn == false)
        {
            PlayerPrefs.SetInt("MostrarRespuesta", 0);
        }
    }


    public void AnimaciónClipVolante()
    {
        Botoncillos[0].SetActive(false);
        Botoncillos[1].SetActive(false);
        pantalla.enabled = false;
        xx.SetActive(false);
        Guantes.SetActive(false);
        BotónVolante = true;
        VolanteBotón.SetActive(false);
        Textos.SetActive(false);
        StartCoroutine(VAMOS());
    }


    IEnumerator VAMOS()
    {
        yield return new WaitForSeconds(tiempo);
        BotónVolante = false;
        BotonAtrás[0].SetActive(true);
        prueba[0].SetActive(true);
        prueba[1].SetActive(true);
        prueba[2].SetActive(true);
        prueba[3].SetActive(true);
    }

    public void Privacidad()
    {
        Application.OpenURL("https://docs.google.com/document/d/1z39-DndQVspdbQuEkwGe6NfkCKUn0yQKWa3ji3dOMcc/edit?usp=sharing");
    }

    public void BotónAtrásAnimación()
    {
        Leva.Play();
        VolanteBotón.SetActive(false);
        BotonAtrás[0].SetActive(false);
        prueba[0].SetActive(false);
        prueba[1].SetActive(false);
        prueba[3].SetActive(false);
        pantalla.enabled = true;
        prueba[0].SetActive(false);
        prueba[1].SetActive(false);
        prueba[2].SetActive(false);
        BotónAtrásAnimaciónVolante = true;
        BotonAtrás[0].SetActive(false);
        StartCoroutine(ATRAS());
    }

    IEnumerator ATRAS()
    {
        yield return new WaitForSeconds(0.9f);
        Textos.SetActive(true);
        BotónAtrásAnimaciónVolante = false;
        Guantes.SetActive(true);
        xx.SetActive(true);
        Botoncillos[0].SetActive(true);
        Botoncillos[1].SetActive(true);
        StartCoroutine(Hey());
    }

    IEnumerator Hey()
    {
        yield return new WaitForSeconds(0.15f);
        VolanteBotón.SetActive(true);
    }

    public void ActivarTextos(int x)
    {
        Leva.Play();
        a = x;
        prueba[0].SetActive(false);
        prueba[1].SetActive(false);
        prueba[2].SetActive(false);
        prueba[3].SetActive(false);
        Textoss[x].SetActive(true);
        BotonAtrás[0].SetActive(false);
        BotonAtrás[1].SetActive(true);
    }

    public void AtrásTextos()
    {
        Leva.Play();
        prueba[0].SetActive(true);
        prueba[1].SetActive(true);
        prueba[2].SetActive(true);
        prueba[3].SetActive(true);
        Textoss[a].SetActive(false);
        BotonAtrás[1].SetActive(false);
        BotonAtrás[0].SetActive(true);
    }
}
