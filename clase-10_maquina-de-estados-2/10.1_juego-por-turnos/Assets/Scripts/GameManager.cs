using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  enum GameState { PAUSE, GAMEPLAY, COUNTDOWN };
  GameState state = GameState.COUNTDOWN;

  // estado COUNTDOWN
  float timerCountdown = 0;
  
  void Update()
  {
    switch (state)
    {
      case GameState.PAUSE:
        /** ACCIÓN **/
        StatePause();

        /** CONDICIÓN DE SALIDA 1 **/
        if (Input.GetKeyDown(KeyCode.P))
        {
          state = GameState.GAMEPLAY;
        }
        break;
      case GameState.GAMEPLAY:
        /** ACCIÓN **/
        StateGameplay();

        /** CONDICIÓN DE SALIDA 1 **/
        if (Input.GetKeyDown(KeyCode.P))
        {
          state = GameState.PAUSE;
        }
        break;

      case GameState.COUNTDOWN:
        /** ACCIÓN **/
        StateCountdown();

        /** CONDICIÓN DE SALIDA 1 **/
        break;
    }
  }

  void StatePause()
  {
    GameObject.Find("PausedScreen").transform.localScale = Vector3.one;
    GameObject.Find("CountdownScreen").transform.localScale = Vector3.zero;
  }

  void StateGameplay()
  {
    GameObject.Find("PausedScreen").transform.localScale = Vector3.zero;
    GameObject.Find("CountdownScreen").transform.localScale = Vector3.zero;
    if (GameObject.Find("Canvas")) GameObject.Find("Canvas").SetActive(false);

    GameObject.Find("Player1").GetComponent<PlayerController>().SetStateToGameplay();
    GameObject.Find("Player2").GetComponent<PlayerController>().SetStateToGameplay();
  }

  void StateCountdown()
  {
    /** ACCIÓN **/
    timerCountdown += Time.deltaTime;

    int timerInt = Mathf.FloorToInt(timerCountdown);

    if (timerInt == 0) GameObject.Find("CountDownText").GetComponent<Text>().text = "3";
    if (timerInt == 1) GameObject.Find("CountDownText").GetComponent<Text>().text = "2";
    if (timerInt == 2) GameObject.Find("CountDownText").GetComponent<Text>().text = "1";
    if (timerInt == 3) GameObject.Find("CountDownText").GetComponent<Text>().text = "GO!";

    if (timerCountdown > 4)
    {
      state = GameState.GAMEPLAY;
    }

    GameObject.Find("Player1").GetComponent<PlayerController>().SetStateToPaused();
    GameObject.Find("Player2").GetComponent<PlayerController>().SetStateToPaused();

    GameObject.Find("PausedScreen").transform.localScale = Vector3.zero;
    GameObject.Find("CountdownScreen").transform.localScale = Vector3.one;
  }
}
