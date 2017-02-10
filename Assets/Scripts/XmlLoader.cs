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
        //parseo de todos los nodos
        XmlNodeList vertexs = xmlDoc.GetElementsByTagName("vertex");
        foreach(XmlElement vertex in vertexs){
            //parseo de un nodo
            Node nodo = new Node();//esto no se puede si es una herencia de monobehavior, en su defecto debo buscar otra cosa
            nodo.id = int.Parse(vertex.GetAttribute("id"));
            //print(nodo.id);
            XmlNode val = vertex.SelectSingleNode("valid");
            //print(val.Attributes["value"].InnerXml);
            nodo.valid = val.Attributes["value"].InnerXml == "1";//funciona pere debe haber una mejor forma
            //print(nodo.valid);
            XmlNode xpos = vertex.SelectSingleNode("x-coordinate");
            nodo.x = float.Parse(xpos.Attributes["value"].InnerXml);//funciona pere debe haber una mejor forma
            XmlNode ypos = vertex.SelectSingleNode("y-coordinate");
            nodo.y = float.Parse(ypos.Attributes["value"].InnerXml);//funciona pere debe haber una mejor forma
            XmlNode parent = vertex.SelectSingleNode("parent");
            nodo.parent = int.Parse(parent.Attributes["value"].InnerXml);
            nodo.parentDistance = float.Parse(parent.Attributes["distance"].InnerXml);
            nodo.sons = new List<int>();
            nodo.sonsDistance = new List<float>();
            //para la lista de hijos
            XmlNodeList sons = vertex.GetElementsByTagName("son");
            foreach(XmlElement son in sons){
                nodo.sons.Add(int.Parse(son.GetAttribute("value")));
                nodo.sonsDistance.Add(float.Parse(son.GetAttribute("distance")));
            }
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
