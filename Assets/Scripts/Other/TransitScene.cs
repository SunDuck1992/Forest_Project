using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Player>()/*gameObject.tag == "Player"*/)
        {
            Player player = FindObjectOfType<Player>();
            player.SaveHealth();
            SceneManager.LoadScene(_sceneName);
        }
    }
}
