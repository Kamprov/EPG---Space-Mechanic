using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerController : MonoBehaviour
{
	public float Speed = 5f;

	private Vector2 target;

	public void Start()
	{
		target = (Vector2) transform.position;
	}

	//Dirty code;;;Not optimised;;;Changes needed
	public void Update()
	{
		if(Input.GetButtonDown("Click"))
		{
			//Future movement based on grid
			//target = LevelController.GetLevel().levelTiles[4, 4].getTilePosition();


			Vector2 selectedPosition = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D[] colliders = Physics2D.OverlapCircleAll(selectedPosition, 0.1f);

			foreach(Collider2D collider in colliders)
			{
				Vector2 vector1 = new Vector2(collider.transform.position.x, collider.transform.position.y + 1);
				Vector2 vector2 = new Vector2(collider.transform.position.x + 1, collider.transform.position.y);
				Vector2 vector3 = new Vector2(collider.transform.position.x, collider.transform.position.y - 1);
				Vector2 vector4 = new Vector2(collider.transform.position.x - 1, collider.transform.position.y);

				float distance1 = Vector2.Distance(transform.position, vector1);
				float distance2 = Vector2.Distance(transform.position, vector2);
				float distance3 = Vector2.Distance(transform.position, vector3);
				float distance4 = Vector2.Distance(transform.position, vector4);

				var listV = new[] {vector1, vector2, vector3, vector4};
				var listD = new[] {distance1, distance2, distance3, distance4};

				float min = distance1;
				Vector2 closestDistance = vector1;

				for(int i = 1; i < listD.Length; i++)
				{
					if(listD[i] < min)
					{
						min = listD[i];
						closestDistance = listV[i];
					}
				}

				Debug.Log(min.ToString());

				if(collider.gameObject.tag.Equals("Material"))
				{
					target = closestDistance;
				}
			}
		}
	}

	public void FixedUpdate()
	{
		transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
	}		
}
