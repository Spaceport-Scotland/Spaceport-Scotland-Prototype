// provides events that item reactions can respond to
using UnityEngine;

public abstract class ItemReactionEffect : MonoBehaviour
{
    // called when the controller detects that the item is picked up
    public abstract void OnPickedUp();

    // called when the controller detects that the item is released
    public abstract void OnReleased();

    // called when the item collides with another object
    public virtual void OnCollided(Collision collision)
    {
    }
}
