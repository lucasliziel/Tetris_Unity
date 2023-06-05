using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromovie : MonoBehaviour
{

    public bool poderolar();
    public bool roda360();


    public float queda;

    public float velocidade;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer - velocidade;
    }

    if (Input.GetKeyUp(Keycode.RightArrow) || Input.GetKeyUp(Keycode.LeftArrow) || Input.GetKeyUp(Keycode.DownArrow))
    timer = velocidade;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(Keycode.RightArrow))
        {
            timer += Time.deltaTime;
            
            if (timer > velocidade){       
            transform.position += new Vector3(1,0,0);
            timer - 0;
            }

            if(posicaoValida()){

            }else{
                transform.position += new Vector3(-1,0,0);

            }

        }
        if(Input.GetKey(Keycode.LeftArrow))
        {
            timer += Time.deltaTime;
            if (timer > velocidade){
            transform.position += new Vector3(-1,0,0);
            timer - 0;
            }

            if(posicaoValida()){

            }else{
                transform.position += new Vector3(1,0,0);
            }

        }
        if(Input.GetKey(Keycode.DownArrow)) //|| Time.time - queda >= 1 )
        {
            timer += Time.deltatime

            if(timer > velocidade){
            transform.position += new Vector3(0,-1,0);
            timer - 0;
            }

            if(posicaoValida()){

            }else{
                transform.position += new Vector3(0,1,0);
            }

            //queda = Time.time


        }

        if(Time.time - queda >=1 && !Input.GetKey(Keycode.DownArrow)){
            transform.position += new Vector3(0, -1, 0);
            if(posicaoValida())
            {

            }else{
                transform.position += new Vector3(0, 1, 0);
            }


            queda = Time.time;


        }
        if(Input.GetKeyDown(Keycode.UpArrow))
        {
            checaRoda();
        }
    }

    void checaRoda(){
        if (poderolar){
            if(!roda360){
                if(transform.rotation.z < 0){
                    transform.Rotate(0,0, 90);
                    if(posicaoValida()){

                    }else{
                        transform.Rotate(0,0, -90)
                    }
                }else{
                    transform.Rotate(0,0, -90);

                    if(posicaoValida()){

                    }else{
                        transform.Rotate(0,0, 90);
                    }
                }
            }else{
                transform.Rotate(0,0, -90);

                if(posicaoValida()){

                }else{
                    transform.Rotate(0,0, 90);
                }
            }
        }
    }

    bool posicaoValida(){
        foreach(transform child in transform ){
            vector2 posBloco = FindObjectOfType<GameManager>().arredonda(child.position);

            if(FindObjectOfType<GameManager>().dentroGrade(posBloco) == false){
                return false;
            }
        }

        return true;
    }
}
