using UnityEngine;
using UnityEngine.Rendering;

public class Menus : MonoBehaviour
{

    public GameObject pausemenu;
    public GameObject keybinds;
    public GameObject customer;

    public static bool GIP = false;
    //is short for game is pasued
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (GIP)
            {
                Resume();

            }
            else
            {

                pause();


            }


        }



        void Resume () 
        
        {
            keybinds.SetActive(true);
            customer.SetActive(true);
            pausemenu.SetActive(false);
            Time.timeScale = 1f;
            GIP = false;

        }

        void pause()

        {
            
            pausemenu.SetActive(true);
            keybinds.SetActive(false);
            customer.SetActive(false);
            Time.timeScale = 0f;
            GIP = true;
        }


    }

}

 

   
