﻿using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControls : MonoBehaviour
{
    #region Method

    public void PlayPressed()
    {
        SceneManager.LoadScene(4);
        //AudioSound._audioSound.AudioPressButtonStart();
    }

    public void ExitPressed()
    {
        Application.Quit(); // метод работает только в билде
    }

    #endregion
}