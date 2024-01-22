using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour
{


    void OnEnable()
    {
        Sender.PlayerDiedInfo += PlayerDiedThanRestart;
        Sender.PlayerDiedInfo += PlayerDiedNews;
    }

    void OnDisable()
    {
        Sender.PlayerDiedInfo -= PlayerDiedThanRestart;
        Sender.PlayerDiedInfo -= PlayerDiedNews;
    }
    void PlayerDiedThanRestart()
    {
        Debug.Log("restart");
    }

    void PlayerDiedNews()
    {
        Debug.Log("Player has died");
    }

}
