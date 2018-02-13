# Videogames
Video Game Development: EM2018 with Guillermo Rivas. Unity and C# is mainly used in this course. 

## Partial 1 - Subjects
- GetComponent
- Collisions
- Rigid Body Operations such as apply force, explosions, etc...
- Instantiate
- Destroy 
- Coroutines
- Patrolling
- GUI
- Input - keyboard / mouse o axes

### GetComponent

Project Physics, File Bricks.cs

```C#
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
    }
```

Previous example is shown as if Rigidbody was private, but what happens if it is public?

```C# 
    public GameObject projectile; 
```

In this case, only initialization is needed as a global variable. Afterwards, one can drag the object into the script directly in the Unity interface, so that such object becomes GameObject projectile. 

### Colisions

Colisions are used directly from the object that moves, such as a bullet for example.

```C#
   void OnCollisionEnter(Collision c) //At the moment it collides
    {
        Destroy(c.gameObject); //Destroys object that collides with "bullet"
        
    }
```
In this case the bullet will destroy any object that collides with it. There is also variations of OnCollision, such as the Enter in the example. Exit happens when an object stops colliding with the bullet; on the other hand, Stay executes while the object and bullet are colliding. 

### Rigid Body
Project file Physics, c# code named as Brick.cs

```C#
    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        Invoke("Explotar", 2);

    }

    void Explotar()
    {
        rb.AddExplosionForce(2000, Vector3.zero, 10);
        print("si jala");
    }

```
