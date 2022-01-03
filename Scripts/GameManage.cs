using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject menu1;
    public GameObject menugameover;



    public float velocidad = 2;
    public GameObject piso;
    public GameObject piedra;
    public Renderer fondo;
    public bool gameOver = false;
    public bool start = false;

    public List<GameObject> pisos;
    public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<21; i++)
        {
            pisos.Add(Instantiate(piso, new Vector2(-10 + i,-3), Quaternion.identity));
        }

        obstaculos.Add(Instantiate(piedra, new Vector2(14, -2), Quaternion.identity));


    }

    // Update is called once per frame
    void Update()
    {
        if(start == false)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }


         if(start == true && gameOver == true)
         {
             menugameover.SetActive(true);
             if(Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene( SceneManager.GetActiveScene().name);
            }
         }


        if(start == true && gameOver == false)
        {
            menu1.SetActive(false);
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.015f,0)* Time.deltaTime;

        for (int i=0; i<pisos.Count ; i++)
        {
            if(pisos[i].transform.position.x <= -10)
            {
                pisos[i].transform.position = new Vector3(10,-3,0);
            }

            pisos[i].transform.position =  pisos[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
        }


        for (int i=0; i<obstaculos.Count ; i++)
        {
            if(obstaculos[i].transform.position.x <= -10)
            {
                float randomObstaculos = Random.Range(11,18);
                obstaculos[i].transform.position = new Vector3(randomObstaculos,-2,0);
            }

            obstaculos[i].transform.position =  obstaculos[i].transform.position + new Vector3(-1,0,0) * Time.deltaTime * velocidad;
        }
        }
    }
}
