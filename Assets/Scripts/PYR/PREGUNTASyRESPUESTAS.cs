using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PREGUNTASyRESPUESTAS : MonoBehaviour
{
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

    public int idPregunta;
    private int Aciertos;
    public int idnivel;

    public string[] Preguntas;
    public string[] RespuestasCorrectas;
    public string[] respuestasA;
    public string[] respuestasB;
    public string[] respuestasC;
    public string[] respuestasD;

    // Use this for initialization
    void Start()
    {
        
        idPregunta = 0;

        EmpezarQuiz();


    }

    // Update is called once per frame
    void Update()
    {

        Puntuacion.text = "Aciertos: " + Aciertos;
        NºPregunta.text = idPregunta + 1 + " / 10";

    }

    void EmpezarQuiz()
    {
        if (idPregunta <= 9)
        {
            Debug.Log("Podemos seguir con el quiz");
            Pregunta.text = Preguntas[idPregunta];
            respuestaA.text = respuestasA[idPregunta];
            respuestaB.text = respuestasB[idPregunta];
            respuestaC.text = respuestasC[idPregunta];
            respuestaD.text = respuestasD[idPregunta];
        }
        else if (idPregunta >= 10)
        {
            Debug.Log("Acabaste");
            SceneManager.LoadScene("MENÚPRINCIPAL");
        }
    }



    public void BotónComprobarRespuesta(string respuesta)
    {
        if (respuesta == "A")
        {
            if (respuestasA[idPregunta] == RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
            }
            else
            {
                LedRojos[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(false);
            }
        }

        else if (respuesta == "B")
        {
            if (respuestasB[idPregunta] == RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
            }
            else
            {
                LedRojos[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(false);
            }
        }

        else if (respuesta == "C")
        {
            if (respuestasC[idPregunta] == RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
            }
            else
            {
                LedRojos[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(false);
            }
        }

        else if (respuesta == "D")
        {
            if (respuestasD[idPregunta] == RespuestasCorrectas[idPregunta])
            {
                Aciertos += 1;
                LedRojos[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
            }
            else
            {
                LedRojos[idPregunta].SetActive(true);
                LedNormales[idPregunta].SetActive(false);
                LedVerdesMoco[idPregunta].SetActive(false);
            }
        }

        ProximaPregunta();

    }

    public void ProximaPregunta()
    {
        idPregunta++;
        EmpezarQuiz();
    }

    public void PreguntaAnterior()
    {
        idPregunta--;
        EmpezarQuiz();
    }
}