using UnityEngine;
using System.Collections;
using Leap;

public class Gestures : MonoBehaviour 
{
    public HandController LeapController;
    public ToolModel[] Player_Tool;

    private static float CenterX = 0;

	void Start()
    {
        //LeapController.leap_controller_.EnableGesture( Gesture.GestureType.TYPE_CIRCLE );
        LeapController.leap_controller_.EnableGesture( Gesture.GestureType.TYPE_SWIPE );

        Player_Tool = new ToolModel[2];
	}

	void Update()
    {
        // Find any gestures in this frame
        GestureList gestures = LeapController.leap_controller_.Frame().Gestures();
        foreach ( Gesture gesture in gestures )
        {
            // Gesture exists
            if ( gesture.IsValid )
            {
                // Gesture type recognition
                if ( gesture.Type == Gesture.GestureType.TYPE_CIRCLE ) // Circle
                {
                    CircleGesture circlegesture = new CircleGesture( gesture );
                }
                else if ( gesture.Type == Gesture.GestureType.TYPE_SWIPE ) // Swipe, line
                {
                    SwipeGesture swipegesture = new SwipeGesture( gesture );
                    if ( Mathf.Abs( swipegesture.Direction.y ) > 0.5f ) // Moving up and down
                    {
                        if ( Mathf.Abs( swipegesture.Direction.z ) < 0.8f ) // Not moving much left and right
                        {
                            
                        }
                    }
                }
            }
        }

        // Find all the tools in the scene
        ToolModel[] tools = GameObject.FindObjectsOfType<ToolModel>();
        foreach ( ToolModel tool in tools )
        {
            // TODO: Crossproduct for direction of tool??
            // Find center x position of the wand (Tip position minus half length in wand direction)
            float wandcenterx = tool.GetLeapTool().TipPosition.x - ( tool.GetLeapTool().Direction.x * tool.GetLeapTool().Length / 2 );
            if ( wandcenterx < CenterX ) // Player 1 (array 0)
            {
                Player_Tool[0] = tool;
                print(Player_Tool[0].GetLeapTool().Length);
            }
            else if ( wandcenterx > CenterX ) // Player 2 (array 1)
            {
                Player_Tool[1] = tool;
            }
        }
	}
}
