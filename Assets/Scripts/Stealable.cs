using UnityEngine;
using System.Collections;

public class Stealable : MonoBehaviour {

    public float points;
    public float grabDistance;
    
    Player player;

	// Use this for initialization
	void Start () {
	    player = (Player) FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	void Update () {
	}

    public bool canBeStolen (){
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        vectorToPlayer.y = 0;
        RaycastHit hit;
        if(Vector3.Angle(player.transform.forward, vectorToPlayer*-1f) < 20) {
            if(Physics.Raycast(transform.position, vectorToPlayer, out hit, grabDistance) ) {
                Transform rootTransform = hit.transform;
                while(rootTransform.parent != null)
                {
                    rootTransform = rootTransform.parent;
                }

                if (rootTransform.gameObject == player.gameObject) {
                    return true;
                }
            }
        }
        return false;
    }
}
