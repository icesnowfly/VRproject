using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetAnimalName(string id)
    {
        string filePath = Application.dataPath + "/Resources/Animals.xml";
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("Animal").ChildNodes;
            Debug.Log("get nodes");
            foreach (XmlElement ele in node)
            {
                Debug.Log(ele.Name);
                if (ele.SelectSingleNode("id").InnerText == id)
                    return ele.SelectSingleNode("name").InnerText;
            }
        }
        return "123";
    }
}
