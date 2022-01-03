using UnityEngine;
using UnityEngine.UI;

/**
 * This component lets the player show/hide the cursor by clicking ESC.
 * Initially, it hides the cursor.
 */
public class CursorHider : MonoBehaviour {

    [SerializeField] private Image dialogImage;
    [SerializeField] private GameObject menu;
    void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menu = GameObject.Find("MenuGamePlay").gameObject;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) || dialogImage.gameObject.activeSelf || menu.activeSelf) {
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
