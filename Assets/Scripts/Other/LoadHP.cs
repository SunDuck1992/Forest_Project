using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHP : MonoBehaviour
{
    private void Start()
    {
        LoadCharacteristics();
    }

    private void LoadCharacteristics()
    {
        Player player = FindObjectOfType<Player>();
        player.LoadGame();
    }
}
