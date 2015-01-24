using UnityEngine;
using System.Collections;

public class PlayerWand : MonoBehaviour
{
    public int Player = 1; // The player this wand belongs to
    public Gestures GestureManager;

	void Start()
    {
	
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
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                }
            }
        }
	}
}