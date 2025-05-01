using UnityEngine;

namespace weaponSystem
{
    public class WeaponMoveSwayBob : MonoBehaviour
    {
        [Header("Sway Parameters")]
        [SerializeField] private float swaySpeed;
        [SerializeField] private float swaySmooth;

        [Header("Bob Parameters")]
        [SerializeField] private float bobFrequency;
        [SerializeField] private float bobHorizontalAmplitude;
        [SerializeField] private float bobVerticalAmplitude;

        [Header("References")]
        [SerializeField] private Camera playerCamera;

        private float bobTimer;

        private Vector3 initialPosition;

        private Vector2 currentRotation;
        private Vector2 targetRotation;

        private void Start()
        {
            initialPosition = transform.localPosition;
        }

        private void Update()
        {
            WeaponSway();
            WeaponBob();
        }

        private void WeaponSway()
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * swaySpeed;

            Quaternion xRotation = Quaternion.AngleAxis(-direction.y, Vector3.right);
            Quaternion yRotation = Quaternion.AngleAxis(direction.x, Vector3.up);

            Quaternion targetRotation = xRotation * yRotation;

            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, swaySmooth * Time.deltaTime);
        }

        private void WeaponBob()
        {
            Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (movementInput.magnitude > 0)
            {
                bobTimer += Time.deltaTime;

                float waveSlice = Mathf.Sin(bobTimer * bobFrequency * Mathf.PI * 2f);
                float horizontalOffset = Mathf.Cos(bobTimer * bobFrequency * Mathf.PI * 2f) * bobHorizontalAmplitude;
                float verticalOffset = Mathf.Abs(Mathf.Sin(waveSlice)) * bobVerticalAmplitude;

                transform.localPosition = initialPosition + new Vector3(horizontalOffset, verticalOffset, 0);
            }
            else
            {
                bobTimer = 0;
                transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime * 5f);
            }
        }
    }
}