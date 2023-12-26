using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Restart : MonoBehaviour
{

	public TextMeshProUGUI scoreDisplay;
	private Player player;

	private void Start()
	{
		player = FindObjectOfType<Player>();
	}

	private void Update()
	{

		scoreDisplay.text = player.score.ToString();

		if(Input.GetKeyDown(KeyCode.R)){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
	}
}
