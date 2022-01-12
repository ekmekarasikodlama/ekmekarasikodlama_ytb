public GameObject wheelprefab;
    public WheelCollider[] colliders;
    List<GameObject> wheelModels = new List<GameObject>();
    public float maxTorque = 150;
    public float maxBreakTorque = 120;
    public float turnTorque = 50;
    public float positionDivider = 1;
    public Transform centerOfMass;

    public Renderer tankTrackRenderer;
    public AudioSource engineSound;
    public ParticleSystem[] engineSmokes;

    public float maxSpeed = 10;
    public float maxReverseSpeed = 4;
    public Rigidbody rigid;
    float currentSpeed;


    void Start()
    {
        instantiateWheels();
        rigid = GetComponent<Rigidbody>();
        if (centerOfMass != null)
        {
            rigid.centerOfMass = centerOfMass.position;
        }
    }

    void instantiateWheels()
    {
        foreach (WheelCollider collider in colliders)
        {
            Transform temp = Instantiate(wheelprefab, collider.transform, false).transform;
            temp.position -= collider.center;

        }
    }

    void updateWheelPos()
    {

        for (int wheel = 0; wheel < colliders.Length; wheel++)
        {
            Vector3 pos;
            Quaternion qor;


            colliders[wheel].GetWorldPose(out pos, out qor);

            colliders[wheel].transform.GetChild(1).position = Vector3.MoveTowards(colliders[wheel].transform.GetChild(1).position, pos, Time.deltaTime * 4);
            colliders[wheel].transform.GetChild(1).rotation = qor;

            pos += colliders[wheel].transform.up * -positionDivider;

            colliders[wheel].transform.GetChild(0).position = Vector3.MoveTowards(colliders[wheel].transform.GetChild(0).position, pos, Time.deltaTime * 4);
        }
    }

    private void FixedUpdate()
    {

        float forwardData = Input.GetAxis("Vertical");
        float rightData = Input.GetAxis("Horizontal");

        float effectiveTorque = forwardData * maxTorque;
        float effectiveTurn = rightData * turnTorque;


        rotateTank(effectiveTurn);
        moveTank(effectiveTorque);
        updateUI();

        updateEffects();
    }

    void updateUI()
    {
        if(TankUI.instance != null)
        TankUI.instance.updateSpeed((int)transform.InverseTransformDirection(rigid.velocity).z);
    }

    void moveTank(float effMove)
    {
        foreach (WheelCollider col in colliders)
        {
            currentSpeed = transform.InverseTransformDirection(rigid.velocity).z;

            if (effMove > 0)
            {
                if (currentSpeed < maxSpeed)
                {
                    col.motorTorque = effMove;

                }
                else
                {
                    col.motorTorque = 0;
                }
            }
            else if (effMove < 0)
            {
                if (currentSpeed > -maxReverseSpeed)
                {
                    col.motorTorque = effMove;

                }
                else
                {
                    col.motorTorque = 0;
                }
            }


            if (Input.GetKey(KeyCode.Space))
            {
                col.brakeTorque = maxBreakTorque;
            }
            else
            {
                col.brakeTorque = 0;
            }

        }

    }
    void updateEffects()
    {
        if (tankTrackRenderer != null)
        {
            tankTrackRenderer.materials[0].mainTextureOffset = new Vector2(0, rigid.velocity.magnitude * Time.deltaTime);
        }
        if (engineSound != null)
        {
            engineSound.pitch = 1 + Mathf.Abs(currentSpeed / maxSpeed);
        }
        foreach (ParticleSystem system in engineSmokes)
        {
            ParticleSystem.EmissionModule module = system.emission;
            module.rateOverTime = 3 + Mathf.Abs(currentSpeed / maxSpeed) * 10;
        }

    }

    void rotateTank(float effTurn)
    {
        Quaternion magicRotation = transform.rotation * Quaternion.AngleAxis(effTurn * Time.deltaTime, transform.up);
        rigid.MoveRotation(magicRotation);
        float apply = colliders[0].suspensionSpring.spring;
        if (effTurn > 0)
        {
            rigid.AddForceAtPosition(transform.up * apply, transform.position + transform.right * -3);
        }
        else if (effTurn < 0)
        {
            rigid.AddForceAtPosition(transform.up * apply, transform.position + transform.right * 3);
        }
        else
        {
            apply = 0;
        }


    }
    // Update is called once per frame
    void Update()
    {
        updateWheelPos();
    }
