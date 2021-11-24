using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  enum PlayerState { IDLE, PLAYING, PAUSE };
  PlayerState state;

  [SerializeField]
  int playerIndex;
  bool isJumping = false;
  float x;
  float y;

  // lerp de salto
  const float JUMP_HIGH = 1.3f;
  float tJump = 0;
  float speedJump = 2;

  // movimiento circular
  const float MAX_RADIUS = 2.4f;
  float radius = MAX_RADIUS;
  float angle = 0;
  float speed = 1;


  // estado PAUSE
  Vector3 startPauseSize = new Vector3(1, 1, 1);
  Vector3 endPauseSize = new Vector3(1.4f, 1.4f, 1.4f);
  float tPause = 0;
  float speedPause = 2;

  void Start()
  {
    // inicialización de variables
    state = Global.currentPlayer == playerIndex ? PlayerState.PLAYING : PlayerState.IDLE;
    angle = Global.currentPlayer == playerIndex ? 0 : Mathf.PI;
  }

  void Update()
  {
    switch (state)
    {
      case PlayerState.IDLE:
        StateIdle();
        break;
      case PlayerState.PLAYING:
        StatePlaying();
        break;
      case PlayerState.PAUSE:
        StatePause();
        break;
    }
  }

  void StateIdle()
  {
    /** ACCIÓN **/
    CalculateCartesianCoordinates();
    CalculateJump();
    Locate();

    /** CONDICIÓN DE SALIDA 1 **/
    if (Input.GetKeyDown(KeyCode.Z))
    {
      Global.currentPlayer = playerIndex == 1 ? 2 : 1;
      state = PlayerState.PLAYING;
    }

    /** CONDICIÓN DE SALIDA 2 **/
    if (Input.GetKeyDown(KeyCode.P))
    {
      state = PlayerState.PAUSE;
    }
  }

  void StatePlaying()
  {
    /** ACCIÓN **/
    DetectInputs();
    CalculateCartesianCoordinates();
    CalculateJump();
    Locate();

    /** CONDICIÓN DE SALIDA 1 **/
    if (Input.GetKeyDown(KeyCode.Z))
    {
      Global.currentPlayer = playerIndex == 1 ? 2 : 1;
      state = PlayerState.IDLE;
    }

    /** CONDICIÓN DE SALIDA 2 **/
    if (Input.GetKeyDown(KeyCode.P))
    {
      state = PlayerState.PAUSE;
    }
  }

  void StatePause()
  {
    /** ACCIÓN **/
    CalculateCartesianCoordinates();
    Locate();

    // cálculo de animación
    transform.localScale = Vector3.Lerp(startPauseSize, endPauseSize, Easing.Linear(tPause));
    tPause += Time.deltaTime * speedPause;

    if (tPause >= 1)
    {
      tPause = 1;
      speedPause = -speedPause;
    }

    if (tPause <= 0)
    {
      tPause = 0;
      speedPause = -speedPause;
    }

    /** CONDICIÓN DE SALIDA 1 **/
    if (Input.GetKeyDown(KeyCode.P))
    {
      state = Global.currentPlayer == playerIndex ? PlayerState.PLAYING : PlayerState.IDLE;
    }
  }

  void DetectInputs()
  {
    angle -= Input.GetAxis("Horizontal") * Time.deltaTime * speed;

    // si se presiona UP, se activa el salto
    if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !isJumping)
    {
      isJumping = true;
    }
  }

  void CalculateJump()
  {
    // si el salto está activo
    if (isJumping)
    {
      // se calcula el radio con un lerp
      radius = Mathf.Lerp(MAX_RADIUS, MAX_RADIUS + JUMP_HIGH, Easing.Parabolic(tJump));
      // se incrementa el tiempo de salto
      tJump += Time.deltaTime * speedJump;

      // si termina la animación
      if (tJump >= 1)
      {
        isJumping = false;
        tJump = 0;
      }
    }
    // de lo contrario, se mantiene en el piso
    else
    {
      radius = MAX_RADIUS;
    }
  }

  void CalculateCartesianCoordinates()
  {
    // se transforma la coordenada polar en cartesiana
    x = radius * Mathf.Cos(angle) + 0;
    y = radius * Mathf.Sin(angle) + 0;
  }

  void Locate()
  {
    // se actualiza la rotación del player
    Vector3 up = transform.position - Vector3.zero;

    // se actualiza la posición del jugador
    transform.position = new Vector3(x, y, 0);
    transform.up = up;
  }

  public void SetStateToPaused()
  {
    state = PlayerState.PAUSE;
  }

  public void SetStateToGameplay()
  {
    state = Global.currentPlayer == playerIndex ? PlayerState.PLAYING : PlayerState.IDLE;
  }
}
