using UnityEngine;
using UnityEngine.SceneManagement;

public class itemScript : MonoBehaviour
{
    int contador = 10;

    public GameObject puertaFinal;
    public GameObject campana;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        campana.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            contador--;
            if (contador == 0)
            {
                Destroy(puertaFinal);
                campana.SetActive(true);
            }
        }
        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("level1");

        }
    }
}

