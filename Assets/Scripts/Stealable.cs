using UnityEngine;
using System.Collections;

public class Stealable : MonoBehaviour {

    public float points;
    public float grabDistance;
    [HideInInspector] public bool isHighlighted = false;
    private Behaviour halo;
    
    Player player;

	// Use this for initialization
	void Start () {
	    player = (Player) FindObjectOfType(typeof(Player));
        halo = (Behaviour) GetComponent("Halo");
        halo.enabled = false;
	}

    // Update is called once per frame
    void Update() {
        if (isHighlighted) {
            halo.enabled = true;
        }
        else {
            halo.enabled = false;
        }
    }


    public bool canBeStolen (){
        Vector3 vectorToPlayer = player.transform.position + (1.3f * Vector3.up) - transform.position;
        if (vectorToPlayer.magnitude > grabDistance) {
            return false;
        }
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
