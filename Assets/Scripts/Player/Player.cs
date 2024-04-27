using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Player : MonoBehaviour
    {

        private Rigidbody2D _RigidBody;
        private float Horizontal;
        private bool IsGrounded;
        public PlayerMovement PlayerMovement { get; set; }
        public bool IsSendingSignal { get; set; }

        [SerializeField]
        private float Speed = 5;


        void Start()
        {
            _RigidBody = GetComponent<Rigidbody2D>();
            PlayerMovement = new PlayerMovement();
        }

        void Update()
        {
            Debug.DrawRay(transform.position, Vector3.down * 0.15f, Color.red);
            float vertical = Input.GetAxisRaw("Vertical2");
            IsGrounded = PlayerMovement.IsNotJumping(transform);

            Move();
            IsSendingSignal = PlayerMovement.IsActionChangeColorKeyDown();
        }

        private void Move()
        {
            bool horizontalKeyDown = PlayerMovement.isHorizontalKeyDown("Horizontal2");
            Horizontal = PlayerMovement.HorizontalMovement(horizontalKeyDown, "Horizontal2");
            PlayerMovement.Jump(_RigidBody, IsGrounded, "Jump");
        }

        private void FixedUpdate()
        {
            _RigidBody.velocity = new Vector2(Horizontal, _RigidBody.velocity.y);
        }
    }
}