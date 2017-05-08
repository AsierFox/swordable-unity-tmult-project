using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseState : MonoBehaviour {

    private bool paused;

    public GameObject pauseCanvas;

	void Start ()
    {
        paused = false;
        pauseCanvas.SetActive(paused);
	}
	
	void Update ()
    {
		if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        pauseCanvas.SetActive(paused);

        Time.timeScale = paused ? 0 : 1;
	}

    public void Resume()
    {
        paused = false;
    }

    public void Pause()
    {
        paused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
