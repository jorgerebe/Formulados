using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Copassssss : MonoBehaviour
{
    public int prueba1 ;
    public int idnivell;
    public string Tema;
    public string Trofeosss;
    public static Copassssss estescript;
    public GameObject[] Trofeos1;
    public GameObject[] Trofeos2;
    public GameObject[] Trofeos3;
    public GameObject[] Trofeos4;
    public GameObject[] Temas;
    Scene scene;
    public int idnivel;
    public string TemaTrofeos;
    public int Aciertos;

    // Use this for initialization
    void Start()
    {
        print("Hola");
        prueba1 = 0;

        while (prueba1 <= 60)
        {
            if (PlayerPrefs.GetInt("Preferencias1" + prueba1) > 0)
            {
                Trofeos1[prueba1].SetActive(true);
            }

            prueba1++;
        }
        prueba1 = 0;

        while (prueba1 <= 60)
        {
            if (PlayerPrefs.GetInt("Preferencias2" + prueba1) > 0)
            {
                Trofeos2[prueba1].SetActive(true);
            }

            prueba1++;
        }
        prueba1 = 0;

        while (prueba1 <= 60)
        {
            if (PlayerPrefs.GetInt("Preferencias3" + prueba1) > 0)
            {
                Trofeos3[prueba1].SetActive(true);
            }

            prueba1++;
        }
        prueba1 = 0;
        while (prueba1 <= 60)
        {
            if (PlayerPrefs.GetInt("Preferencias4" + prueba1) > 0)
            {
                Trofeos4[prueba1].SetActive(true);
            }

            prueba1++;
        }
    }
    // Update is called once per frame
    void Update()
    {

        scene = SceneManager.GetActiveScene();

        if (scene.name == "MENÚPRINCIPAL")
        {
            if (PlayerPrefs.GetFloat("a") <= .59f)
            {
                Temas[0].SetActive(true);
                Temas[1].SetActive(true);
                Temas[2].SetActive(true);
                Temas[3].SetActive(true);
                Temas[4].SetActive(true);
                Temas[5].SetActive(true);
            }

        }
        else
        {
            Temas[0].SetActive(false);
            Temas[1].SetActive(false);
            Temas[2].SetActive(false);
            Temas[3].SetActive(false);
            Temas[4].SetActive(false);
            Temas[5].SetActive(false);
        }

        idnivel = PlayerPrefs.GetInt("IdNivel");
        Aciertos = PlayerPrefs.GetInt("Aciertos");
        TemaTrofeos = PlayerPrefs.GetString("Tema");
        switch (PlayerPrefs.GetString("Tema"))
        {
            case ("F1ENGENERAL (UnityEngine.GameObject)"):

                if (Aciertos == 15)
                {
                    Trofeos1[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias1" + idnivel, idnivel);
                }
                else if (Aciertos == 14)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 13)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 12)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 11)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 10)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 9)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 8)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 7)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 6)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 5)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else
                {
                    Trofeos4[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias4" + idnivel, idnivel);
                }
                break;
            case ("F1ESPAÑOLA (UnityEngine.GameObject)"):

                if (Aciertos == 15)
                {
                    Trofeos1[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias1" + idnivel, idnivel);
                }
                else if (Aciertos == 14)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 13)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 12)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 11)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 10)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 9)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 8)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 7)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 6)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 5)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else
                {
                    Trofeos4[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias4" + idnivel, idnivel);
                }
                break;
            case ("PILOTOSLEGENDARIOS (UnityEngine.GameObject)"):

                if (Aciertos == 15)
                {
                    Trofeos1[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias1" + idnivel, idnivel);
                }
                else if (Aciertos == 14)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 13)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 12)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 11)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 10)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 9)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 8)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 7)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 6)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 5)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else
                {
                    Trofeos4[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias4" + idnivel, idnivel);
                }
                break;
            case ("EQUIPOSLEGENDARIOS (UnityEngine.GameObject)"):

                if (Aciertos == 15)
                {
                    Trofeos1[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias1" + idnivel, idnivel);
                }
                else if (Aciertos == 14)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 13)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 12)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 11)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 10)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 9)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 8)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 7)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 6)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 5)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else
                {
                    Trofeos4[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias4" + idnivel, idnivel);
                }
                break;
            case ("CIRCUITOSLEGENDARIOS (UnityEngine.GameObject)"):

                if (Aciertos == 15)
                {
                    Trofeos1[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias1" + idnivel, idnivel);
                }
                else if (Aciertos == 14)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 13)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 12)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 11)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 10)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 9)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 8)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 7)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 6)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 5)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else
                {
                    Trofeos4[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias4" + idnivel, idnivel);
                }
                break;
            default:

                if (Aciertos == 15)
                {
                    Trofeos1[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias1" + idnivel, idnivel);
                }
                else if (Aciertos == 14)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 13)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 12)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 11)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 10)
                {
                    Trofeos2[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias2" + idnivel, idnivel);
                }
                else if (Aciertos == 9)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 8)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 7)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 6)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else if (Aciertos == 5)
                {
                    Trofeos3[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias3" + idnivel, idnivel);
                }
                else
                {
                    Trofeos4[idnivel].SetActive(true);
                    PlayerPrefs.SetInt("Preferencias4" + idnivel, idnivel);
                }
                break;
        }

    }

    void Awake()
    {
        if (estescript == null)
        {
            estescript = this;
            DontDestroyOnLoad(gameObject);
        }else if (estescript != this)
        {
            Destroy(gameObject);
        }
    }
    public void Reiniciar()
    {
        //PlayerPrefs.DeleteAll();
    }

    public void Salir()
    {
        Application.Quit();
    }
}

    
