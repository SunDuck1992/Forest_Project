using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            player.SaveHealth();
            SceneManager.LoadScene(_sceneName);
        }
    }
}
