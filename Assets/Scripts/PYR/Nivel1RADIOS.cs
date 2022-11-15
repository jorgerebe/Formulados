using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text;

public class Nivel1RADIOS : MonoBehaviour {

    public int pruebA = 0;
    public Text[] RadiosEspañol;
    public Text[] RadiosInglés;
    public Text ejemplo;
    public Text Puntuacion;
    public Text NºPregunta;
    public Text nombreniveles;

    

    public GameObject[] LedsRojos;
    public GameObject[] LedsAmarillos;
    public GameObject[] LedsVerdeMoco;
    public GameObject[] LedsNormales;

    public int idPregunta;
    public float Aciertos;
    public int idNivell;
    public int intentos;

    public InputField RespuestaPiloto;
    public InputField RespuestaCarrera;
    public InputField RespuestaAño;

    public string[] Radios;
    public string[] PilotosCorrectos;
    public string[] CarrerasCorrectas;
    public string [] AñosCorrectos;
    public string[] niveles;
    public string Tema;

    int a;
    int b;

    public Button[] BotonesEliminarRespuestas;


    // Use this for initialization
    void Start () {
        Aciertos = 0;
        intentos = 0;
        idNivell = PlayerPrefs.GetInt("idnivel");


        nombreniveles.text = Tema + " / " + niveles[idNivell];

        if (idNivell == 0)
        {
            idPregunta = 0;
            EmpezarQuiz();
        }
        else
        {
            idPregunta = idNivell * 5;
            EmpezarQuiz();
        }
	}

    void Update()
    {
        Puntuacion.text = "Aciertos: " + Aciertos;
        NºPregunta.text = intentos + 1 + " / 5";
    }

    void EmpezarQuiz()
    {
        if (intentos <= 4)
        {
            Debug.Log("Podemos seguir con el quiz");
            if (PlayerPrefs.GetInt("Radioss") == 1)
            {
                RadiosEspañol[idPregunta].enabled = true;
                RadiosInglés[idPregunta].enabled = false;
            }
            else if (PlayerPrefs.GetInt("Radioss") == 0)
            {
                RadiosEspañol[idPregunta].enabled = false;
                RadiosInglés[idPregunta].enabled = true;
            }
            RespuestaAño.text = "";
            RespuestaCarrera.text = "";
            RespuestaPiloto.text = "";
            BotonesEliminarRespuestas[0].interactable = true;
            BotonesEliminarRespuestas[1].interactable = true;
        }
        else
        {
            PlayerPrefs.SetFloat("AciertosRadios", Aciertos);
            Debug.Log("Acabaste");
            SceneManager.LoadScene("Podio");
        }
    }

    public void BotónComprobarRespuesta()
    {
        ComprobarRespuesta();
    }

    void ComprobarRespuesta()
    {
        RadiosEspañol[idPregunta].enabled = false;
        RadiosInglés[idPregunta].enabled = false;
        if (RespuestaPiloto.text == PilotosCorrectos[idPregunta])
        {
            pruebA++;
        }
        if (RespuestaCarrera.text == CarrerasCorrectas[idPregunta])
        {
            pruebA++;
        }
        if (RespuestaAño.text == AñosCorrectos[idPregunta])
        {
            pruebA++;
        }

        switch (pruebA)
        {
            case 1:
                Aciertos = Aciertos + 0.3f;
                LedsAmarillos[intentos].SetActive(true);
                LedsNormales[intentos].SetActive(false);
                LedsVerdeMoco[intentos].SetActive(false);
                LedsRojos[intentos].SetActive(false);
                break;

            case 2:
                Aciertos = Aciertos + 0.6f;
                LedsAmarillos[intentos].SetActive(true);
                LedsNormales[intentos].SetActive(false);
                LedsVerdeMoco[intentos].SetActive(false);
                LedsRojos[intentos].SetActive(false);
                break;

            case 3:
                Aciertos++;
                LedsAmarillos[intentos].SetActive(false);
                LedsNormales[intentos].SetActive(false);
                LedsVerdeMoco[intentos].SetActive(true);
                LedsRojos[intentos].SetActive(false);
                break;

            default:
                LedsNormales[intentos].SetActive(false);
                LedsVerdeMoco[intentos].SetActive(false);
                LedsAmarillos[intentos].SetActive(false);
                LedsRojos[intentos].SetActive(true);
                break;
        }
        ProximaPregunta();

    }

    void ProximaPregunta()
    {

        intentos++;
        idPregunta++;
        pruebA = 0;
        EmpezarQuiz();
    }

    public void Rellenar1Respuesta()
    {
        BotonesEliminarRespuestas[0].interactable = false;
        BotonesEliminarRespuestas[1].interactable = false;
        //Advertisement.Show();
        int a;
        a = Random.Range(0, 3);
        if(a == 0)
        {
            RespuestaPiloto.text = PilotosCorrectos[idPregunta];
        }
        else if (a == 1)
        {
            RespuestaAño.text = AñosCorrectos[idPregunta];
        }
        else if (a == 2)
        {
            RespuestaCarrera.text = CarrerasCorrectas[idPregunta];
        }
    }

    public void Rellenar2Respuestas()
    {
        BotonesEliminarRespuestas[0].interactable = false;
        BotonesEliminarRespuestas[1].interactable = false;

        a = Random.Range(0, 3);
        b = Random.Range(0, 3);
        if (a == b)
        {
            Rellenar2Respuestas();
        }
        else if (a != b)
        {

               /*if (Advertisement.IsReady("rewardedVideo"))
                {
                    var options = new ShowOptions { resultCallback = HandleShowResult };
                    Advertisement.Show("rewardedVideo", options);
                }*/

            
        }
    }
    /*
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                if (a == 0)
                {
                    RespuestaPiloto.text = PilotosCorrectos[idPregunta];
                }
                else if (a == 1)
                {
                    RespuestaAño.text = AñosCorrectos[idPregunta];
                }
                else if (a == 2)
                {
                    RespuestaCarrera.text = CarrerasCorrectas[idPregunta];
                }

                if (b == 0)
                {
                    RespuestaPiloto.text = PilotosCorrectos[idPregunta];
                }
                else if (b == 1)
                {
                    RespuestaAño.text = AñosCorrectos[idPregunta];
                }
                else if (b == 2)
                {
                    RespuestaCarrera.text = CarrerasCorrectas[idPregunta];
                }
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    */
    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void SalirAlMenú()
    {
        SceneManager.LoadScene("MENÚPRINCIPAL");
    }

    public void CambiarIdioma()
    {
        if (PlayerPrefs.GetInt("Radioss") == 0)
        {
            PlayerPrefs.SetInt("Radioss", 1);
            RadiosInglés[idPregunta].enabled = false;
            RadiosEspañol[idPregunta].enabled = true;
        }
        else if (PlayerPrefs.GetInt("Radioss") == 1)
        {
            PlayerPrefs.SetInt("Radioss", 0);
            RadiosInglés[idPregunta].enabled = true;
            RadiosEspañol[idPregunta].enabled = false;
        }
    }
}
