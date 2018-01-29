using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectManagerComponent : MonoBehaviour {
    [SerializeField]
    Transform node_parent;
    [SerializeField]
    GameObject node_prefab;

	// Use this for initialization
	void Start () {
        SetupDummyLevelNodes();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetupDummyLevelNodes()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject node = Instantiate(node_prefab, node_parent);
            node.GetComponent<LevelNodeComponent>().SetupUI(i);
        }
    }
}
