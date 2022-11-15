using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotaFinal : MonoBehaviour {

    public AudioSource bizet;
    public GameObject[] botellaschampagne;
    int b = 0;
    int Aciertos;

    // Use this for initialization
    void Start ()
    {

        if (PlayerPrefs.GetString("eeee") == "Carrera")
        {
            if (PlayerPrefs.GetInt("CarreraPodio") == 0)
            {
                botellaschampagne[2].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("CarreraPodio") == 1)
            {
                botellaschampagne[1].SetActive(true);
            }
            else
            {
                botellaschampagne[0].SetActive(true);
            }
        }

        else if (PlayerPrefs.GetString("eeee") == "Radios1")
        {
            if (PlayerPrefs.GetFloat("AciertosRadios") < 2)
            {
                if (PlayerPrefs.GetFloat("AciertosRadios") > 0)
                {
                    botellaschampagne[2].SetActive(true);
                }
            }
            else if (PlayerPrefs.GetFloat("AciertosRadios") <= 4)
            {
                botellaschampagne[1].SetActive(true);
            }
            else if (PlayerPrefs.GetFloat("AciertosRadios") == 5)
            {
                botellaschampagne[0].SetActive(true);
            }
        }
        else if (PlayerPrefs.GetString("eeee") == "Qualy")
        {
            botellaschampagne[PlayerPrefs.GetInt("PodioSuper")].SetActive(true);
        }
        else
        {
            if (PlayerPrefs.GetInt("Aciertos" + PlayerPrefs.GetInt("idnivel".ToString())) < 7)
            {
                if (PlayerPrefs.GetInt("Aciertos" + PlayerPrefs.GetInt("idnivel".ToString())) > 0)
                {
                    botellaschampagne[2].SetActive(true);
                }
            }
            else if (PlayerPrefs.GetInt("Aciertos" + PlayerPrefs.GetInt("idnivel".ToString())) <= 14)
            {
                botellaschampagne[1].SetActive(true);
            }
            else if (PlayerPrefs.GetInt("Aciertos" + PlayerPrefs.GetInt("idnivel".ToString())) == 15)
            {
                botellaschampagne[0].SetActive(true);
            }
        }   


        PlayerPrefs.Save();
        int a = 0;
        while (a <= 49)
        {
            b = b + PlayerPrefs.GetInt("Aciertos" + a);
            a++;
        }

        Social.ReportScore(b, "CgkIvc_dmdYEEAIQAQ", (bool success) => { });

        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate(success => { });
            Social.ReportScore(b, "CgkIvc_dmdYEEAIQAQ", (bool success) => { });
        }

        int x = 0;
        int y = 0;

        while (x <= 9)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + x);
            x++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQAg", 100.0f, (bool success) => { });
        }

        x = 10;
        y = 0;

        while (x <= 19)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + x);
            x++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQAw", 100.0f, (bool success) => { });
        }

        x = 20;
        y = 0;

        while (x <= 29)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + x);
            x++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQBA", 100.0f, (bool success) => { });
        }

        x = 30;
        y = 0;

        while (x <= 39)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + x);
            x++;
        }
        if (y == 150)
        {
            Social.ReportProgress("CgkIvc_dmdYEEAIQBQ", 100.0f, (bool success) => { });
        }

        x = 40;
        y = 0;

        while (x <= 49)
        {
            y = y + PlayerPrefs.GetInt("Aciertos" + x);
            x++;
        }
       if (y == 150)
       {
            Social.ReportProgress("CgkIvc_dmdYEEAIQBg", 100.0f, (bool success) => { });
       }

        bizet.PlayDelayed(0.1f);
        StartCoroutine(EMPEZAR());
	}
	
    IEnumerator EMPEZAR()
    {
        yield return new WaitForSeconds(7.2f);
        SceneManager.LoadScene("MENÚPRINCIPAL");
    }

    public void AbrirURL()
    {
        Application.OpenURL("http://soymotor.com");
    }

	// Update is called once per frame
	void Update () {

	}
}
