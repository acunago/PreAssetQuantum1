using Invector.vCharacterController;
using System;
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
    public GameObject Gameover;
    public GameObject vinctoria;

    public GameObject gameOverBtns;
    public Camera camPrinc;
    public Camera camDerrota;

    public GameObject playerPrefab;

    public GameObject checkpoint;

    public GameObject Calavera;

    private void Update()
    {
        Teleport();
    }


    public void GameOver()
    {
        Calavera.GetComponent<ActionsController>().DeathChar();
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
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (respawn.Length >= 4)
            {
                if (respawn[3] != null)
                {
                    Player.transform.position = respawn[3].transform.position;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            RestCheck();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Level1-TheCave");

        }


    }
    public void ExectImage()
    {

        Destroy(Player.gameObject);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Gameover.gameObject.SetActive(true);
        ActiveGame(true);
        //Invoke("Menu", 2);
    }
    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void victoria()
    {
        //Gameover.gameObject.SetActive(true);
        Invoke("ChangeVictory", 2);
    }

    public void ChangeVictory()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void RestCheck()
    {
        ActiveGame(false);

        Player = Instantiate(playerPrefab, checkpoint.transform.position, checkpoint.transform.rotation);
        Player.gameObject.GetComponent<vThirdPersonController>().onDead.AddListener(GameOver);
        Calavera.GetComponent<ActionsController>().PosTotal = Player.transform.Find("SkullPos").gameObject;
        AudioManager.instance.sourceHolder = Player.transform.Find("collisionAudio").gameObject;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void GameOver(GameObject arg0)
    {
        Debug.Log("muerto");
        Invoke("ExectImage", 3);
    }

    public void ActiveGame(bool status)
    {
        PauseMenu.GameIsPaused = status;
        gameOverBtns.SetActive(status);
        camPrinc.gameObject.SetActive(!status);
        camDerrota.gameObject.SetActive(status);
    }

}
