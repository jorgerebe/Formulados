using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
public class Animaciones : MonoBehaviour
{
    public int idnivel;

    public int Aciertos;
    public string TemaTrofeos;
    bool menu1 = false;
    public GameObject Textos;
    public AudioSource Leva;
    public Animator animator;
    public bool BotónPantalla;
    public bool BotónAtrásAnimaciónInvertida;
    public float tiempo;

    public GameObject PantallaObject;
    public GameObject PantallaBoton;
    public GameObject BotonesRank;

    public GameObject[] BotonAtrás;

    //public GameObject Menú1;
    public GameObject Menú2;

    public GameObject[] menu;

    public GameObject[] NivelesPreguntas;
    private int idTema;
    public int idnivell;
    private int idMenú;

    public GameObject x;

    public GameObject[] TrofeosTotales;

    // Use this for initialization
    void Start()
    {
        /*if (PlayerPrefs.GetInt("Salida") == 1)
        {
            PlayerPrefs.SetInt("Salida", 0);
            if(Random.Range(0, 3) == 2)
            {
                Advertisement.Show();
            }
        }*/

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();

        SignIn();
        idTema = 0;
        BotónPantalla = false;
        BotónAtrásAnimaciónInvertida = false;
        menu[0].SetActive(false);
        menu[1].SetActive(false);
        BotonAtrás[0].SetActive(false);
        BotonAtrás[1].SetActive(false);
        BotonAtrás[2].SetActive(false);

        int xxxxx = 0;
        int y = 0;

        while (xxxxx <= 9)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + xxxxx);
            xxxxx++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQAg", 100.0f, (bool success) => { });
            TrofeosTotales[0].SetActive(true);
        }

        xxxxx = 10;
        y = 0;

        while (xxxxx <= 19)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + xxxxx);
            xxxxx++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQAw", 100.0f, (bool success) => { });
            TrofeosTotales[1].SetActive(true);
        }

        xxxxx = 20;
        y = 0;

        while (xxxxx <= 29)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + xxxxx);
            xxxxx++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQBA", 100.0f, (bool success) => { });
            TrofeosTotales[2].SetActive(true);
        }

        xxxxx = 30;
        y = 0;

        while (xxxxx <= 39)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + xxxxx);
            xxxxx++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQBQ", 100.0f, (bool success) => { });
            TrofeosTotales[3].SetActive(true);
        }

        xxxxx = 40;
        y = 0;

        while (xxxxx <= 49)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + xxxxx);
            xxxxx++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQBg", 100.0f, (bool success) => { });
            TrofeosTotales[4].SetActive(true);
        }

    }

    public void Superrapido()
    {
        SceneManager.LoadScene("PreguntasSuperrápidas");
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();

        animator.SetBool("BotónPantalla", BotónPantalla);
        animator.SetBool("BotónAtrás", BotónAtrásAnimaciónInvertida);

        if (PantallaObject.transform.localScale.y == 1.5)
        {
            if (menu1 == true)
            {
                Menú2.SetActive(true);
                BotonAtrás[0].SetActive(true);
                BotonesRank.SetActive(true);
            }
        }
        if (PantallaObject.transform.localScale.y == 1.3)
        {
            x.SetActive(true);
            BotónPantalla = true;
            PantallaBoton.SetActive(true);
            Textos.SetActive(true);
        }

        if (Textos.activeInHierarchy == true)
        {
            PantallaBoton.SetActive(true);
        }
        
    }

    public void AnimaciónClip()
    {
        BotónAtrásAnimaciónInvertida = false;
        x.SetActive(false);
        BotónPantalla = true;
        PantallaBoton.SetActive(false);
        Textos.SetActive(false);
        StartCoroutine(VAMOS());
    }

    IEnumerator VAMOS()
    {
        yield return new WaitForSeconds(tiempo);
        menu1 = true;
        BotónPantalla = false;
    }

    public void SeleccionarMenú(int x)
    {
        if (x == 1)
        {
            SceneManager.LoadScene("Online");
        }
        if (x == 2)
        {
            SceneManager.LoadScene("PreguntasSuperrápidas");
        }
        else if (x == 3)
        {
            menu1 = false;
            Menú2.SetActive(false);
            BotonAtrás[0].SetActive(false);
            BotonAtrás[1].SetActive(true);
            Leva.Play();
            menu[x - 1].SetActive(true);
            idMenú = x - 1;
        }
        else
        {
            menu1 = false;
            Menú2.SetActive(false);
            BotonAtrás[0].SetActive(false);
            BotonAtrás[1].SetActive(true);
            Leva.Play();
            menu[x].SetActive(true);
            idMenú = x;
        }
    }

    public void SeleccionarTemaPreguntas(int i)
    {
        Menú2.SetActive(false);
        menu1 = false;
        Leva.Play();
        menu[idMenú].SetActive(false);
        BotonAtrás[1].SetActive(false);
        BotonAtrás[2].SetActive(true);
        NivelesPreguntas[i].SetActive(true);
        idTema = i;
        TemaTrofeos = NivelesPreguntas[i].ToString();
        PlayerPrefs.SetString("Tema", TemaTrofeos);
    }

    public void SeleccionarTemaRadios(int o)
    {
        menu1 = false;
        menu[idMenú].SetActive(false);
        BotonAtrás[1].SetActive(false);
        BotonAtrás[2].SetActive(true);
        Leva.Play();
        idTema = o;
    }

    public void BotónAtrásAnimación()
    {
        menu1 = false;
        Leva.Play();
        BotónAtrásAnimaciónInvertida = true;
        Menú2.SetActive(false);
        BotonesRank.SetActive(false);
        BotonAtrás[0].SetActive(false);
        BotonAtrás[1].SetActive(false);
        StartCoroutine(ATRAS());
    }

    IEnumerator ATRAS()
    {
        yield return new WaitForSeconds(tiempo);
        x.SetActive(true);
        BotónPantalla = false;
        Textos.SetActive(true);
        BotónAtrásAnimaciónInvertida = false;
    }

    public void BotónAtrás2()
    {
        if (Menú2.activeInHierarchy == true)
        {
            BotónAtrásAnimación();
        }
        else
        {
            switch (idMenú)
            {
                case 0:
                    menu1 = true;
                    menu[1].SetActive(false);
                    Menú2.SetActive(true);
                    Leva.Play();
                    BotonAtrás[0].SetActive(true);
                    BotonAtrás[1].SetActive(false);
                    break;
                case 1:
                    menu1 = true;
                    menu[1].SetActive(false);
                    Menú2.SetActive(true);
                    Leva.Play();
                    BotonAtrás[0].SetActive(true);
                    BotonAtrás[1].SetActive(false);
                    break;
                default:
                    Menú2.SetActive(true);
                    menu[idMenú].SetActive(false);
                    Leva.Play();
                    break;
            }
        }
    }

    public void BotónAtrás3()
    {
        Leva.Play();
        BotonAtrás[1].SetActive(true);
        BotonAtrás[2].SetActive(false);
        NivelesPreguntas[idTema].SetActive(false);

        menu[idMenú].SetActive(true);
    }

    public void idNivel(int x)
    {
        Leva.Play();
        idnivell = x;
        PlayerPrefs.SetInt("idnivel", idnivell);
    }

    public void CargarLaBonitaEscena(string Tema)
    {
        if (Tema == "Radios1")
        {
            PlayerPrefs.SetString("eeee", Tema);
            SceneManager.LoadScene("Radios1");
        }
        else
        {
            PlayerPrefs.SetString("eeee", "");
            SceneManager.LoadScene("F1EnGeneral");
        }
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

    public void MostrarLogros()
    {
        if (Social.localUser.authenticated == true)
        {
            Social.ShowAchievementsUI();
        }
        else
        {
            Social.localUser.Authenticate(success => { });
            Social.ShowAchievementsUI();
        }
    }

    public void MostrarClasificacion()
    {
        if (Social.localUser.authenticated == true)
        {
            Social.ShowLeaderboardUI();
        }
        else
        {
            Social.localUser.Authenticate(success => { });
            Social.ShowLeaderboardUI();
        }
    }
}

