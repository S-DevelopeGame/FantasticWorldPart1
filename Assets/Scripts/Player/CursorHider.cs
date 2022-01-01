using UnityEngine;
using UnityEngine.UI;

/**
 * This component lets the player show/hide the cursor by clicking ESC.
 * Initially, it hides the cursor.
 */
public class CursorHider : MonoBehaviour {

    [SerializeField] private Image dialogImage;
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || dialogImage.gameObject.activeSelf) {
            if (!Cursor.visible || dialogImage.gameObject.activeSelf) {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
