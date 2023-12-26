using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float rotSpeed;

	public GameObject projectile;
	public Transform spawnPos;
	private float timeBtwShots;
	public float startTimeBtwShots;

	private void Update()
	{
		Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotSpeed * Time.deltaTime);

		if(Input.GetMouseButtonDown(0)){
			Instantiate(projectile, spawnPos.position, transform.rotation);
		}

		if(Input.GetMouseButton(0)){

			if(timeBtwShots <= 0)
			{
				Instantiate(projectile, spawnPos.position, transform.rotation);
				timeBtwShots = startTimeBtwShots;
			}
			else
			{
				timeBtwShots -= Time.deltaTime;
			}
		} 
	}
}
