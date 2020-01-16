using UnityEngine;
using System.Collections;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Valve.VR.InteractionSystem.Sample
{
    public class BallController : MonoBehaviour
    {
        // Used to animate the joystick when moved
        public Transform Joystick;

        // Refers to vive's touchpad or oculus's joystick
        public SteamVR_Action_Vector2 moveAction = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");
        // Refers to a click event on touchpad / joystick
        public SteamVR_Action_Boolean jumpAction = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("platformer", "Jump");


        // Multiplier for ball movement
        public float forceMult = 2.0f;

        // Vertical force to add for jumping
        public float upMult = 250.0f;

        // Modified multiplier since original scene was a different scale
        public float joyMove = 0.01f;

        // Interactable script of the GameObject
        private Interactable interactable;

        // Game ball's Rigidbody
        private Rigidbody ballRb;

        private void Start()
        {
            // Get Interactable script on this GameObject (the controller)
            interactable = GetComponent<Interactable>();

            // Get ball's Rigidbody so we can add force to it
            ballRb = GameObject.Find("/Ball").GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 movement = Vector2.zero;
            bool jump = false;

            // If controller is attached to hand
            if (interactable.attachedToHand)
            {
                // Get hand type (L / R) so that the controller can be used in either hand
                SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

                // Get the touchpad/joystick x/y coordinates of that particular hand
                Vector2 m = moveAction[hand].axis;
                movement = new Vector3(m.x, 0, m.y);

                // If someone has "clicked" the touchpad/joystick, then they jump.
                jump = jumpAction[hand].stateDown;
            }

            Joystick.localPosition = movement * joyMove;

            //Movement of ball done relative to controller.
            //To do this, we get the angle with respect to the y-axis (vertical in world space)
            float rot = transform.eulerAngles.y;
            movement = Quaternion.AngleAxis(rot, Vector3.up) * movement;

            if (jump)
            {
                // Allows infinite combined jumps
                ballRb.AddForce(new Vector3(0, this.upMult, 0));
            }
            ballRb.AddForce(movement * this.forceMult);
        }
    }
}