using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
	public bool Death = false;

    public Image healthBar = null;
    public Image progressBar = null;

	public float maxHealth, curHealth;

    void Update()
    {

        if(Death)
        {
            transform.position -= new Vector3(0.0f, 3.0f * Time.deltaTime, 0.0f);
            //healthBar.gameObject.SetActive(false);
            //progressBar.gameObject.SetActive(false);
        }else
        {
            //healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            //progressBar.fillAmount = (curHealth / maxHealth) * 1.0f;
        }
    }

    public void anyDamage(float _dmg)
    {
    	if(!Death)
    	{
    		curHealth -= _dmg;
    		if(curHealth <= 0.0f)
    		{
    			Death = true;
    		}
    	}
    }
}
