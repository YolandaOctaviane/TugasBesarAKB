using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIGameOverController : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButtonDown(0))
        {
            // reload
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
