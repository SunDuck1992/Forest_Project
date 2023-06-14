using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _canvas;

    private void OnEnable()
    {
        _player.Died += OnGameOver;
    }

    private void OnDisable()
    {
        _player.Died -= OnGameOver;
    }

    private void OnGameOver()
    {
        DontDestroy obj = FindObjectOfType<Sound>().GetComponent<DontDestroy>();
        obj.DestroyObject();
        Time.timeScale = 0;
        _canvas.gameObject.SetActive(true);
    }
}
