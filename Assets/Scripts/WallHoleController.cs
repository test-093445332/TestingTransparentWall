using UnityEngine;

public class WallHoleController : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float sphereRadius = 0.3f;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float holeRadius = 0.5f;
    [SerializeField] private LayerMask wallMask;

    private static readonly int HolePosition = Shader.PropertyToID("_HolePosition");
    private static readonly int HoleRadius = Shader.PropertyToID("_HoleRadius");
    private void Update()
    {
        RaycastHit hit;

        if (Physics.SphereCast(
                playerCamera.transform.position,
                sphereRadius,
                playerCamera.transform.forward,
                out hit,
                maxDistance,
                wallMask))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();

            Debug.Log("Hit");

            if (renderer != null)
            {
                MaterialPropertyBlock block = new MaterialPropertyBlock();

                renderer.GetPropertyBlock(block);

                block.SetVector(HolePosition, hit.point);
                block.SetFloat(HoleRadius, holeRadius);

                renderer.SetPropertyBlock(block);
            }
        }
    }
}

//using UnityEngine;

//public class WallHoleEffect : MonoBehaviour
//{
//    [SerializeField] private Camera playerCamera;
//    [SerializeField] private float sphereRadius = 0.3f;
//    [SerializeField] private float maxDistance = 5f;
//    [SerializeField] private float holeRadius = 0.5f;
//    [SerializeField] private float fadeSpeed = 3f;
//    [SerializeField] private LayerMask wallMask;

//    private static readonly int HolePositionID = Shader.PropertyToID("_HolePosition");
//    private static readonly int HoleRadiusID = Shader.PropertyToID("_HoleRadius");

//    // Храним последний hit renderer чтобы сбрасывать при уходе
//    private Renderer lastRenderer;
//    private float currentRadius = 0f;
//    private bool isNear = false;

//    private void Update()
//    {
//        RaycastHit hit;
//        bool didHit = Physics.SphereCast(
//            playerCamera.transform.position,
//            sphereRadius,
//            playerCamera.transform.forward,
//            out hit,
//            maxDistance,
//            wallMask);

//        // Плавное изменение радиуса
//        float targetRadius = didHit ? holeRadius : 0f;
//        currentRadius = Mathf.Lerp(currentRadius, targetRadius, Time.deltaTime * fadeSpeed);

//        if (didHit)
//        {
//            Renderer rend = hit.collider.GetComponent<Renderer>();
//            if (rend != null)
//            {
//                // Если сменили стену — сбросить старую
//                if (lastRenderer != null && lastRenderer != rend)
//                    ClearHole(lastRenderer);

//                lastRenderer = rend;

//                MaterialPropertyBlock block = new MaterialPropertyBlock();
//                rend.GetPropertyBlock(block);
//                block.SetVector(HolePositionID, hit.point);   // World Space позиция
//                block.SetFloat(HoleRadiusID, currentRadius);
//                rend.SetPropertyBlock(block);
//            }
//        }
//        else
//        {
//            // Камера далеко — плавно убираем дырку
//            if (lastRenderer != null)
//            {
//                MaterialPropertyBlock block = new MaterialPropertyBlock();
//                lastRenderer.GetPropertyBlock(block);
//                block.SetFloat(HoleRadiusID, currentRadius);
//                lastRenderer.SetPropertyBlock(block);

//                // Когда радиус почти 0 — полностью сбрасываем
//                if (currentRadius < 0.01f)
//                {
//                    ClearHole(lastRenderer);
//                    lastRenderer = null;
//                }
//            }
//        }
//    }

//    private void ClearHole(Renderer rend)
//    {
//        MaterialPropertyBlock block = new MaterialPropertyBlock();
//        rend.GetPropertyBlock(block);
//        block.SetFloat(HoleRadiusID, 0f);
//        rend.SetPropertyBlock(block);
//    }
//}
