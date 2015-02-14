using UnityEngine;
using System.Collections;

// Matthew Cormack
// @johnjoemcbob
// 24/01/15 00:05
// #GGJ15

// In collaboration with
// @DrMelon
// @_Inu_
// @MaxWrighton

public class PlayerWand : MonoBehaviour
{
    public int Player = 1; // The player this wand belongs to
    public Gestures GestureManager;
    public ParticleSystem DefaultSpell;

    public GameObject Spell_Fire; // Prefab for spell

    private SpriteRenderer sprite;

	void Start()
    {
        // Initialize reference to the sprite component
        sprite = GetComponent<SpriteRenderer>();

        // Convert player to array position
        Player--;
	}

	void Update()
    {
        // Ensure GestureManager has been set in the editor
	    if (GestureManager)
        {
            // Player is in the right boundaries
            if ((Player == 0) || (Player == 1))
            {
                // Update the orientation of player wands using tool position
                bool HasTool = false;
                // Player has a tool
                if (GestureManager.Player_Tool[Player])
                {
                    // Player's tool is still valid (may be removed from scene, etc)
                    if (GestureManager.Player_Tool[Player].GetLeapTool().IsValid)
                    {
                        HasTool = true;

                        // Orientate the wand OFFSET (parent) depending on the Leap tool (z is rotation)
                        Leap.Vector direction = GestureManager.Player_Tool[Player].GetLeapTool().Direction;
                        if (Player == 0) // Left hand player
                        {
                            if (direction.z > 0) // Direction z should always be positive for aiming wand
                            {
                                direction *= -1; // If not, correct it
                            }
                        }
                        else if (Player == 1) // Right hand player
                        {
                            if (direction.z > 0) // Direction z should always be negative for aiming wand
                            {
                                direction *= -1; // If not, correct it
                            }
                        }
                        float angle = direction.x * 45; // Work out the angle to offset the wand
                        {
                            if (Player == 1) // Player two's offset needs to be the inverse
                            {
                                angle *= -1;
                            }
                        }
                        transform.parent.localEulerAngles = new Vector3(0, 0, angle);
                    }
                    else
                    {
                        HasTool = false; // Tool isn't valid
                    }
                }
                else
                {
                    HasTool = false; // Tool isn't set
                }
                if (HasTool)
                {
                    sprite.color = new Color(255, 255, 255, 255); // Show wand
                }
                else
                {
                    sprite.color = new Color(0, 0, 0, 100); // Hide wand
                }

                // Run logic when this player's wand is shaken
                // Player wand has been shaken
                if (GestureManager.Player_Cast[Player])
                {
                    // Play default particles
                    // Default Spell has been set in the editor
                    if (DefaultSpell)
                    {
                        DefaultSpell.Stop();
                        DefaultSpell.Play();
                    }

                    // Create spell
                    //if (Spell_Fire)
                    //{
                    //    Instantiate(Spell_Fire, transform.GetChild(0).localPosition, Quaternion.Euler(transform.GetChild(0).eulerAngles)); // Child 0 is the tip
                    //}

                    // Flag casting as handled
                    //GestureManager.Player_Cast[Player] = false;
                }
            }
        }
	}
}