using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public void OpenWebUrl(string Url){
        Application.OpenURL(Url);
    }
}
