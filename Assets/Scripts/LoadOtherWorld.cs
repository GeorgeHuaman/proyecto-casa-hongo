using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOtherWorld : MonoBehaviour
{
    public void OpenRoom(string roomUrl)
    {
        if (!string.IsNullOrEmpty(roomUrl))
        {
#if UNITY_WEBGL && !UNITY_EDITOR
                Application.ExternalEval("window.open('" + roomUrl + "', '_blank')");
#else
            Debug.LogWarning("Este método solo funciona en WebGL.");
#endif
        }
        else
        {
            Debug.LogWarning("La URL de la sala está vacía.");
        }
    }

}
