using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    
    [SerializeField] Color32 paketTakenColor = new Color32 (1, 1, 1, 1); //Color32 bizim renk kartelamız paketTken değişkenlerimiz new color32 de yeni atadığımız değerler
    [SerializeField] Color32 paketGivenColor = new Color32 (1, 1, 1, 1);

    SpriteRenderer sprtr;

    void Start() 
    {
        sprtr = GetComponent<SpriteRenderer>(); //sprtr değişkenini 
    }
 
    void OnCollisionEnter2D(Collision2D other) //Çarpınca consola bum yazdır
    {
        Debug.Log("Bum!"); 
    }

    bool hasPaket; // bool means true or false.eğer burda olduğu gibi bool hasPaket = ture veya false demezsek false olarak kabul eder.
    [SerializeField] float destDelay = 0.1f; //destDelay yok eder. 0.1f de ne kadar sürede yok ettiğini.
    
    void OnTriggerEnter2D(Collider2D other) // Nesne Trigger alanına girince çalışmaktadır. other aslında bizim oyundaki objemizdir.
    
    {
        if (other.tag == "Paket" && !hasPaket) // && ve anlamına gelir. ! ise değişkenin tersini ifade eder. 
        {
            Debug.Log("Package picked up");
            hasPaket = true;
            sprtr.color = paketTakenColor;
            Destroy(other.gameObject, destDelay); //Paketleri yok ediyor.    
        }
        
        if (other.tag == "Human" && hasPaket)
        {
            Debug.Log("You delivered Package to Human");
            hasPaket = false;
            sprtr.color = paketGivenColor; 
        }
    }
}
