using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalfosMovement : MonoBehaviour
{

    private Vector3 new_pos;
    private Vector3 ray_right;
    private Vector3 ray_left;
    private Vector3 ray_up;
    private Vector3 ray_down;
    public float move_speed = 1.0f;

    
    
    private bool move_up = true;
    private bool move_down = true;
    private bool move_left = true;
    private bool move_right = true;

    private bool moving = false;
    // Start is called before the first frame update
    void Start()
    {
        new_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        ray_right = transform.position;
        ray_right.x += 1;
        ray_left = transform.position;
        ray_left.x -= 1;
        ray_up = transform.position;
        ray_up.y += 1;
        ray_down = transform.position;
        ray_down.y -= 1;
        
        int ran_dir;

        
        move_right = check_direction(Vector3.right);
        move_up = check_direction(Vector3.up);
        move_left = check_direction(Vector3.left);
        move_down = check_direction(Vector3.down);

        List<Vector3> dirs = new List<Vector3>();

        if(move_right){
            dirs.Add(ray_right);
        }

        if(move_up){
            dirs.Add(ray_up);
        }

        if(move_left){
            dirs.Add(ray_left);
        }

        if(move_down){
            dirs.Add(ray_down);
        }

        //Debug.DrawRay(transform.position, Vector3.up);
        //Debug.DrawRay(transform.position, ray_down);
        //Debug.DrawRay(transform.position, ray_left);
        //Debug.DrawRay(transform.position, ray_right);

        
        //Debug.Log(dirs.Count.ToString());
        if(!moving && dirs.Count > 0){
            ran_dir = Random.Range(0, dirs.Count);
            new_pos = dirs[ran_dir];
            moving = true;
        }

        //if(Input.GetKeyDown("space") && can_move){
        //    new_pos = transform.position;
        //    new_pos.x += 1;
           
        //}

        if(new_pos != transform.position){
            transform.position = Vector3.MoveTowards(transform.position, new_pos, move_speed * Time.deltaTime);
        }else{
            moving = false;
        }


    }

    bool check_direction(Vector3 dir){
        RaycastHit hit;
        if(Physics.Raycast(transform.position, dir, out hit, 0.9f)){
            
            if(hit.collider.gameObject.name == "Tile_WALL"){
                return false;
            }else{
                return true;
            }
        }
        return true;
    }
}
