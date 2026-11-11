// watches dragging and collisions, then notifies the item's reaction effects
using UnityEngine;

public class ItemReactionController : MonoBehaviour
{
    // stores the script that tells us whether the item is being dragged
    private InteractionWithPhysics interactionWithPhysics;

    // stores the reaction effects attached to this item
    private ItemReactionEffect[] reactionEffects;

    // remembers the previous frame's state so effects only run when dragging starts or stops
    private bool wasBeingDragged;

    private void Awake()
    {
        // find the needed scripts on this item
        interactionWithPhysics = GetComponent<InteractionWithPhysics>();
        reactionEffects = GetComponents<ItemReactionEffect>();

        if (interactionWithPhysics == null)
        {
            Debug.LogError("InteractionWithPhysics is missing from this item.");
        }
    }

    private void Update()
    {
        // stop if this item does not have the dragging script
        if (interactionWithPhysics == null)
        {
            return;
        }

        bool isBeingDragged = interactionWithPhysics.dragging;

        // run pickup effects once when dragging changes from false to true
        if (isBeingDragged && !wasBeingDragged)
        {
            foreach (ItemReactionEffect reactionEffect in reactionEffects)
            {
                reactionEffect.OnPickedUp();
            }
        }
        // run release effects once when dragging changes from true to false
        else if (!isBeingDragged && wasBeingDragged)
        {
            foreach (ItemReactionEffect reactionEffect in reactionEffects)
            {
                reactionEffect.OnReleased();
            }
        }

        wasBeingDragged = isBeingDragged;
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ItemReactionEffect reactionEffect in reactionEffects)
        {
            reactionEffect.OnCollided(collision);
        }
    }
}
