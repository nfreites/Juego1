using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Circulos : MonoBehaviour {

    protected Rigidbody2D body;
    protected float senoTiempo = 0;
    protected float cosenoTiempo = 0;

    // Use this for initialization
    void Start () {
		
	}

    /**
   * Cambia la posición del objeto "this" sumando en las coordenadas
   * x e y los valores de entrada @param x y @param y.
   */
    public void sumarPosicion(float posX, float posY)
    {
        transform.position += new Vector3(posX, posY, 0);
    }

    public Vector2 diferencialPosicion(float posX, float posY)
    {
        return new Vector2(posX - transform.position.x, posY - transform.position.y);
    }

    public void calcularSenoDelTiempo()
    {
        senoTiempo = Mathf.Sin(Time.unscaledTime);
    }

    public void calcularCosenoDelTiempo()
    {
        cosenoTiempo = Mathf.Cos(Time.unscaledTime);
    }

    public void calcularSenoDelTiempo(float velocidad)
    {
        senoTiempo = Mathf.Sin(Time.unscaledTime * velocidad);
    }

    public void calcularCosenoDelTiempo(float velocidad)
    {
        cosenoTiempo = Mathf.Cos(Time.unscaledTime * velocidad);
    }
}
