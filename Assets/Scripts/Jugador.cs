using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : Circulos {

    public float superficieMaxima = 4;
    public float superficieMinima = 2;
    public float superficie = 2;
    public bool despegado = false;

    private float desplazamientoDefecto = 0.01F;

    private float aumentoTamanioX = 0.01F;
    private float aumentoTamanioY = 0.01F;
    private float perdidaTamanioX = 0.001F;
    private float perdidaTamanioY = 0.001F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        teclasPulsadas();
        movimientoBasal();
    }

    private void teclasPulsadas() {
        // Código que está a la espera de que el jugador pulse A o D
        // para provocar un desplazamiento horizontal.
        if (Input.GetKey(KeyCode.A))
        {
            sumarPosicion(desplazamientoDefecto, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            sumarPosicion(-desplazamientoDefecto, 0);
        }
    }

    private void movimientoBasal() {
        if (despegado && superficie > superficieMinima)
        {
            sumarPosicion(0, 0.02F);
        }
    }

    private void inflarse(){
#warning
        // El personaje perderá aire constantemente por una vía de escape
        // hasta alcanzar un mínimo.
        // TODO: escala debería cambiar en ambos ejes
        if (superficie > superficieMinima)
        {
            if (!Input.GetKey(KeyCode.C))
            {
                transform.localScale -= new Vector3(perdidaTamanioX, perdidaTamanioY, 0);
                superficie -= perdidaTamanioX;
            }
        }
        else {
            this.GetComponent<Rigidbody2D>().isKinematic = false;
        }
#warning
        // Código que se ejecuta en el momento inicial.
        // El jugador pulsará C para inflarse hasta soltar
        // la tecla o hasta llegar a un máximo.
        // TODO:
        // Sólo se debería permitir un inflado inicial.
        if (!despegado)
        {
            float aumentoTamanioXProximo = 0;
            float aumentoTamanioYProximo = aumentoTamanioY;
            if (superficie < superficieMaxima)
            {
                if (Input.GetKey(KeyCode.C))
                {
                    aumentoTamanioXProximo = aumentoTamanioX;
                    if (transform.localScale.x < 0)
                    {
                        aumentoTamanioXProximo = -aumentoTamanioX;
                    }
                    transform.localScale += new Vector3(aumentoTamanioXProximo, aumentoTamanioYProximo, 0);
                    superficie += aumentoTamanioXProximo;
                }
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                body.gravityScale = 0;
                despegado = true;
            }
        }
    }
}
