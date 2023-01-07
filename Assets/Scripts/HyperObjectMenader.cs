using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public struct Vector6
{
   public float x, y, z, w, h, p;
    public Vector6(float x, float y, float z, float w, float h, float p)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
        this.h = h;
        this.p = p;
    }
}

[System.Serializable]
public class HRM
{
    [SerializeField] public List<Vector4> pos = new List<Vector4>();
    [SerializeField] public List<Vector4> scale = new List<Vector4>();
    [SerializeField] public List<Vector6> rot = new List<Vector6>();
    [SerializeField] public List<Color> color = new List<Color>();
    [SerializeField] public List<Shape4D.ShapeType> shapeTypes = new List<Shape4D.ShapeType>();
    [SerializeField] public List<Shape4D.Operation> Operations = new List<Shape4D.Operation>();
    [SerializeField] public List<float> Blend = new List<float>();
    [SerializeField] public List<int> parent = new List<int>();
}

public class HyperObjectMenader : MonoBehaviour
{
    HyperObject[] s;
    public Dropdown dd;
    public InputField um;
    public GameObject loader;
    public int curcount;
    public int oldcount;
    bool p;
    private void Start()
    {
        Directory.CreateDirectory("C:/Unauticna Multiverse");
    }
    void edit()
    {
        curcount = FindObjectsOfType<HyperObject>().Length;
        s = FindObjectsOfType<HyperObject>();
        if (curcount != oldcount)
        {
            for (int i = 0; i < FindObjectsOfType<objs>().Length; i++)
            {
                FindObjectsOfType<objs>()[i].gameObject.AddComponent<DELETE>();
            }
            for (int i = 0; i < s.Length; i++)
            {
               GameObject g = Instantiate(Resources.Load<GameObject>("obj"), transform);
                g.GetComponent<objs>().material = s[i];
            }
        }
      if(true) oldcount = curcount;
    }

