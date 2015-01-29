using UnityEngine;
using System.Collections;
using Leap;

// Matthew Cormack
// @johnjoemcbob
// 24/01/15 00:05
// #GGJ15

// In collaboration with
// @DrMelon
// @_Inu_
// @MaxWrighton

public class Gestures : MonoBehaviour 
{
    public HandController LeapController;
    public ToolModel[] Player_Tool;
    public float[] Player_Tool_LastY;
    public bool[] Player_Cast;

    private static float CenterOffset = 0;

	void Start()
    {
        // TODO: Add error check/handle

        //LeapController.leap_controller_.EnableGesture( Gesture.GestureType.TYPE_CIRCLE );
        LeapController.leap_controller_.EnableGesture( Gesture.GestureType.TYPE_SWIPE );

        // Setup the config file for various gesture minimums
        LeapController.leap_controller_.Config.SetFloat("Gesture.Swipe.MinLength", 100.0f);
        LeapController.leap_controller_.Config.SetFloat("Gesture.Swipe.MinVelocity", 400);
        LeapController.leap_controller_.Config.Save();

        // Dimension the arrays
        Player_Tool = new ToolModel[2];
        Player_Tool_LastY = new float[2];
        Player_Cast = new bool[2];
	}

	void Update()
    {
        // Find all the tools in the scene
        ToolModel[] tools = GameObject.FindObjectsOfType<ToolModel>();
        foreach (ToolModel tool in tools)
        {
            // Find center x position of the wand (Tip position minus half length in wand direction)
            float wandcenteroffset = tool.GetLeapTool().TipPosition.z - (tool.GetLeapTool().Direction.z * tool.GetLeapTool().Length / 2);

            // Decide which player's wand this is
            int player = 0;
            if (wandcenteroffset > CenterOffset) // Player 2 (array 1)
            {
                player = 1;
            }
            Player_Tool[player] = tool;
            {
                float difference = tool.GetLeapTool().TipPosition.y - Player_Tool_LastY[player];
                if (difference < -20)
                {
                    //print(difference);
                    Player_Cast[player] = true;
                }
            }
            Player_Tool_LastY[player] = tool.GetLeapTool().TipPosition.y;
        }

        // Ensure the editor has LeapController set
        if (LeapController)
        {
            // Get the actual Leap controller, with useful data
            Controller controller = LeapController.leap_controller_;
            if (controller.IsConnected)
            {
                // Get the status of the Leap Motion this frame
                Frame frame = controller.Frame();
                if (frame.IsValid)
                {
                    // Find any gestures in this frame
                    GestureList gestures = frame.Gestures();
                    foreach (Gesture gesture in gestures)
                    {
                        // Gesture exists
                        if (gesture.IsValid)
                        {
                            // Gesture type recognition
                            if (gesture.Type == Gesture.GestureType.TYPE_CIRCLE) // Circle
                            {
                                CircleGesture circlegesture = new CircleGesture(gesture);
                            }
                            else if (gesture.Type == Gesture.GestureType.TYPE_SWIPE) // Swipe, line
                            {
                                SwipeGesture swipegesture = new SwipeGesture(gesture);
                                if (Mathf.Abs(swipegesture.Direction.y) > 0.3f) // Moving up and down
                                {
                                    if (Mathf.Abs(swipegesture.Direction.x) < 0.8f) // Not moving much left and right
                                    {
                                        // TODO: Add error handle/checks
                                        float wandcenteroffset = swipegesture.StartPosition.z;
                                        if (wandcenteroffset < CenterOffset)
                                        {
                                            //Player_Cast[0] = true;
                                        }
                                        else if (wandcenteroffset > CenterOffset)
                                        {
                                            //Player_Cast[1] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

// Structure to hold;
//  (Leap.Vector) The position of the tool at this point in time
//  (Time) The time at which the tool's position was stored
public class LeapToolFrame
{
    Leap.Vector Position;
    float Time;
}