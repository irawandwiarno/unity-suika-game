using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System.Collections;


public class Player : MonoBehaviour, TouchInput.ITouchActions
{
    public Transform startFruid;
    public Transform batasKiri;
    public Transform batasKanan;
    private TouchInput touchInput;
    private Camera cameraMain;
    public static bool fruitExist = false;
    private Coroutine releaseCoroutine;
    public float delay = 0.5f;

    public UnityEvent OnTouchRellase;


    private void Awake()
    {
        touchInput = new TouchInput();
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        touchInput.Enable();
        //touchInput.Touch.SetCallbacks(this);
    }

    private void OnDisable()
    {
           // Cancel all input actions
        touchInput.Disable();

        // Clear all callbacks
        //touchInput.Touch.TouchPosition.canceled -= OnTouchCanceled;
    }

    public void OnTouchInput(InputAction.CallbackContext context)
    {
    }

    public void OnTouchPress(InputAction.CallbackContext context)
    {
        if (!EndLine.isPaused)
        {
            if (context.canceled)
            {
                OnTouchRellase.Invoke();
                Debug.Log("OnPrees Releasse");
                if (releaseCoroutine != null)
                {
                    StopCoroutine(releaseCoroutine);
                }

                releaseCoroutine = StartCoroutine(ReleaseCoroutine());
            }
        }

    }

    public void OnTouchPosition(InputAction.CallbackContext context)
    {
        Vector2 touchPos = context.ReadValue<Vector2>();
        Vector3 screenPos = new Vector3(touchPos.x, touchPos.y, cameraMain.nearClipPlane);
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

    private IEnumerator ReleaseCoroutine()
    {
        yield return new WaitForSeconds(delay);

        fruitExist = false;
        releaseCoroutine = null;
    }

}
