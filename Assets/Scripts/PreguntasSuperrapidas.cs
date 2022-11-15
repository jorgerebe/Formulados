using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PreguntasSuperrapidas : Preguntas {

    [SerializeField] InterstitialAdsButton interstitialAdsButton;
    [SerializeField] RewardedAdsButton rewardedAdsButton;

    public float Tiempo;
    bool y = false;

    public string Tema;
    public int x;
    public Button[] RespuestaAs;

    public int[] Respuestas;

    public Text textoniveles;

    public Text Pregunta;
    public Text Puntuacion;
    public Text NºPregunta;
    public Text respuestaA;
    public Text respuestaB;
    public Text respuestaC;
    public Text respuestaD;

    public int idNivell;
    public int idPregunta;
    public int Aciertos;

    public Button[] BotonesRespuestas;
    public Nivel1PYR[] Temas;


    // Use this for initialization
    void Start()
    {
        interstitialAdsButton.addScriptPreguntas(this);
        rewardedAdsButton.addScriptPreguntas(this);

        interstitialAdsButton.Inicializar();
        rewardedAdsButton.Inicializar();

        RespuestaAs[0].onClick.AddListener(interstitialAdsButton.ShowAd);
        RespuestaAs[1].onClick.AddListener(rewardedAdsButton.ShowAd);

        PlayerPrefs.SetString("eeee", "Qualy");

        Tiempo = 60;
        y = true;

        activarBotones();
        PlayerPrefs.SetInt("a", 1);
        Aciertos = 0;
        EmpezarQuiz();
    }

    // Update is called once per frame
    void Update()
    {
        if(y == true)
        {
            Tiempo -= Time.deltaTime;
        }   
        if (Tiempo <= 0)
        {
            y = false;
            AcabarQuiz();
        }
        Puntuacion.text = "Puntos: " + Aciertos;
        if(Tiempo <= 60)
        {
            NºPregunta.text =  "Tiempo: " + Tiempo.ToString("f1");
        }
        else
        {
            NºPregunta.text = "Tiempo: " + Tiempo.ToString("f0");
        }
        
    }

    void AcabarQuiz()
    {
        if(Social.localUser.authenticated == true)
        {
            Social.ReportScore(Aciertos, "CgkIvc_dmdYEEAIQBw", (bool success) => { });
        }
        else if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(success => { });
            Social.ReportScore(Aciertos, "CgkIvc_dmdYEEAIQBw", (bool success) => { });
        }
        if (Aciertos > PlayerPrefs.GetInt("AciertosSuperrápidos"))
        {
            PlayerPrefs.SetInt("PodioSuper", 0);
        }
        else if (Aciertos == PlayerPrefs.GetInt("AciertosSuperrápidos"))
        {
            PlayerPrefs.SetInt("PodioSuper", 1);
        }
        else if (Aciertos < PlayerPrefs.GetInt("AciertosSuperrápidos"))
        {
            PlayerPrefs.SetInt("PodioSuper", 2);
        }
        PlayerPrefs.SetInt("AciertosSuperrápidos", Aciertos);
        SceneManager.LoadScene("Podio");
    }

    void EmpezarQuiz()
    {
        x = Random.Range(0, 5);
        idPregunta = Random.Range(0, 150);
        if(idPregunta <= 14)
        {
            idNivell = 0;
        }
        else if (idPregunta <= 29)
        {
            idNivell = 1;
        }
        else if (idPregunta <= 44)
        {
            idNivell = 2;
        }
        else if (idPregunta <= 59)
        {
            idNivell = 3;
        }
        else if (idPregunta <= 74)
        {
            idNivell = 4;
        }
        else if (idPregunta <= 89)
        {
            idNivell = 5;
        }
        else if (idPregunta <= 104)
        {
            idNivell = 6;
        }
        else if (idPregunta <= 119)
        {
            idNivell = 7;
        }
        else if (idPregunta <= 134)
        {
            idNivell = 8;
        }
        else if (idPregunta <= 149)
        {
            idNivell = 9;
        }

        textoniveles.text = Temas[x].nombregeneral + " / " + Temas[x].nombreniveles[idNivell];
        Pregunta.text = Temas[x].Preguntas[idPregunta];

            AsignarRespuestaA();

        /*int g = 0;
        while (g <= 149)
        {
            if(Temas[1].respuestasA[g] == Temas[1].respuestasB[g])
            {
                Debug.Log(Temas[1].respuestasA[g]);
                Debug.Log(Temas[1].Preguntas[g]);
            }
            if (Temas[1].respuestasA[g] == Temas[1].respuestasC[g])
            {
                Debug.Log(Temas[1].respuestasA[g]);
                Debug.Log(Temas[1].Preguntas[g]);
            }
            if (Temas[1].respuestasA[g] == Temas[1].respuestasD[g])
            {
                Debug.Log(Temas[1].respuestasA[g]);
                Debug.Log(Temas[1].Preguntas[g]);
            }
            if (Temas[1].respuestasB[g] == Temas[1].respuestasC[g])
            {
                Debug.Log(Temas[1].respuestasB[g]);
                Debug.Log(Temas[1].Preguntas[g]);
            }
            if (Temas[1].respuestasB[g] == Temas[1].respuestasD[g])
            {
                Debug.Log(Temas[0].respuestasB[g]);
                Debug.Log(Temas[1].Preguntas[g]);
            }
            if (Temas[1].respuestasC[g] == Temas[1].respuestasD[g])
            {
                Debug.Log(Temas[1].respuestasC[g]);
                Debug.Log(Temas[1].Preguntas[g]);
            }
            g++;
        }*/
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
                Aciertos += 3;
                Tiempo += 0.5f;
                BotonesRespuestas[0].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[0].image.color = Color.red;
                Aciertos -= 1;
                Tiempo -= 1;
            }
        }

        else if (respuesta == "B")
        {
            if (respuestaB.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                Aciertos += 3;
                Tiempo += 0.5f;
                BotonesRespuestas[1].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[1].image.color = Color.red;
                Aciertos -= 1;
                Tiempo -= 1;
            }
        }

        else if (respuesta == "C")
        {
            if (respuestaC.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                Aciertos += 3;
                Tiempo += 0.5f;
                BotonesRespuestas[2].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[2].image.color = Color.red;
                Aciertos -= 1;
                Tiempo -= 1;
            }
        }

        else if (respuesta == "D")
        {
            if (respuestaD.text == Temas[x].RespuestasCorrectas[idPregunta])
            {
                Aciertos += 3;
                Tiempo += 0.5f;
                BotonesRespuestas[3].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[3].image.color = Color.red;
                Aciertos -= 1;
                Tiempo -= 1;
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