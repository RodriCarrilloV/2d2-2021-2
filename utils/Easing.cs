using UnityEngine;

public class Easing
{
  // no hace ningún cambio
  public static float Linear(float t)
  {
    return t;
  }

  // acelerar
  // .. .  .   .    .     .       .
  public static float EaseIn(float t)
  {
    return Mathf.Pow(t, 3);
  }

  // descacelerar
  // .      .     .    .   .  . ..
  public static float EaseOut(float t)
  {
    return 1 - Mathf.Pow(1 - t, 3);
  }

  // acelerar/desacelerar
  // .. .  .   .    .   .  . ..
  public static float EaseInOut(float t)
  {
    return t < 0.5f ? 4 * Mathf.Pow(t, 3) : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
  }

  // anticipación del movimiento
  public static float EaseInBack(float t)
  {
    return 2.70158f * Mathf.Pow(t, 3) - 1.70158f * Mathf.Pow(t, 2);
  }

  // continúa el movimiento
  public static float EaseOutBack(float t)
  {
    return 1 + 2.70158f * Mathf.Pow(t - 1, 3) + 1.70158f * Mathf.Pow(t - 1, 2);
  }

  // se mueve como un resorte
  public static float Elastic(float t)
  {
    if (t == 0) return 0;
    if (t == 1) return 1;
    return Mathf.Pow(2, -10 * t) * Mathf.Sin((10 * t - 0.75f) * 0.666666f * Mathf.PI) + 1;
  }

  // va hacia el punto final y retorna al punto inicial
  public static float Parabolic(float t)
  {
    return 4 * t - 4 * t * t;
  }

  // saltar
  public static float Bounce(float t)
  {
    float n1 = 7.5625f;
    float d1 = 2.75f;

    if (t < 1 / d1)
    {
      return n1 * t * t;
    }
    else if (t < 2 / d1)
    {
      return n1 * (t -= 1.5f / d1) * t + 0.75f;
    }
    else if (t < 2.5 / d1)
    {
      return n1 * (t -= 2.25f / d1) * t + 0.9375f;
    }
    else
    {
      return n1 * (t -= 2.625f / d1) * t + 0.984375f;
    }
  }
}
