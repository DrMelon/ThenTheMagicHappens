using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public HandController LeapController;

    void Update()
    {
        // Find all the tools in the scene
        ToolModel[] tools = GameObject.FindObjectsOfType<ToolModel>();
        if (tools.Length > 1) // Start game when two wands are in the scene
        {
            Application.LoadLevel("playfield");
        }
    }
}