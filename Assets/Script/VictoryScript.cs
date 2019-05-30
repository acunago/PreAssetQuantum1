
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    public GameObject vinctoria;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Invoke("Victoria", 2);
    }
    public void Menu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        vinctoria.gameObject.SetActive(true);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
    public void Victoria()
    {
        vinctoria.gameObject.SetActive(true);
        Invoke("Menu", 2);
    }
}
