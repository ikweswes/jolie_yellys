using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSelector : MonoBehaviour
{

    public TransformAndPanelName[] mainpannels;
    public KeyCode up = KeyCode.UpArrow;
    public KeyCode down = KeyCode.DownArrow;
    int index;
    // Update is called once per frame
    void Start()
    {
        index = 0;
    }

    void Update()
    {


        if (Input.GetKeyDown(up))
        {
            index -= 1;
            checkoutofrange();
            setposition();
        }
        else if (Input.GetKeyDown(down))
        {
            index += 1;
            checkoutofrange();
            setposition();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pannelactiion(mainpannels[index].pn);
        }


    }

    void setposition()
    {


        checkoutofrange();
        try
        {
            this.transform.position = mainpannels[index].tf.position;
        }
        catch
        {
        }


    }

    void checkoutofrange()
    {
        if (index < 0)
            index = 0;

        if (index >= mainpannels.Length)
            index = mainpannels.Length - 1;

    }

    void pannelactiion(string pannelname)
    {
        if (pannelname == "Reload")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (pannelname == "Quit")
        {
            Application.Quit();
        }

    }
}



