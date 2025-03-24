using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTrigger : MonoBehaviour
{
    [SerializeField] string targetScene;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Main Menu");
            SceneManager.LoadScene(targetScene);
        }
    }
}
