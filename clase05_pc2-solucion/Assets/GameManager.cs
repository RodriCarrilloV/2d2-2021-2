using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static bool isPlayer1Playing;

  void Start()
  {
    isPlayer1Playing = true;
  }

  void Update()
  {
    if (isPlayer1Playing)
    {
      GameObject.Find("Player1").GetComponent<Player1>().isActive = true;
      GameObject.Find("Player2").GetComponent<Player2>().isActive = false;
    }
    else
    {
      GameObject.Find("Player1").GetComponent<Player1>().isActive = false;
      GameObject.Find("Player2").GetComponent<Player2>().isActive = true;
    }
  }

  public void ActivateTurnPlayer1()
  {
    GameManager.isPlayer1Playing = true;
    GameObject.Find("Player1").GetComponent<Player1>().canShoot = true;
  }

  public void ActivateTurnPlayer2()
  {
    GameManager.isPlayer1Playing = false;
    GameObject.Find("Player2").GetComponent<Player2>().canShoot = true;
  }
}
