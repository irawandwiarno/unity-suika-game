using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Events;
using System.Collections;

public class Player : MonoBehaviour
{
    public Transform startFruid;
    public Transform batasKiri;
    public Transform batasKanan;
    private Camera cameraMain;
    public static bool fruitExist = false;
    private Coroutine releaseCoroutine;
    public float delay = 0.5f;

    public UnityEvent OnTouchRellase;

    private void Awake()
    {
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        // Aktifkan fitur input sentuh yang ditingkatkan
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        // Nonaktifkan fitur input sentuh yang ditingkatkan
        EnhancedTouchSupport.Disable();
    }

    private void Update()
    {
        // Periksa input sentuh
        foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            // Lakukan sesuatu dengan setiap sentuhan aktif
            if (!EndLine.isPaused)
            {
                if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended)
                {
                    OnTouchRellase.Invoke();
                    Debug.Log("OnPress Release");
                    if (releaseCoroutine != null)
                    {
                        StopCoroutine(releaseCoroutine);
                    }

                    releaseCoroutine = StartCoroutine(ReleaseCoroutine());
                }

                Vector3 screenPos = new Vector3(touch.screenPosition.x, touch.screenPosition.y, cameraMain.nearClipPlane);
                Vector3 worldPos = cameraMain.ScreenToWorldPoint(screenPos);
                worldPos.z = 0;
                worldPos.y = startFruid.position.y;
                if (worldPos.x <= batasKiri.position.x)
                {
                    worldPos.x = -1.6f;
                }
                if (worldPos.x >= batasKanan.position.x)
                {
                    worldPos.x = 1.6f;
                }
                gameObject.transform.position = worldPos;
                Debug.Log("Touch position: " + worldPos);
            }
        }
    }

    private IEnumerator ReleaseCoroutine()
    {
        yield return new WaitForSeconds(delay);

        fruitExist = false;
        releaseCoroutine = null;
    }
}
