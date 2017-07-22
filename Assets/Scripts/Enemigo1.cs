using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : Circulos
{
    public int tipoMovimiento = 0;

    void start() {
        body = this.GetComponent<Rigidbody2D>();
        body.gravityScale = 0f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // 0 grados = 2pi
        // 90 grados = pi / 2
        calcularSenoDelTiempo();
        float pos = senoTiempo;
        pos *= 6;

        if (tipoMovimiento == 1)
        {
            // Movimiento horizontal
            Vector2 nuevaPos = diferencialPosicion(pos, 0);
            body.AddForce(new Vector2(nuevaPos.x, 0));
        }
        else if (tipoMovimiento == 2)
        {
            // Movimiento vertical
            Vector2 nuevaPos = diferencialPosicion(0, pos);
            body.AddForce(new Vector2(0, nuevaPos.y));
        }
        else if (tipoMovimiento == 3)
        {
            // Movimiento diagonal
            Vector2 nuevaPos = diferencialPosicion(pos, pos);
            body.AddForce(new Vector2(nuevaPos.x, nuevaPos.y));
        }
        else {
            // Movimiento horizontal por defecto
            Vector2 nuevaPos = diferencialPosicion(pos, 0);
            body.AddForce(new Vector2(nuevaPos.x, 0));
        }

    }
}
