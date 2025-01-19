using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 20f; // Vitesse de déplacement
    public float rotationSpeed = 400f; // Vitesse de rotation

    void Update()
    {
        // Déplacement avant/arrière avec les flèches haut/bas
        if (Input.GetKey(KeyCode.UpArrow)) // Flèche haut pour avancer
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)) // Flèche bas pour reculer
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        // Déplacement latéral avec les flèches gauche/droite
        if (Input.GetKey(KeyCode.LeftArrow)) // Flèche gauche pour bouger à gauche
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) // Flèche droite pour bouger à droite
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        // Rotation gauche/droite avec les touches "Q" et "D"
        if (Input.GetKey(KeyCode.S)) // Touche "Q" pour tourner à gauche
        {
            transform.Rotate(new Vector3(0, -rotationSpeed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.D)) // Touche "D" pour tourner à droite
        {
            transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
        }
    }
}