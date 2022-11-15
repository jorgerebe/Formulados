using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RADIOSyRESPUESTAS : MonoBehaviour {

    //public NumeroNivel idNivelll;

    public Text RespuestaUser;
    public AudioSource Pregunta;
    public Text Puntuacion;
    public Text NºPregunta;


    public GameObject[] LedNormales;
    public GameObject[] LedRojos;
    public GameObject[] LedVerdesMoco;

    public int idPregunta;
    private int Aciertos;
    public int idNivell;
    public int intentos;

    public AudioClip[] Preguntas;
    public string[] RespuestasCorrectas;

    // Use this for initialization
    void Start() {

        Aciertos = 0;
        intentos = 0;

        //idNivelll = GameObject.Find("Nivel").GetComponent<NumeroNivel>();
      //  idNivell = idNivelll.idNivelL;

      //  idNivelll.enabled = false;

        if (idNivell == 0)
        {
            idPregunta = 0;
            EmpezarQuiz();
        }
        else
        {
            idPregunta = idNivell * 10;
            EmpezarQuiz();
        }
    }

    // Update is called once per frame
    void Update() {

        Puntuacion.text = "Aciertos: "+Aciertos;
        NºPregunta.text = idPregunta + 1 + " / 5";
    }

    void EmpezarQuiz()
    {
        if (intentos <= 4)
        {
            Debug.Log("Podemos seguir con el quiz");
            Pregunta.clip = Preguntas[idPregunta];
        }
        else if (intentos >= 5)
        {
            Debug.Log("Acabaste");
            SceneManager.LoadScene("MENÚPRINCIPAL");
        }
    }

    public void PlayAudio()
    {
        Pregunta = GetComponent<AudioSource>();
        Pregunta.PlayDelayed(0);
    }

    public void BotónComprobarRespuesta()
    {
        ComprobarRespuesta();
    }

    void ComprobarRespuesta()
    {
        if (RespuestaUser.text == RespuestasCorrectas[idPregunta])
        {
            Debug.Log("Acertaste");
            Aciertos++;
            intentos++;
            LedNormales[idPregunta].SetActive(false);
            LedRojos[idPregunta].SetActive(false);
            LedVerdesMoco[idPregunta].SetActive(true);
            ProximaPregunta();
        }
        else
        {
            intentos++;
            Debug.Log("Fallaste");
            LedNormales[idPregunta].SetActive(false);
            LedVerdesMoco[idPregunta].SetActive(false);
            LedRojos[idPregunta].SetActive(true);
            ProximaPregunta();
        }
    }
        
        void ProximaPregunta()
        {
            idPregunta++;
            EmpezarQuiz();
        }
}