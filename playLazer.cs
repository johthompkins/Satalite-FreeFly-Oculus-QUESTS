using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class playLazer : MonoBehaviour
{
    public RaycastHit hit;
    public Material green;
    public Material red;
    public AudioSource sound;
    public float time;

    private LineRenderer lr;

    // Use this for initialization
    public void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    public void Update()
    {
        time += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            SceneManager.LoadScene(0);
        }

        lr.SetPosition(0, transform.position);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {

                lr.SetPosition(1, hit.point);
                IsItTarget();
            }
        }
        else
        {
            lr.material = red;
            sound.Stop();
            lr.SetPosition(1, transform.forward * 5000);
        }

    }

    public void IsItTarget()
    {
        if (hit.collider.tag == "target")
        {
            lr.material = green;
            //Time.timeScale = 0.25f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
            //SceneManager.LoadScene(nextLevel);

        }
    }
}
