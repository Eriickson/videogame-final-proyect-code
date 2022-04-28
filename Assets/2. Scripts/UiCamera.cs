using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCamera : MonoBehaviour
{
    public Transform player;
    public float xPost;
    public float yPost;
    public float zPost;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x + xPost, player.position.y + yPost, zPost);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + xPost, player.position.y + yPost, zPost);
    }
}
