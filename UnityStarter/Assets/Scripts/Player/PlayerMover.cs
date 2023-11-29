using UnityEngine;

namespace Characters
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Transform currentTransform;
        [SerializeField] private float normalSpeed;
        [SerializeField] private float shiftSpeed;
        [SerializeField] private float jumpForce;

        private void Update()
        {
            if (currentTransform == null)
            {
                currentTransform = GetComponent<Transform>();
            }

            Vector3 movementValue = GetMovement() * GetSpeed();
            Move(movementValue);
        }

        private Vector3 GetMovement()
        {
            Vector3 currentMovement = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                currentMovement.z = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currentMovement.z = -1;
            }
            else
            {
                currentMovement.z = 0;
            }

            if (Input.GetKey(KeyCode.D))
            {
                currentMovement.x = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                currentMovement.x = -1;
            }
            else
            {
                currentMovement.x = 0;
            }

            currentMovement.y = GetJumpValue();

            return currentMovement;
        }

        private float GetJumpValue()
        {
            float jumpValue = 0;

            bool spaceIsPressed = Input.GetKey(KeyCode.Space);
            bool isOnGround = currentTransform.transform.position.y < 1.1f;

            if (spaceIsPressed && isOnGround)
            {
                jumpValue = jumpForce;
            }

            return jumpValue;
        }

        private float GetSpeed()
        {
            float speed = normalSpeed;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = shiftSpeed;
            }

            return speed;
        }

        private void Move(Vector3 direction)
        {
            transform.position = transform.position + transform.TransformDirection(direction);
        }
    }
}