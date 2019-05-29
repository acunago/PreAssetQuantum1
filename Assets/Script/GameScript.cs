using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] respawn;
    public GameObject Player;
    public Image Gameover;

    private void Update()
    {
        Teleport();
    }


    public void GameOver()
    {
        Debug.Log("muerto");
        Invoke("ExectImage", 3);
    }
    public void Teleport()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (respawn.Length >= 1)
            {
                Player.transform.position = respawn[0].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (respawn.Length >= 2)
            {
                Player.transform.position = respawn[1].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (respawn.Length >= 3)
            {
                Player.transform.position = respawn[2].transform.position;
            }
        }
        if (respawn.Length >= 4)
        {
            if (respawn[3] != null)
            {
                Player.transform.position = respawn[3].transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1-TheCave");

        }
    }
    public void ExectImage()
    {
        Debug.Log("raro");
        Gameover.gameObject.SetActive(true);
    }
}
