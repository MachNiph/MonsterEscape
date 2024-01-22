using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{

    public delegate void PlayerDied();
    public static event PlayerDied PlayerDiedInfo;
    void Start()
    {
        Invoke("OnEvent", 4f);
    }

    void OnEvent()
    {
        if (PlayerDiedInfo != null)
        {
            PlayerDiedInfo();
        }
    }
  
    
}












