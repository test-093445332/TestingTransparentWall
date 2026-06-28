using UnityEngine;


namespace Scripts.Camera
{
    [DisallowMultipleComponent, RequireComponent(typeof(CameraInput))]
    public class CameraConroller : MonoBehaviour
    {
        [Header("Option")]
        [SerializeField] private float cameraSpeed;

        private CameraInput _cameraInput;


        private void Awake()
        {
            _cameraInput = GetComponent<CameraInput>();
        }

        private void Update()
        {
            Movment();
        }

        private void Movment()
        {
            Vector2 directionVectros = _cameraInput.MoveVector;


            Vector3 move =
                (transform.right * directionVectros.x +
                 transform.forward * directionVectros.y);

            transform.position += move * cameraSpeed * Time.deltaTime;
        }

        
    }
}

