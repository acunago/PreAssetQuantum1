using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetsController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Stick = false;
    public Color32 colour;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 2) { return; }
        if (collision.transform.GetComponent<Rigidbody>() != null)
        {

            var sticky = gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            sticky.connectedBody = collision.rigidbody;

            if (collision.transform.gameObject.GetComponent<Outline>() == null)
            {
                collision.transform.gameObject.AddComponent<Outline>();

                collision.transform.gameObject.GetComponent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
                collision.transform.gameObject.GetComponent<Outline>().OutlineWidth = 10;
                collision.transform.gameObject.GetComponent<Outline>().OutlineColor = colour;
            }
            Stick = true;

        }
        else
        {
            DestroyObj();
        }

        //if (collision.collider != null && collision.collider.gameObject.GetComponent<Emerald_AI>() != null)
        //{
        //    collision.collider.gameObject.GetComponent<Emerald_AI>().Damage(100, Emerald_AI.TargetType.Player);

        //}

    }
    public void DestroyObj()
    {
        if (gameObject.GetComponent<FixedJoint>() != null)
        {
            Destroy(gameObject.GetComponent<FixedJoint>().connectedBody.transform.gameObject.GetComponent<Outline>());
        }
        Destroy(gameObject);
    }
}
