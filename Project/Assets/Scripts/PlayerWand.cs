using UnityEngine;
using System.Collections;

// Matthew Cormack
// 24/01/15 00:05
// #GGJ15

public class PlayerWand : MonoBehaviour
{
    public int Player = 1; // The player this wand belongs to
    public Gestures GestureManager;

    private SpriteRenderer sprite;

	void Start()
    {
        // Initialize reference to the sprite component
        sprite = GetComponent<SpriteRenderer>();
	}

	void Update()
    {
        // Ensure GestureManager has been set in the editor
	    if (GestureManager)
        {
            // Player is in the right boundaries
            if ((Player >= 1) && (Player <= 2))
            {
                bool HasTool = false;
                // Player has a tool
                if (GestureManager.Player_Tool[Player-1])
                {
                    // Player's tool is still valid (may be removed from scene, etc)
                    if (GestureManager.Player_Tool[Player-1].GetLeapTool().IsValid)
                    {
                        HasTool = true;

                        // Orientate the wand OFFSET (parent) depending on the Leap tool (z is rotation)
                        Leap.Vector direction = GestureManager.Player_Tool[Player - 1].GetLeapTool().Direction;
                        float angle = -direction.z * 45; // Work out the angle to offset the wand
                        {
                            if (Player == 2) // Player two's offset needs to be the inverse
                            {
                                angle *= -1;
                            }
                        }
                        transform.parent.localEulerAngles = new Vector3(0, 0, angle);
                    }
                    else
                    {
                        HasTool = false;
                    }
                }
                else
                {
                    HasTool = false;
                }
                if (HasTool)
                {
                    sprite.color = new Color(255, 255, 255, 255); // Show wand
                }
                else
                {
                    sprite.color = new Color(255, 255, 255, 0); // Hide wand
                }
            }
        }
	}
}