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

While colisions are a way to create an action after an impact between two objects, <b> Triggers </b> could also do the job. 
```C#
 void OnTriggerEnter(Collider c) 
    {
        Destroy(c.gameObject); 
        
    }
```
OnTrigger also has Enter, Exit & Stay and they work the same way around as Colliders. Beforehand, one needs to check the 'Is Trigger' option of the objects that should collide with the Bullet. With this method, one can ensure which objects can be destroyed, in this case, if the bullet collides with it. 
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
    }

```
This causes the bullet to push all objects in a certain radius with a certain force  as if it exploded. 

Next, one can manipulate the force that the bullet is traveling by. 

```c#
 	rb.AddForce(125 * transform.forward, ForceMode.Impulse);
        rb.AddForce(150 * transform.up, ForceMode.Impulse);
```
In this way, the bullet goes foward with a force of 125 while it goes by 150 upwards. 

### Instantiate

Instantiate is used for spawning an object after certain conditions, defined by the programmer, happen. 

```C#

if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(originalBullet, punta.position, transform.rotation);
        }

```

Lets say a tank is running the previous script, when the spacebar is pressed a bullet will spawn from it at punta's position. In this case punta would be the tip of the cannon from such tank. More to be said, a object spawned by Instantiate may stay or exist in the scene while running, until stated otherwise. So, one should be able to handle this issue by destroying an object when it is no longer necessary. 

```C# 
   void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
```
In this case the object will no longer exist after it goes out of the camera's vision. 

### Destroy 

As previously mentioned, Destroy makes an object to stop existing from the game's current scene. This can be used to avoid extra useless objects thay may slow down the game. The previous sentence is just making reference to what was mentioned in the Instantiate section. 
This can also be used within Triggers or Colliders if the game is supposed to work in a way that an object takes care to destroy others.

### Coroutines

Coroutines were explaines as pseudothreads. This will constantly excecute a piece of code stated inside the coroutine. ``` yield return``` in important in here, since it states how will it excecute specially if you want to make such coroutine wait some time in each loop.

```c#
	IEnumerator HacerCambio()
    	{
        	while (true)
        	{
            		yield return new WaitForSeconds(0.2f);
            		float distancia = Vector3.Distance(transform.position, path[currentNode].transform.position);
            		if(distancia < threshold) {
                		currentNode++;
                		currentNode %= path.Length;
             		}
        	}
    	}
```
In this case it will call the function WaitForSeconds, it is important to state the parameter as a float. 
### Patrolling

Patrolling consist in creating a series of Nodes that can only be visible for the programmer but not for the user. This nodes are used as a reference of a path that one object may follow. Each Node is connected with another only if he is the parent of the other node. The road points Parent Node in the direction to the Children (pNode --> chNode). Using the same piece of code as Coroutines but with a slight change:

```c#
	 public Node[] path;
	 void Update () {
		transform.LookAt(path[currentNode].transform); //The object rotates pointing at the objective Node
		transform.Translate(transform.forward*Time.deltaTime*5, Space.World); // //Moves to objective Node
	 }
	  IEnumerator HacerCambio()
	    {
		while (true)
		{
		    yield return new WaitForSeconds(0.2f);
		    float distancia = Vector3.Distance(transform.position, path[currentNode].transform.position);
		    if(distancia < threshold) {
			currentNode++;
			currentNode %= path.Length;
		     }
		}
	    }
```

With the array Node, one manages to store the Node's children, and since it is public, one can manually insert the children directly from Unity. Then, with a coroutine, the object will travel through all the nodes within the array. 

### GUI

### Input - keyboard / mouse o axes

A game is required to have interaction with the user, so it needs to know what the player is trying to do after a certain input.
The first thing to handle is if the main character is required to move by the player's commands. Unity has by default the Arrow keys to move left,up,down,right ;however, it also uses de AWSD keys to move respectively. In order to move around when the player inputs this keys, one needs to run:

```C# 
	float h = Input.GetAxis("Horizontal"); 
	float v = Input.GetAxis("Vertical");
	
	transform.Translate(h * velocidad * Time.deltaTime, v * velocidad * Time.deltaTime, 0,Space.World);
	//velocidad is an int variable, it alters the speed that such object will move in the axis. 
```
In this way, the object that runs the scipt can now move in x and y axes. As we mentioned, Unity has default keys that will perform a certain action such as going up, down or jump. One can modify this default keys; however, in code, one can call to this raw values.

```C#
	float j = Input.GetAxisRaw("Jump");
```
In this case, j works for the key that is used for the "Jump" action. The spacebar is defined as default. 

Another way of handling inputs is by the use of conditions, since the Keyboard has way more keys that the ones previously mentioned, plus a mouse could also trigger an action. A way to handle this is

```C#
       if (Input.GetKeyDown(KeyCode.A)) { //Only prints when A is pressed
            print("Key Down");
        }

        if(Input.GetKey(KeyCode.A)) { //While A is pressed 
            print("Just Key");
        }

        if (Input.GetKeyUp(KeyCode.A)) //Key released
        {
            print("Key Released");
        }

        if (Input.GetMouseButtonDown(0)) { //0 is left click
            print(Input.mousePosition);
        }
```
