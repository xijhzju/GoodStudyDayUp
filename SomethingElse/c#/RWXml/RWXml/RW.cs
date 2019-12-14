using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace RWXml
{
    class RW
    {
        public static void Write()
        {
            XmlDocument xDoc = new XmlDocument();
            XmlDeclaration declaration = xDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xDoc.AppendChild(declaration);//添加声明行
            XmlElement elem = xDoc.CreateElement("students");//创建节点
            xDoc.AppendChild(elem);//添加根节点

            Random ran = new Random();
            for (int i = 0; i < 10; i++)
            {
                XmlElement elem1 = xDoc.CreateElement("student");
                elem.AppendChild(elem1);//在根节点下增加子节点
                elem1.SetAttribute("学号", (i + 1).ToString());//设置节点属性
                XmlElement elem1_Chinese = xDoc.CreateElement("语文成绩");
                elem1.AppendChild(elem1_Chinese);
                elem1_Chinese.InnerText = ran.Next(100).ToString();//设置节点内容
                XmlElement elem1_Math = xDoc.CreateElement("数学成绩");
                elem1.AppendChild(elem1_Math);
                elem1_Math.InnerText = ran.Next(100).ToString();
            }


            xDoc.Save("students.xml");//保存XML文件
        }

        public static void Read()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("students.xml");//导入xml文件

            XmlNode node1 = xDoc.SelectSingleNode("students");//根节点students
            XmlNodeList node1Children = node1.ChildNodes;//获取子节点

            foreach (XmlNode item in node1Children)
            {
                XmlElement elme = (XmlElement)item;

                string id = elme.GetAttribute("学号");
                Console.WriteLine($"------{item.Name} ID：{id}------");
                
                foreach (XmlNode xn in item.ChildNodes)
                {
                    Console.Write(xn.Name+": ");
                    XmlElement xn_elem = (XmlElement)xn;
                    Console.WriteLine(xn_elem.InnerText);
                    if (id=="4"&&xn.Name=="语文成绩")//学号为4，语文成绩改成100
                    {
                        xn_elem.InnerText = "100";
                    }
                }
            }
            xDoc.Save("students.xml");
        }
    }

}
