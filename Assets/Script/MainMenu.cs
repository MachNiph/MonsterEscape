using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayControl()
    {

        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameController.instance.CharSelect = selectedCharacter;
        SceneManager.LoadScene("GamePlay");
      
    }
    
}
