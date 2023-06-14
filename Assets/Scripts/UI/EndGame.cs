using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _canvas.gameObject.SetActive(true);
            DontDestroy obj = FindObjectOfType<Sound>().GetComponent<DontDestroy>();
            obj.DestroyObject();
            Time.timeScale = 0;
        }
    }
}
