using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>())
        {
            DontDestroy obj = FindObjectOfType<Sound>().GetComponent<DontDestroy>();
            obj.DestroyObject();
            Time.timeScale = 0;
            _canvas.gameObject.SetActive(true);
        }
    }
}
