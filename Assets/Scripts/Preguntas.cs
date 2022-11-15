using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Preguntas : MonoBehaviour
{
    public abstract void activarBotones();
    public abstract void desactivarBotones();

    public abstract void Eliminar1RespuestaIncorrecta();
    public abstract void Eliminar2RespuestasIncorrectas();
}
