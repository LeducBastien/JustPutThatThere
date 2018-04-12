using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [SerializeField] GameObject helpButtonInstance;
    [SerializeField] float timeBeforeHelp;
    private float timer = 0;
    public bool pustuleButtonActivated = false;
    public bool gameOver = false;
    public bool gatlingDoorOpen = false;
    public bool barFell = false;
    public bool roomButtonHere = false;
    public bool lollipopHere = false;
    public bool lollipopActivated = false;
    public bool armLeft = false;



    private void Awake()
    {
        if (Instance) return;
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        if (!helpButtonInstance) return;
        timer += Time.deltaTime;
        if (Input.anyKey)
            timer = 0;
        if (timer > timeBeforeHelp)
        {
            helpButtonInstance.SetActive(true);
            helpButtonInstance.GetComponent<Animator>().enabled = true;
        }
    }


	public void LoadTitleScreen () {
		SceneManager.LoadScene (0);
	}
	public void LoadOptions () {
		SceneManager.LoadScene (1);
	}
	public void LoadMainGame () {
		SceneManager.LoadScene (2);
	}

    public void Quit()
    {
        Application.Quit();

    }
}
