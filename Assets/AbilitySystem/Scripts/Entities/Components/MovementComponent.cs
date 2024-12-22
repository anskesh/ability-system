using UnityEngine;

namespace AbilitySystem.Scripts.Entities
{
    public abstract class MovementComponent
    {
        protected float _moveSpeed => _entityAttributes.Speed;
        protected float _rotationSpeed => _entityAttributes.RotationSpeed;
        protected CharacterController _characterController;
        protected Vector3 _moveDirection;

        private bool _canMove = true;
        private EntityAttributes _entityAttributes;
        private Transform _transform;

        public MovementComponent(Transform transform, EntityAttributes entityAttributes)
        {
            _entityAttributes = entityAttributes;
            _transform = transform;
            
            _characterController = _transform.GetComponent<CharacterController>();
        }

        public void SetCanMove(bool canMove)
        {
            _canMove = canMove;
            _moveDirection = Vector3.zero;
        }

        public void TeleportTo(Vector3 direction)
        {
            _moveDirection = Vector3.zero;
            SetCanMove(false);
            Vector3 newPos = _transform.forward * direction.magnitude;
            newPos.y = 0;
            _characterController.Move(newPos);
            SetCanMove(true);
        }

        public void Update()
        {
            if (_canMove)
                HandleMovement();
            
            MovementMethod();
        }

        protected abstract void HandleMovement();

        protected void MovementMethod()
        {
            if (_moveDirection == Vector3.zero)
                return;
            
            _characterController.Move(_moveDirection.normalized * _moveSpeed * Time.deltaTime);

            if (_moveDirection.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(_moveDirection);
                _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }

            _moveDirection = Vector3.zero;
        }
    }
}