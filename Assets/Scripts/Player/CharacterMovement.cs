using UnityEngine;
using System;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class CharacterMovement : MonoBehaviour
    {
        public float normalSpeed = 5f;
        public float JumpHeight = 2f;
        public float Gravity = -9.81f;
        public float dashSpeed = 5f;

        private CharacterController _controller;
        private Vector3 _velocity;
        private float distToGround;
        private float speedChange;

        public GameObject cam;
        public MouseLook mouseLook = new MouseLook();

        [Serializable]
        public class AdvancedSettings
        {
            public float groundCheckDistance = 0.01f; // distance for checking if the controller is grounded ( 0.01f seems to work best for this )
            [Tooltip("set it to 0.1 or more if you get stuck in wall")]
            public float shellOffset; //reduce the radius by that ratio to avoid getting stuck in wall (a value of 0.1f is nice)
        }

        public AdvancedSettings advancedSettings = new AdvancedSettings();

        void Start()
        {
            _controller = GetComponent<CharacterController>();
            mouseLook.Init(transform, cam.transform);
            distToGround = GetComponent<Collider>().bounds.extents.y;
            speedChange = normalSpeed;
        }

        void Update()
        {
            RotateView();

            if (!GameProgress.GetPaused())
            {
                if (IsGrounded() && _velocity.y < 0)
                {
                    _velocity.y = 0f;
                }

                Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                move = cam.transform.TransformDirection(move);
                move.y = 0.0f;

                _controller.Move(move * Time.unscaledDeltaTime * speedChange);

                if (Input.GetButtonDown("Jump") && IsGrounded())
                {
                    _velocity.y += Mathf.Sqrt(JumpHeight * -2f * Gravity);
                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    speedChange = dashSpeed;
                } else
                {
                    speedChange = normalSpeed;
                }

                _velocity.y += Gravity * Time.unscaledDeltaTime;

                _controller.Move(_velocity * Time.unscaledDeltaTime);
            }
        }

        private void RotateView()
        {
            //avoids the mouse looking if the game is effectively paused
            if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

            // get the rotation before it's changed
            float oldYRotation = transform.eulerAngles.y;

            mouseLook.LookRotation(transform, cam.transform);
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        }

        public void MoveCharacter(Vector3 newPos)
        {
            _controller.enabled = false;
            transform.position = newPos;
            _controller.enabled = true;
        }
    }
}
