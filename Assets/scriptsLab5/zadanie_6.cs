using UnityEngine;

public class SprawdzanieKontaktu : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Przeszkoda"))
        {
            Debug.Log("Doszło do kontaktu z przeszkodą: " + hit.gameObject.name);
        }
    }
}