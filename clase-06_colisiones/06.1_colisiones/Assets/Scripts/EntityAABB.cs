using UnityEngine;

public class EntityAABB : MonoBehaviour
{
  public float width;
  public float height;
  public float top;
  public float bottom;
  public float left;
  public float right;

  public void CalculateBounds()
  {
    top = transform.position.y + height / 2;
    bottom = transform.position.y - height / 2;
    left = transform.position.x - width / 2;
    right = transform.position.x + width / 2;
  }

  public bool CollideWith(EntityAABB entity)
  {
    return !(bottom > entity.top || top < entity.bottom || left > entity.right || right < entity.left);
  }
}