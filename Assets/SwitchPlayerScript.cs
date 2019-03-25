using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SwitchPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public Mesh placeholderMesh;

    private SphereCollider headCollider;

    void Start()
    {
        headCollider = (SphereCollider) GetComponent<Player>().headCollider;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Switch"))
        {
            player.gameObject.SetActive(true);

            Destroy(GameObject.Find("Placeholder"));
            CreateNewPlaceholder();

            gameObject.SetActive(false);
        }
    }

    void CreateNewPlaceholder()
    {
        var placeholderGameObject = new GameObject("Placeholder");
        var meshFilter = placeholderGameObject.AddComponent<MeshFilter>();
        placeholderGameObject.AddComponent<MeshRenderer>();
        meshFilter.sharedMesh = placeholderMesh;
        placeholderGameObject.transform.position = headCollider.transform.position;
        placeholderGameObject.transform.rotation = headCollider.transform.rotation;
    }
}
