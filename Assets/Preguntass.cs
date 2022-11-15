using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preguntass : Preguntas
{
    [SerializeField] InterstitialAdsButton interstitialAdsButton;
    [SerializeField] RewardedAdsButton rewardedAdsButton;

    public string Tema;
    int x;
    public Button[] RespuestaAs;

    public int[] Respuestas;

    int idnivellll;
    public Text textoniveles;

    public Text Pregunta;
    public Text Puntuacion;
    public Text NºPregunta;
    public Text respuestaA;
    public Text respuestaB;
    public Text respuestaC;
    public Text respuestaD;

    public GameObject[] LedNormales;
    public GameObject[] LedRojos;
    public GameObject[] LedVerdesMoco;

    public int idNivell;
    public int idPregunta;
    public int Intentos;
    public int Aciertos;

    public Button[] BotonesRespuestas;
    public Nivel1PYR[] Temas;


    // Use this for initialization
    void Start () {

        interstitialAdsButton.addScriptPreguntas(this);
        rewardedAdsButton.addScriptPreguntas(this);

        interstitialAdsButton.Inicializar();
        rewardedAdsButton.Inicializar();

        RespuestaAs[0].onClick.AddListener(interstitialAdsButton.ShowAd);
        RespuestaAs[1].onClick.AddListener(rewardedAdsButton.ShowAd);

        activarBotones();

        PlayerPrefs.SetInt("AciertosMotor", 0);
        PlayerPrefs.SetInt("a", 1);

        idnivellll = PlayerPrefs.GetInt("idnivel");
        idNivell = PlayerPrefs.GetInt("idnivel");
        Tema = PlayerPrefs.GetString("Tema");
        switch (Tema)
        {
            case ("F1ENGENERAL (UnityEngine.GameObject)"):
                x = 0;
                break;
            case ("F1ESPAÑOLA (UnityEngine.GameObject)"):
                x = 1;
                idNivell = idNivell - 10;
                break;
            case ("PILOTOSLEGENDARIOS (UnityEngine.GameObject)"):
                x = 2;
                idNivell = idNivell - 20;
                break;
            case ("EQUIPOSLEGENDARIOS (UnityEngine.GameObject)"):
                x = 3;
                idNivell = idNivell - 30;
                break;
            case ("CIRCUITOSLEGENDARIOS (UnityEngine.GameObject)"):
                x = 4;
                idNivell = idNivell - 40;
                break;
            default:
                x = 5;
                idNivell = idNivell - 50;
                break;
        }
        Aciertos = 0;
        Intentos = 0;
        textoniveles.text = Temas[x].nombregeneral + " / " + Temas[x].nombreniveles[idNivell];
        if (idNivell == 0)
        {
            idPregunta = 0;
            EmpezarQuiz();
        }
        else
        {
            idPregunta = idNivell * 15;
            EmpezarQuiz();
        }


    }

    // Update is called once per frame
    void Update()
    {
        Puntuacion.text = "Aciertos: " + Aciertos;
        NºPregunta.text = Intentos + 1 + " / 15";
    }

    void EmpezarQuiz()
    {
        activarBotones();

        if (Intentos <= 14)
        {
            PlayerPrefs.SetInt("AciertosMotor", Aciertos);
            AsignarRespuestaA();
            Pregunta.text = Temas[x].Preguntas[idPregunta];
        }
        if (Intentos >= 15)
        {
            PlayerPrefs.SetInt("Aciertos" + idnivellll.ToString(), Aciertos);
            PlayerPrefs.SetInt("IdNivel", idNivell);
            SceneManager.LoadScene("Podio");
        }
    }

    void AsignarRespuestaA()
    {
        Respuestas[0] = Random.Range(0, 4);
        if (Respuestas[0] == 0)
        {
            respuestaA.text = Temas[x].respuestasA[idPregunta];
        }
        else if (Respuestas[0] == 1)
        {
            respuestaA.text = Temas[x].respuestasB[idPregunta];
        }
        else if (Respuestas[0] == 2)
        {
            respuestaA.text = Temas[x].respuestasC[idPregunta];
        }
        else if (Respuestas[0] == 3)
        {
            respuestaA.text = Temas[x].respuestasD[idPregunta];
        }

        AsignarRespuestaB();
    }

    void AsignarRespuestaB()
    {
        Respuestas[1] = Random.Range(0, 4);
        if (Respuestas[0] == Respuestas[1])
        {
            AsignarRespuestaB();
        }
        if (Respuestas[1] == 0)
        {
            respuestaB.text = Temas[x].respuestasA[idPregunta];
        }
        else if (Respuestas[1] == 1)
        {
            respuestaB.text = Temas[x].respuestasB[idPregunta];
        }
        else if (Respuestas[1] == 2)
        {
            respuestaB.text = Temas[x].respuestasC[idPregunta];
        }
        else if (Respuestas[1] == 3)
        {
            respuestaB.text = Temas[x].respuestasD[idPregunta];
        }

        AsignarRespuestaC();
    }

    void AsignarRespuestaC()
    {
        Respuestas[2] = Random.Range(0, 4);
        if (Respuestas[0] == Respuestas[2])
        {
            AsignarRespuestaC();
        }
        else if (Respuestas[1] == Respuestas[2])
        {
            AsignarRespuestaC();
        }
        if (Respuestas[2] == 0)
        {
            respuestaC.text = Temas[x].respuestasA[idPregunta];
        }
        else if (Respuestas[2] == 1)
        {
            respuestaC.text = Temas[x].respuestasB[idPregunta];
        }
        else if (Respuestas[2] == 2)
        {
            respuestaC.text = Temas[x].respuestasC[idPregunta];
        }
        else if (Respuestas[2] == 3)
        {
            respuestaC.text = Temas[x].respuestasD[idPregunta];
        }
        AsignarRespuestaD();
    }

    void AsignarRespuestaD()
    {
        Respuestas[3] = Random.Range(0, 4);
        if (Respuestas[0] == Respuestas[3])
        {
            AsignarRespuestaD();
        }
        else if (Respuestas[1] == Respuestas[3])
        {
            AsignarRespuestaD();
        }
        else if (Respuestas[2] == Respuestas[3])
        {
            AsignarRespuestaD();
        }
        if (Respuestas[3] == 0)
        {
            respuestaD.text = Temas[x].respuestasA[idPregunta];
        }
        else if (Respuestas[3] == 1)
        {
            respuestaD.text = Temas[x].respuestasB[idPregunta];
        }
        else if (Respuestas[3] == 2)
        {
            respuestaD.text = Temas[x].respuestasC[idPregunta];
        }
        else if (Respuestas[3] == 3)
        {
            respuestaD.text = Temas[x].respuestasD[idPregunta];
        }
    }

    public void BotónComprobarRespuesta(string respuesta)
    {
        if (respuesta == "A")
        {
            if (respuestaA.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                BotonesRespuestas[0].image.color = Color.green;
            }
            else
            {
                LedRojos[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(false);
                BotonesRespuestas[0].image.color = Color.red;
            }
        }

        else if (respuesta == "B")
        {
            if (respuestaB.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                BotonesRespuestas[1].image.color = Color.green;
            }
            else
            {
                LedRojos[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(false);
                BotonesRespuestas[1].image.color = Color.red;
            }
        }

        else if (respuesta == "C")
        {
            if (respuestaC.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                BotonesRespuestas[2].image.color = Color.green;
            }
            else
            {
                LedRojos[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(false);
                BotonesRespuestas[2].image.color = Color.red;
            }
        }

        else if (respuesta == "D")
        {
            if (respuestaD.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                BotonesRespuestas[3].image.color = Color.green;
            }
            else
            {
                LedRojos[Intentos].SetActive(true);
                LedNormales[Intentos].SetActive(false);
                LedVerdesMoco[Intentos].SetActive(false);
                BotonesRespuestas[3].image.color = Color.red;
            }
        }

        if (PlayerPrefs.GetInt("MostrarRespuesta") == 1)
        {
            if (respuestaA.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                BotonesRespuestas[0].image.color = Color.green;
            }
            else if (respuestaB.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                BotonesRespuestas[1].image.color = Color.green;
            }
            else if (respuestaC.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                BotonesRespuestas[2].image.color = Color.green;
            }
            else if (respuestaD.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                BotonesRespuestas[3].image.color = Color.green;
            }
        }
        PlayerPrefs.SetInt("AciertosMotor", Aciertos);
        BotonesRespuestas[0].interactable = false;
        BotonesRespuestas[1].interactable = false;
        BotonesRespuestas[2].interactable = false;
        BotonesRespuestas[3].interactable = false;

        StartCoroutine(CambiarColorBotones());
        RespuestaAs[0].interactable = true;
        RespuestaAs[1].interactable = true;
    }

    IEnumerator CambiarColorBotones()
    {
        yield return new WaitForSeconds(0.5f);
        BotonesRespuestas[0].image.color = Color.white;
        BotonesRespuestas[1].image.color = Color.white;
        BotonesRespuestas[2].image.color = Color.white;
        BotonesRespuestas[3].image.color = Color.white;
        BotonesRespuestas[0].interactable = true;
        BotonesRespuestas[1].interactable = true;
        BotonesRespuestas[2].interactable = true;
        BotonesRespuestas[3].interactable = true;
        ProximaPregunta();
    }

    public override void Eliminar1RespuestaIncorrecta()
    {
        int prueba = 0;
        while (prueba < 1)
        {
            if (respuestaC.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaC.text = "";
                prueba++;
            }
            else if (respuestaA.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaA.text = "";
                prueba++;
            }
            else if (respuestaD.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaD.text = "";
                prueba++;
            }
            else if (respuestaB.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaB.text = "";
                prueba++;
            }
        }
    }

    public override void Eliminar2RespuestasIncorrectas()
    {
        int prueba = 0;
        while (prueba < 2)
        {
            if (respuestaC.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaC.text = "";
                prueba++;
                if (respuestaA.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaA.text = "";
                    prueba++;
                }
                else if (respuestaB.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaB.text = "";
                    prueba++;
                }
                else if (respuestaD.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaD.text = "";
                    prueba++;
                }
            }

            else if (respuestaA.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaA.text = "";
                prueba++;
                if (respuestaC.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaC.text = "";
                    prueba++;
                }
                else if (respuestaB.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaB.text = "";
                    prueba++;
                }
                else if (respuestaD.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaD.text = "";
                    prueba++;
                }

            }
            else if (respuestaB.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaB.text = "";
                prueba++;
                if (respuestaA.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaA.text = ""; prueba++;
                }
                else if (respuestaD.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaD.text = ""; prueba++;
                }
                else if (respuestaC.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaC.text = ""; prueba++;
                }
            }
            else if (respuestaD.text != Temas[x].RespuestasCorrectas[idPregunta])
            {
                respuestaD.text = "";
                prueba++;
                if (respuestaA.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaA.text = "";
                    prueba++;
                }
                else if (respuestaB.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaB.text = "";
                    prueba++;
                }
                else if (respuestaC.text != Temas[x].RespuestasCorrectas[idPregunta])
                {
                    respuestaC.text = "";
                    prueba++;
                }
            }
        }
    }

    public void ProximaPregunta()
    {
        Intentos++;
        idPregunta++;
        EmpezarQuiz();
    }

    public void SalirDelJuego()
    {
        Application.Quit();
    }

    public void SalirAlMenú()
    {
        SceneManager.LoadScene("MENÚPRINCIPAL");
    }

    public override void desactivarBotones()
    {
        RespuestaAs[0].interactable = false;
        RespuestaAs[1].interactable = false;
    }

    public override void activarBotones()
    {
        RespuestaAs[0].interactable = true;
        RespuestaAs[1].interactable = true;
    }
}