    public void save()
    {
        p = false;
        loader.SetActive(true);
        s = FindObjectsOfType<HyperObject>();
        HRM hrm = new HRM();
        int i = 0;
        foreach (HyperObject hyperObject in s)
        {
            i++;
            Shape4D r = hyperObject.obj;
            hrm.color.Add(hyperObject.c);
            hrm.pos.Add(r.Position());
            hrm.rot.Add(r.Rotmy());
            hrm.scale.Add(r.Scalemy());
            hrm.shapeTypes.Add(r.shapeType);
            hrm.Operations.Add(r.operation);
            hrm.Blend.Add(r.smoothRadius);
            // if(r.numChildren > 0) hrm.parent.Add(i);
        }
        File.WriteAllText("test.hrm", JsonUtility.ToJson(hrm));
    }
    public void loadstart()
    {
        load();
    }
    public bool load()
    {
        p = true;

        loader.SetActive(true);

        if (File.Exists("test.hrm"))
        {
            for (int i = 0; i < FindObjectsOfType<HyperObject>().Length; i++)
            {
                FindObjectsOfType<HyperObject>()[i].gameObject.AddComponent<DELETE>();
            }
            for (int i = 0; i < FindObjectsOfType<objs>().Length; i++)
            {
                FindObjectsOfType<objs>()[i].gameObject.AddComponent<DELETE>();
            }
            HRM hrm = JsonUtility.FromJson<HRM>(File.ReadAllText("test.hrm"));
            for (int i = 0; i < hrm.color.Count; i++)
            {
                GameObject s = Instantiate(Resources.Load<GameObject>("Hyper_object"), new Vector3(hrm.pos[i].x, hrm.pos[i].y, hrm.pos[i].z), Quaternion.identity);
                Shape4D t = s.GetComponent<Shape4D>();
                t.operation = hrm.Operations[i];
                t.GetComponent<HyperObject>().c = hrm.color[i];
                t.scaleW = hrm.scale[i].w;
                t.positionW = hrm.pos[i].w;
                t.rotationW = new Vector3(hrm.rot[i].w, hrm.rot[i].h, hrm.rot[i].p);
                t.shapeType = hrm.shapeTypes[i];
                t.smoothRadius = hrm.Blend[i];
                t.transform.localScale = new Vector3(hrm.scale[i].x, hrm.scale[i].y, hrm.scale[i].z);
                t.transform.rotation = Quaternion.Euler(new Vector3(hrm.rot[i].x, hrm.rot[i].y, hrm.rot[i].z));

            }

        }

        return true;
    }
    public void loadname()
    {





        loader.SetActive(false);

    }
    public void savename()
    {
        if (p)
        {

            if (File.Exists("C:/Unauticna Multiverse/" + um.text + ".hrm"))
            {
                for (int i = 0; i < FindObjectsOfType<HyperObject>().Length; i++)
                {
                    FindObjectsOfType<HyperObject>()[i].gameObject.AddComponent<DELETE>();
                }
                for (int i = 0; i < FindObjectsOfType<objs>().Length; i++)
                {
                    FindObjectsOfType<objs>()[i].gameObject.AddComponent<DELETE>();
                }
                HRM hrm = JsonUtility.FromJson<HRM>(File.ReadAllText("C:/Unauticna Multiverse/" + um.text + ".hrm"));
                for (int i = 0; i < hrm.color.Count; i++)
                {
                    GameObject s = Instantiate(Resources.Load<GameObject>("Hyper_object"), new Vector3(hrm.pos[i].x, hrm.pos[i].y, hrm.pos[i].z), Quaternion.identity);
                    Shape4D t = s.GetComponent<Shape4D>();
                    t.operation = hrm.Operations[i];
                    t.GetComponent<HyperObject>().c = hrm.color[i];
                    t.scaleW = hrm.scale[i].w;
                    t.positionW = hrm.pos[i].w;
                    t.rotationW = new Vector3(hrm.rot[i].w, hrm.rot[i].h, hrm.rot[i].p);
                    t.shapeType = hrm.shapeTypes[i];
                    t.smoothRadius = hrm.Blend[i];
                    t.transform.localScale = new Vector3(hrm.scale[i].x, hrm.scale[i].y, hrm.scale[i].z);
                    t.transform.rotation = Quaternion.Euler(new Vector3(hrm.rot[i].x, hrm.rot[i].y, hrm.rot[i].z));

                }

            }
        }
        if (!p)
        {



          
            s = FindObjectsOfType<HyperObject>();
            HRM hrm = new HRM();
            int i = 0;
            foreach (HyperObject hyperObject in s)
            {
                i++;
                Shape4D r = hyperObject.obj;
                hrm.color.Add(hyperObject.c);
                hrm.pos.Add(r.Position());
                hrm.rot.Add(r.Rotmy());
                hrm.scale.Add(r.Scalemy());
                hrm.shapeTypes.Add(r.shapeType);
                hrm.Operations.Add(r.operation);
                hrm.Blend.Add(r.smoothRadius);
                // if(r.numChildren > 0) hrm.parent.Add(i);
            }
            File.WriteAllText("C:/Unauticna Multiverse/" + um.text + ".hrm", JsonUtility.ToJson(hrm));
           
        }

        loader.SetActive(false);
    }

    public void canel()
    {

        loader.SetActive(false);
    }
    public void Create()
    {
        if (dd.value == 0)
        {
            GameObject s = Instantiate(Resources.Load<GameObject>("Hyper_object"), new Vector3(0, 2, 0), Quaternion.identity);
            selectedHyperObject.ho = s.GetComponent<HyperObject>();
          
        }
        if (dd.value == 1)
        {
            GameObject s = Instantiate(Resources.Load<GameObject>("Hyper_cube"), new Vector3(0, 2, 0), Quaternion.identity);
            selectedHyperObject.ho = s.GetComponent<HyperObject>();
           
        }
        if (dd.value == 2)
        {
            GameObject s = Instantiate(Resources.Load<GameObject>("Hyper_DuoCylinder"), new Vector3(0, 2, 0), Quaternion.identity);
            selectedHyperObject.ho = s.GetComponent<HyperObject>();
            
        }
        if (dd.value == 3)
        {
            GameObject s = Instantiate(Resources.Load<GameObject>("Hyper_fivecel"), new Vector3(0, 2, 0), Quaternion.identity);
            selectedHyperObject.ho = s.GetComponent<HyperObject>();
           
        }
        if (dd.value == 4)
        {
            GameObject s = Instantiate(Resources.Load<GameObject>("Hyper_sixtencell"), new Vector3(0, 2, 0), Quaternion.identity);
            selectedHyperObject.ho = s.GetComponent<HyperObject>();
           
        }
        
    }

    void Update()
    {
        edit();


    }
}
