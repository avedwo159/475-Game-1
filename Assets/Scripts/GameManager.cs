using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{	
	// Place holders to allow connecting to other objects
	public Transform spawnPoint;
	public GameObject player;
	public GameObject blackHole;
	public GameObject text;
	public int streak;
	public GameObject Scoreboard;
	public bool checkDead = false;

	// Use this for initialization
	void Start ()
	{
		DeactivateText();
		Application.targetFrameRate = 300;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
	}


	//Runs when the player needs to be positioned back at the spawn point
	public void PositionPlayer()
	{
		//SceneManager.LoadScene("Main", LoadSceneMode.Single);
		player.transform.position = spawnPoint.position;
		blackHole.transform.localScale = new Vector3(0, 0, 0);

		checkDead = false;
	}


	// Runs when the player enters the finish zone
	public void FinishedGame()
	{
		ActivateText();
		PositionPlayer();
		streak++;
		blackHole.GetComponent<BlackHoleExpand>().growFactor += 0.25f;
		player.GetComponent<PlayerInput>().speedCap += 0.1f;
		player.GetComponent<PlayerInput>().speedMod += 0.1f;
		player.GetComponent<PlayerInput>().speedDrag += 0.1f;
		Invoke("DeactivateText", 10.0f);
	}

	public void Dead()
	{
		blackHole.GetComponent<BlackHoleExpand>().growFactor = 0.25f;
		player.GetComponent<PlayerInput>().speed = 0.0f;
		player.GetComponent<PlayerInput>().speedCap = 0.0f;
		player.GetComponent<PlayerInput>().speedMod = 0.0f;
		player.GetComponent<PlayerInput>().speedDrag = 0.0f;

		streak = 0;

		checkDead = true;

		PositionPlayer();
	}

	public int getFinish()
	{
		return streak;
	}

	public void ActivateText()
    {
		text.SetActive(true);
    }

	public void DeactivateText()
    {
		text.SetActive(false);
    }
	
	
}
