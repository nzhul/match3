using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

	public int movesLeft = 30;
	public int scoreGoal = 10000;
	public ScreenFader screenFader;
	public Text levelNameText;
	public Text movesLeftText;

	Board m_board;
	bool m_isReadyToBegin = false;
	bool m_isGameOver = false;
	bool m_isWinner = false;

	private void Start()
	{
		m_board = GameObject.FindObjectOfType<Board>().GetComponent<Board>();

		Scene scene = SceneManager.GetActiveScene();
		if (levelNameText != null)
		{
			levelNameText.text = scene.name;
		}

		UpdateMoves();
		StartCoroutine("ExecuteGameLoop");
	}

	public void UpdateMoves()
	{
		if (movesLeftText != null)
		{
			movesLeftText.text = movesLeft.ToString();
		}
	}

	IEnumerator ExecuteGameLoop()
	{
		yield return StartCoroutine("StartGameRoutine");
		yield return StartCoroutine("PlayGameRoutine");
		yield return StartCoroutine("EndGameRoutine");
	}

	IEnumerator StartGameRoutine()
	{
		while (!m_isReadyToBegin)
		{
			yield return null;
			//yield return new WaitForSeconds(2);
			m_isReadyToBegin = true;
		}

		if (screenFader != null)
		{
			screenFader.FadeOff();
		}

		//yield return new WaitForSeconds(0.5f);

		if (m_board != null)
		{
			m_board.SetupBoard();
		}
	}

	IEnumerator PlayGameRoutine()
	{
		while(!m_isGameOver)
		{
			if (movesLeft == 0)
			{
				m_isGameOver = true;
				m_isWinner = false;
			}

			yield return null;
		}
	}

	IEnumerator EndGameRoutine()
	{
		if (screenFader != null)
		{
			screenFader.FadeOn();
		}

		if (m_isWinner)
		{
			Debug.Log("YOU WIN!");
		}
		else
		{
			Debug.Log("YOU LOSE!");
		}

		yield return null;
	}


}
