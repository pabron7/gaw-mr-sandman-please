
using UnityEngine;

public class EndMenu : MonoBehaviour
{

    void Start()
    {
        UnlockCursor();
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
