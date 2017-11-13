using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TableList : MonoBehaviour {


    private List<Player> lista;
    public GameObject content;
    

    public void createLista(List<Player> lista) { this.lista = lista.OrderBy(p => p.Position).ToList(); refresh(); }

    public void refresh()
    {
        bool back = false;
        foreach (Transform child in content.transform)
            Destroy(child.gameObject);
        lista.ForEach(p => {
            GameObject o = Instantiate(Resources.Load("Prefabs/row")) as GameObject;
            o.transform.SetParent(content.transform);
            if (!back)
                o.GetComponent<Image>().color = new Color(255, 255, 255);     
            back = !back;
            o.GetComponent<TableRow>().setRefPlayer(ref p);
        });

    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
