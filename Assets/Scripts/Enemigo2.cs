using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : Circulos
{
    // TODO trabajar con diferenciales
    // para poder sumar la posición calculada a la posición actual del objeto.
    protected float radio = 1f;
    public float centroX = 0;
    public float centroY = 0;
    public int clockwise = 1;
    protected float velocidad = 2;

	// Use this for initialization
	void Start () {
        body = this.GetComponent<Rigidbody2D>();
        body.gravityScale = 0f;
        centroX = this.GetComponent<Transform>().position.x - radio;
        centroY = this.GetComponent<Transform>().position.y - radio;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // 0 grados = 2pi
        // 90 grados = pi / 2
        // 1 pi radian = 180 grados / pi

        // Fórmula del cálculo de la posición en el movimiento circular uniforme
        // x = x0 + r * cos(alfa)
        // y = y0 + r * sin(alfa)
        // Siendo x0 e y0 el centro de la circunferencia y r el radio.
        calcularSenoDelTiempo(velocidad);
        calcularCosenoDelTiempo(velocidad);
        
        float x = centroX + radio * cosenoTiempo;
        float y = centroY + radio * senoTiempo;

        Debug.Log("CENTROX " + centroX + " CENTROY " + centroY);
        Debug.Log("radio*cos " + (radio * cosenoTiempo) + " radio*sin " + (radio * senoTiempo));
        // Se va a restar la mitad del número máximo del rango para centrar en 0
        // sumarPosicion(clockwise * x/60, clockwise * y/60);
        Vector2 nuevaPos = diferencialPosicion(x, y);
        body.AddForce(new Vector2(nuevaPos.x, nuevaPos.y));
    }
}
