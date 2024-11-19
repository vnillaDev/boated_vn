using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAddon : MonoBehaviour
{
    private ObjectFader _objectFader;
    private GameObject player;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }



    private void Update()
    {

        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;

            Ray ray = new(transform.position, direction);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider == null)
                {
                    return;
                }

                if (hit.collider.gameObject == player)
                {
                    // nothing is in front of player
                    if (_objectFader != null)
                    {
                        _objectFader.DoFade = false;
                    }
                    else
                    {
                        _objectFader = hit.collider.gameObject.GetComponent<ObjectFader>();

                        if (_objectFader != null)
                        {
                            _objectFader.DoFade = true;
                        }
                    }
                }
            }
        }
    }
}
