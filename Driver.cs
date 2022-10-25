using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float turnSpeed = 250f; 
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 20f; 
    [SerializeField] float fastSpeed = 30f;  
    
    void OnCollisionEnter2D(Collision2D other) //Burada herhangi bir yere çarptığında slowspeede eşitliyor.
    {
        moveSpeed = slowSpeed;        
    }

    void OnTriggerEnter2D(Collider2D other) //Burada faster adına atadığımız nesnenin üzerinden geçtiğinde fastspeede eşitlememizi söylüyoruz. 
    {
        if (other.tag == "faster")
        {
            moveSpeed = fastSpeed;
        }

    }

/*serializeField unity içinde değişiklik yaptırıp oyun değişkenlerini daha güvenli hale getirir.
turnSpeed ve moveSpeed oyun motoru içinde değiştirebileceğim değişkenlerin isimleri ben srealizeField 
eklediğimde unity motorunda driver script adı altında değişkenlerim gelmiş olacak ve ben onları unity üzerinden
değiştireceğim burda verdiğim değerler ise oyun içinde atadığım varsayılan değerlerim olacaktır.*/
    
    // Update is called once per frame
    void Update()
    {   
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0, moveAmount, 0);
        
    }
}
/*Hareket girdileri için Unity içinde kontrol et Edit> ProjectSetting> InputManager*/
/*GetAxis ve içine verilen horizontal veya vertical değer onun bizim sağa sola ileri geri yapabilmemize olanak sağlar.
-moveSpeed ve turnSpeed bizim başta atadığımız değerlerdi.
-transform.Rotate objenin genel koordinat sistemindeki rotasyon değeri
 transform.Translate Objeyi transform bileşenini kullanarak adım adım hareket ettirmemizi sağlar.
-Time.deltaTime komutlarımızı bilgisayarımız hızlı çalıştıkça daha düşük değerle vermemizi, 
bilgisayarımız yavaş çalıştıkça daha yüksek değerle vermemizi sağlayarak ortalama olarak aynı değerde çalışmasını sağlar.*/
