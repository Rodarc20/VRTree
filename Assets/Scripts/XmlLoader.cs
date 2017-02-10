using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class XmlLoader : MonoBehaviour {
    private string fileName;
    private XmlDocument xmlDoc;
    List<Node> nodos;
    // Use this for initialization
    void loadXML(){
        xmlDoc = new XmlDocument();
        if(System.IO.File.Exists(getPath())){
            xmlDoc.LoadXml(System.IO.File.ReadAllText(getPath()));
        }
        else{
            TextAsset textXml = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
            xmlDoc.LoadXml(textXml.text);
        }
    }
    string getPath(){
        #if UNITY_EDITOR
        return Application.dataPath +"/Resources/"+fileName;
        #elif UNITY_ANDROID
        return Application.persistentDataPath+fileName;
        #elif UNITY_IPHONE
        return GetiPhoneDocumentsPath()+"/"+fileName;
        #else
        return Application.dataPath +"/"+ fileName;
        #endif
    }

    void load(){
        //primero crear los nodos
        XmlNodeList vertexs = xmlDoc.GetElementsByTagName("vertex");
        foreach(XmlElement vertex in vertexs){
            Node nodo = new Node();
            nodo.id = int.Parse(vertex.GetAttribute("id"));
            //print(nodo.id);
            XmlNode val = vertex.SelectSingleNode("valid");
            //print(val.Attributes["value"].InnerXml);
            nodo.valid = val.Attributes["value"].InnerXml == "1";//funciona pere debe haber una mejor forma
            //print(nodo.valid);
            /*XmlNodeList valids = vertex.GetElementsByTagName("valid");
            foreach(XmlElement valid in valids){
                nodo.valid = bool.Parse(valid.GetAttribute("value"));
            }*/
            //imprimir cada nodo para ver el resultado
        }


    }
    void Start () {
        fileName = "cbr-ilp-ir-son.xml";
        loadXML();
        load();
    }
    
    // Update is called once per frame
    void Update () {
    
    }
    
}
