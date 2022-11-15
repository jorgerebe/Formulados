using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Onlinne : MonoBehaviour, RealTimeMultiplayerListener
{

    public int Aciertos = 0;
    public int Puntop = 0;
    public Text Aciertoss;
    public Text idpregunttas;
    public Text idtemas;

    public Nivel1PYR[] Temas;
    public Button[] BotonesRespuestas;

    public int[] Temass;
    public int[] idPregunta;

    public Text textoniveles;
    public Text Tiempoo;
    public Text Pregunta;
    public Text Puntuacion;
    public Text NºPregunta;
    public Text respuestaA;
    public Text respuestaB;
    public Text respuestaC;
    public Text respuestaD;
    public Text espera;

    public int TemaActual;
    public int PreguntaActual;

    public int idNivell;
    public int[] Respuestas;

    public int recuento;
    public int recuentot = 0;
    public int recuentoy = 0;

    public float Tiempo;
    public float Tiempo2;
    public bool y = false;

    public GameObject Lobby;
    public GameObject Partida;
    public GameObject Texts;
    List<Participant> participants;

    int x = 0;
    public bool o = false;
    public bool l = false;
    public bool k = false;
    public bool iz = false;
    bool marcador = false;

    public float botones = 0.5f;

    public string[] idparticipants;
    public string myid;
    public int njugadores;

    public int envio = 0;

    public Text esperandos;

    // Use this for initialization
    void Start()
    {
        
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
        });

        SignIn();

        iz = false;

        esperandos.text = "";

        o = false;
        recuento = 0;
        Aciertos = 0;
        Tiempo = 10;
        y = false;
        Partida.SetActive(false);
        Lobby.SetActive(true);
        DesactivarBotones();
    }

    void SignIn()
    {
        if (Social.localUser.authenticated == true)
        {

        }
        else if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(success => { });
        }
    }

    // Update is called once per frame
    void Update()
    {
        idpregunttas.text = idPregunta[0] + "\n" + idPregunta[1] + "\n" + idPregunta[2] + "\n" + idPregunta[3] + "\n" + idPregunta[4] + "\n" + idPregunta[5] + "\n" + idPregunta[6] + "\n" + idPregunta[7] + "\n" + idPregunta[8] + "\n" + idPregunta[9];
        idtemas.text = Temass[0] + "\n" + Temass[1] + "\n" + Temass[2] + "\n" + Temass[3] + "\n" + Temass[4] + "\n" + Temass[5] + "\n" + Temass[6] + "\n" + Temass[7] + "\n" + Temass[8] + "\n" + Temass[9];

        Tiempoo.text = "Tiempo: " + Tiempo.ToString("f1");
        if (y == true)
        {
            Tiempo -= Time.deltaTime;
        }
        else
        {

        }
        if (Tiempo <= 0.42f)
        {
            DesactivarBotones();
            if (Tiempo <= 0)
            {
                y = false;
                SiguientePregunta();
            }
        }
        if(o == true)
        {
            if(marcador == false)
            {
                Marcador();
            }
            else
            {

            }

            if(recuento >= 9)
            {
                Texts.SetActive(false);
                if(Aciertos > Puntop)
                {
                    espera.text = "¡HAS GANADO!\t Has conseguido " + Aciertos + " puntos";
                }
                else if(Aciertos == Puntop)
                {
                    espera.text = "HAS EMPATADO\t Has conseguido " + Aciertos + " puntos";
                }
                else
                {
                    espera.text = "HAS PERDIDO\t Has conseguido " + Aciertos + " puntos";
                }
            }
            else
            {
                Texts.SetActive(false);
                espera.text = "SIGUIENTE PREGUNTA EN " + Tiempo.ToString("f1");
            }  
        }
        else if (o == false)
        {
            if (l == true)
            {
                Texts.SetActive(false);
                Tiempo2 -= Time.deltaTime;
                espera.text = "EMPEZANDO EN " + Tiempo2.ToString("f1");
                if (Tiempo2 <= 0)
                {
                    EmpezarQuiz();
                    l = false;
                }
            }
            else
            {
                Texts.SetActive(true);
                espera.text = "";
            }
        }

        if(k == true)
        {
            botones -= Time.deltaTime;
            if(botones <= 0)
            {
                CambiarColorBotones();
                k = false;
            }
        }
    }

    public void PartidaRapida()
    {
        Social.localUser.Authenticate((bool success) => {
        });
        if (Social.localUser.authenticated == true)
        {
            Social.localUser.Authenticate((bool success) =>
            {
            });
        }
        else if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(succes => { });
            SignIn();
        }
        const int MinOpponents = 1, MaxOpponents = 1;
        const int GameVariant = 0;
        PlayGamesPlatform.Instance.RealTime.CreateQuickGame(MinOpponents, MaxOpponents,
                    GameVariant, this);
        Lobby.SetActive(false);
        esperandos.text = "Por favor, espera...";
    }

    public void CreateWithInvitationScreen()
    {
        const int MinOpponents = 1, MaxOpponents = 1;
        const int GameVariant = 0;
        PlayGamesPlatform.Instance.RealTime.CreateWithInvitationScreen(MinOpponents, MaxOpponents,
                    GameVariant, this);
    }

    public void VerInvitaciones()
    {
        PlayGamesPlatform.Instance.RealTime.AcceptFromInbox(this);
    }

    public void OnRoomSetupProgress(float percent)
    {
        PlayGamesPlatform.Instance.RealTime.ShowWaitingRoomUI();
        throw new NotImplementedException();
    }

    public void OnRoomConnected(bool success)
    {
        if (success)
        {
            EmpezarPartida();
        }
        else
        {
            SceneManager.LoadScene("Online");
        }
        throw new NotImplementedException();
    }

    public void OnLeftRoom()
    {
        SceneManager.LoadScene("MENÚPRINCIPAL");
        throw new NotImplementedException();
    }

    public void OnParticipantLeft(Participant participant)
    {
        throw new NotImplementedException();
    }

    public void OnPeersConnected(string[] participantIds)
    {
        throw new NotImplementedException();
    }

    public void OnPeersDisconnected(string[] participantIds)
    {
        throw new NotImplementedException();
    }

    public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
    {
        int z;
        z = BitConverter.ToInt32(data, 0);

        if(iz == false)
        {
            if (z > 10)
            {
                idPregunta[recuentot] = z - 20;
                recuentot++;
            }
            else if (z < -10)
            {
                Temass[recuentoy] = z + 20;
                recuentoy++;
            }
        }
        else if(iz == true)
        {
            Puntop = z;
            ActualizarPuntuacion();
        }

        throw new NotImplementedException();
    }

    public void EnviarDato()
    {
        byte[] message = BitConverter.GetBytes(Aciertos);
        bool reliable = true;
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(reliable, message);
        ActualizarPuntuacion();
    }

    public void Marcador()
    {
        if (Aciertos > Puntop)
        {
            PlayerPrefs.SetInt("Carreraas", PlayerPrefs.GetInt("Carreraas") + 2);
        }
        else
        {
            PlayerPrefs.SetInt("Carreraas", PlayerPrefs.GetInt("Carreraas") + 1);
        }
        if (Social.localUser.authenticated == true)
        {
                    Social.ReportScore(PlayerPrefs.GetInt("Carreraas"), "CgkIvc_dmdYEEAIQCA", (bool success) => { });
        }
                else if (Social.localUser.authenticated == false)
                {
                    Social.localUser.Authenticate(success => { });
                    Social.ReportScore(PlayerPrefs.GetInt("Carreraas"), "CgkIvc_dmdYEEAIQCA", (bool success) => { });
                }        
        marcador = true;
    }

    public void ActualizarPuntuacion()
    {

        if (Puntop < Aciertos)
        {
            Puntuacion.text = "P1: " + Aciertos + " ptos";
        }
        else if (Puntop > Aciertos)
        {
            Puntuacion.text = "P2: " + Aciertos + " ptos";
        }
        else
        {
            Puntuacion.text = "P1: " + Aciertos + " ptos";
        }
    }

        void EmpezarPartida()
        {
        esperandos.text = "";
        recuento = 0;
        recuentot = 0;
        recuentoy = 0;
            Tiempo2 = 12;
            x = 0;
            Lobby.SetActive(false);
            Partida.SetActive(true);
            Texts.SetActive(true);
            x = 0;

        participants = PlayGamesPlatform.Instance.RealTime.GetConnectedParticipants();
        njugadores = participants.Count;
        myid = PlayGamesPlatform.Instance.RealTime.GetSelf().ParticipantId;

        int u = 0;
        while (u < njugadores) 
        {
            idparticipants[u] = participants[u].ParticipantId;
            u++;
        }


        if (myid == idparticipants[1])
        {
            while (x < 10)
            {
                Temass[x] = UnityEngine.Random.Range(0, 5);
                idPregunta[x] = UnityEngine.Random.Range(0, 150);
                x++;
            }
            StartCoroutine(Espera1());
        }
        else
        {

        }
        o = false;
        l = true;
    }

    IEnumerator Espera1()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(EnviarDatosPreguntas());
    }

    void EmpezarQuiz()
    {
        iz = true;
        ActivarBotones();
        o = false;
        Tiempo = 10;
        y = true;
        NºPregunta.text = recuento + 1 + "/10";
        if (recuento >= 10)
        {
            PlayerPrefs.SetString("eeee", "Carrera");
            NºPregunta.text = recuento + "/10";
            if(Aciertos > Puntop)
            {
                PlayerPrefs.SetInt("CarreraPodio", 2);
            }
            else if(Aciertos == Puntop)
            {
                PlayerPrefs.SetInt("CarreraPodio", 1);
            }
            else if(Aciertos < Puntop)
            {
                PlayerPrefs.SetInt("CarreraPodio", 0);
            }

            AcabarQuiz();
        }
        else
        {

        }

        PreguntaActual = idPregunta[recuento];
        TemaActual = Temass[recuento];
        if (idPregunta[recuento] <= 14)
        {
            idNivell = 0;
        }
        else if (idPregunta[recuento] <= 29)
        {
            idNivell = 1;
        }
        else if (idPregunta[recuento] <= 44)
        {
            idNivell = 2;
        }
        else if (idPregunta[recuento] <= 59)
        {
            idNivell = 3;
        }
        else if (idPregunta[recuento] <= 74)
        {
            idNivell = 4;
        }
        else if (idPregunta[recuento] <= 89)
        {
            idNivell = 5;
        }
        else if (idPregunta[recuento] <= 104)
        {
            idNivell = 6;
        }
        else if (idPregunta[recuento] <= 119)
        {
            idNivell = 7;
        }
        else if (idPregunta[recuento] <= 134)
        {
            idNivell = 8;
        }
        else if (idPregunta[recuento] <= 149)
        {
            idNivell = 9;
        }

        AsignarPreguntas();
    }

    void AsignarPreguntas()
    {
        PreguntaActual = idPregunta[recuento];
        TemaActual = Temass[recuento];
        if (idPregunta[recuento] <= 14)
        {
            idNivell = 0;
        }
        else if (idPregunta[recuento] <= 29)
        {
            idNivell = 1;
        }
        else if (idPregunta[recuento] <= 44)
        {
            idNivell = 2;
        }
        else if (idPregunta[recuento] <= 59)
        {
            idNivell = 3;
        }
        else if (idPregunta[recuento] <= 74)
        {
            idNivell = 4;
        }
        else if (idPregunta[recuento] <= 89)
        {
            idNivell = 5;
        }
        else if (idPregunta[recuento] <= 104)
        {
            idNivell = 6;
        }
        else if (idPregunta[recuento] <= 119)
        {
            idNivell = 7;
        }
        else if (idPregunta[recuento] <= 134)
        {
            idNivell = 8;
        }
        else if (idPregunta[recuento] <= 149)
        {
            idNivell = 9;
        }
        textoniveles.text = Temas[TemaActual].nombregeneral + " / " + Temas[TemaActual].nombreniveles[idNivell];
        Pregunta.text = Temas[TemaActual].Preguntas[PreguntaActual];
        AsignarRespuestaA();
    }

    void AsignarRespuestaA()
    {
        Respuestas[0] = UnityEngine.Random.Range(0, 4);
        if (Respuestas[0] == 0)
        {
            respuestaA.text = Temas[TemaActual].respuestasA[PreguntaActual];
        }
        else if (Respuestas[0] == 1)
        {
            respuestaA.text = Temas[TemaActual].respuestasB[PreguntaActual];
        }
        else if (Respuestas[0] == 2)
        {
            respuestaA.text = Temas[TemaActual].respuestasC[PreguntaActual];
        }
        else if (Respuestas[0] == 3)
        {
            respuestaA.text = Temas[TemaActual].respuestasD[PreguntaActual];
        }

        AsignarRespuestaB();
    }

    void AsignarRespuestaB()
    {
        Respuestas[1] = UnityEngine.Random.Range(0, 4);
        if (Respuestas[0] == Respuestas[1])
        {
            AsignarRespuestaB();
        }
        if (Respuestas[1] == 0)
        {
            respuestaB.text = Temas[TemaActual].respuestasA[PreguntaActual];
        }
        else if (Respuestas[1] == 1)
        {
            respuestaB.text = Temas[TemaActual].respuestasB[PreguntaActual];
        }
        else if (Respuestas[1] == 2)
        {
            respuestaB.text = Temas[TemaActual].respuestasC[PreguntaActual];
        }
        else if (Respuestas[1] == 3)
        {
            respuestaB.text = Temas[TemaActual].respuestasD[PreguntaActual];
        }
        AsignarRespuestaC();
    }

    void AsignarRespuestaC()
    {

        Respuestas[2] = UnityEngine.Random.Range(0, 4);
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
            respuestaC.text = Temas[TemaActual].respuestasA[PreguntaActual];
        }
        else if (Respuestas[2] == 1)
        {
            respuestaC.text = Temas[TemaActual].respuestasB[PreguntaActual];
        }
        else if (Respuestas[2] == 2)
        {
            respuestaC.text = Temas[TemaActual].respuestasC[PreguntaActual];
        }
        else if (Respuestas[2] == 3)
        {
            respuestaC.text = Temas[TemaActual].respuestasD[PreguntaActual];
        }
        AsignarRespuestaD();
    }

    void AsignarRespuestaD()
    {
        Respuestas[3] = UnityEngine.Random.Range(0, 4);
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
            respuestaD.text = Temas[TemaActual].respuestasA[PreguntaActual];
        }
        else if (Respuestas[3] == 1)
        {
            respuestaD.text = Temas[TemaActual].respuestasB[PreguntaActual];
        }
        else if (Respuestas[3] == 2)
        {
            respuestaD.text = Temas[TemaActual].respuestasC[PreguntaActual];
        }
        else if (Respuestas[3] == 3)
        {
            respuestaD.text = Temas[TemaActual].respuestasD[PreguntaActual];
        }
    }

    public void BotónComprobarRespuesta(string respuesta)
    {
        if (respuesta == "A")
        {
            if (respuestaA.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                Aciertos++;
                BotonesRespuestas[0].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[0].image.color = Color.red;
                Aciertos--;
            }
        }

        else if (respuesta == "B")
        {
            if (respuestaB.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                Aciertos++;
                BotonesRespuestas[1].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[1].image.color = Color.red;
                Aciertos--;
            }
        }

        else if (respuesta == "C")
        {
            if (respuestaC.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                Aciertos++;
                BotonesRespuestas[2].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[2].image.color = Color.red;
                Aciertos--;
            }
        }

        else if (respuesta == "D")
        {
            if (respuestaD.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                Aciertos++;
                BotonesRespuestas[3].image.color = Color.green;
            }
            else
            {
                BotonesRespuestas[3].image.color = Color.red;
                Aciertos--;
            }
        }

        DesactivarBotones();

        if (PlayerPrefs.GetInt("MostrarRespuesta") == 1)
        {
            if (respuestaA.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                BotonesRespuestas[0].image.color = Color.green;
            }
            else if (respuestaB.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                BotonesRespuestas[1].image.color = Color.green;
            }
            else if (respuestaC.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                BotonesRespuestas[2].image.color = Color.green;
            }
            else if (respuestaD.text == Temas[TemaActual].RespuestasCorrectas[PreguntaActual])
            {
                BotonesRespuestas[3].image.color = Color.green;
            }
        }

        if(Tiempo < 1)
        {
            BotonesRespuestas[0].image.color = Color.white;
            BotonesRespuestas[1].image.color = Color.white;
            BotonesRespuestas[2].image.color = Color.white;
            BotonesRespuestas[3].image.color = Color.white;
        }

        EnviarDato();
        botones = 0.5f;
        k = true;

        /*RespuestaAs[0].interactable = true;
        RespuestaAs[1].interactable = true;*/
    }

    void DesactivarBotones()
    {
        BotonesRespuestas[0].interactable = false;
        BotonesRespuestas[1].interactable = false;
        BotonesRespuestas[2].interactable = false;
        BotonesRespuestas[3].interactable = false;
    }

    void ActivarBotones()
    {
        BotonesRespuestas[0].interactable = true;
        BotonesRespuestas[1].interactable = true;
        BotonesRespuestas[2].interactable = true;
        BotonesRespuestas[3].interactable = true;
    }

    void CambiarColorBotones()
    {
        if(Tiempo > 1)
        {
            BotonesRespuestas[0].image.color = Color.white;
            BotonesRespuestas[1].image.color = Color.white;
            BotonesRespuestas[2].image.color = Color.white;
            BotonesRespuestas[3].image.color = Color.white;
            o = true;
        }
        else
        {
                  
        }
    }

    void SiguientePregunta()
    {
        recuento++;
        EnviarDato();
        EmpezarQuiz();
    }

    IEnumerator EnviarDatosPreguntas()
    {
        byte[]message = BitConverter.GetBytes(idPregunta[envio] + 20);
        bool reliable = true;
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(reliable, message);
        yield return new WaitForSeconds(0.4f);
        byte[] tema = BitConverter.GetBytes(Temass[envio] - 20);
        PlayGamesPlatform.Instance.RealTime.SendMessageToAll(reliable, tema);

        if(envio < 9)
        {
            envio++;
            yield return new WaitForSeconds(0.4f);
            StartCoroutine(EnviarDatosPreguntas());
        }

        else
        {

        }
    }

    public void Menú()
    {
        SceneManager.LoadScene("MENÚPRINCIPAL");
    }

    public void Salir()
    {
        Application.Quit();
    }

    void AcabarQuiz()
    {
        SceneManager.LoadScene("Podio");
    }

}
