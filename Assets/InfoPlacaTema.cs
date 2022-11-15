using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoPlacaTema : MonoBehaviour {

    public GameObject[] Trofeos;
    public int idnivelll;
    int Aciertos = 0;

    // Use this for initialization
    void Start() {
        Trofeos[0].SetActive(false);
        Trofeos[1].SetActive(false);
        Trofeos[2].SetActive(false);

        /*if (PlayerPrefs.GetInt("Aciertos" + 60 + idnivelll.ToString()) < PlayerPrefs.GetInt("Aciertos" + idnivelll.ToString()))
        {
            Aciertos = PlayerPrefs.GetInt("Aciertos" + idnivelll.ToString());
            PlayerPrefs.SetInt("Aciertos" + 60 + idnivelll.ToString(), Aciertos);
        }*/
        Aciertos = PlayerPrefs.GetInt("Aciertos" + idnivelll.ToString());
        if (Aciertos < 5)
        {
            if (Aciertos > 0)
            {
            Trofeos[2].SetActive(true);
            }
        }
        else if (Aciertos <= 14)
        {
            Trofeos[1].SetActive(true);
            Trofeos[2].SetActive(true);
        }
        else if (Aciertos == 15)
        {
            Trofeos[0].SetActive(true);
            Trofeos[1].SetActive(true);
            Trofeos[2].SetActive(true);
        }
    }

    public void BorrarDatos()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MENÚPRINCIPAL");
    }

    // Update is called once per frame
    void Update () {
    }
}
