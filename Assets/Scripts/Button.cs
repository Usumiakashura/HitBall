using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
