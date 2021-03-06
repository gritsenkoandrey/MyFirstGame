﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScene : MonoBehaviour
{
    #region Fields

    [SerializeField] private int _loadingScene; // выбор сцены для загрузки

    private float _progressBar = 0.9f;

    [SerializeField] private Image _loadingImage;
    [SerializeField] private Text _progressText;

    #endregion


    #region UnityMethod

    private void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    #endregion


    #region Method

    private IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_loadingScene); // загружаем сцену

        while (!operation.isDone) // пока операция не завершена обновляем прогресс
        {
            float progress = operation.progress / _progressBar; // для того чтобы кружок прогресса доходил до конца
            _loadingImage.fillAmount = operation.progress; // обращаемся в загруженной картинке к полю Fill Amount
            _progressText.text = string.Format("{0:0}%", progress * 100); // string.Format("{0:0}%") для отображения целых чисел, без плавающей запятой
            yield return null; // пропускаем кадр
        }
    }

    #endregion
}