using OperationXML.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Linq;




namespace OperationXML.DAL
{
    public class BookDal
    {
        static string strPath = "Book.xml";
        public void CreatBookInfo(BookModel _bookmodel)
        {
            XmlDocument doc = new XmlDocument();  //实例化XmlDocument对象
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null); //XML头
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("bookstore");         //根节点
            doc.AppendChild(root);
            XmlElement xml0 = doc.CreateElement("book");              //子根节点
            xml0.SetAttribute("课程类型", _bookmodel.BookType);        //设置属性。由UI端写入数据。
            xml0.SetAttribute("编号", Convert.ToString(_bookmodel.BookID));
            XmlElement xml1 = doc.CreateElement("书名");//创建一个书名节点  
            xml1.InnerText = _bookmodel.BookName;          
            xml0.AppendChild(xml1);//添加  
            XmlElement xml2 = doc.CreateElement("作者");//创建作者节点  
            xml2.InnerText = _bookmodel.BookAuthor;
            xml0.AppendChild(xml2);//添加  
            XmlElement xml3 = doc.CreateElement("价格");//创建一个价格节点  
            xml3.InnerText = _bookmodel.BookPrice;
            xml0.AppendChild(xml3);//添加           
            root.AppendChild(xml0);
            doc.Save("Book.xml");
        }      //创建


        public DataSet LoadBookInfo()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(strPath);
            return ds;
        }         //加载到datagridview中

        public void AddBookInfo(BookModel _bookmodel)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Book.xml");
            XmlNode root = doc.SelectSingleNode("bookstore");

            XmlElement xelKey = doc.CreateElement("book");

            XmlAttribute a = doc.CreateAttribute("课程类型");
            a.InnerText = _bookmodel.BookType;
            xelKey.SetAttributeNode(a);

            XmlAttribute b = doc.CreateAttribute("编号");
            b.InnerText = Convert.ToString(_bookmodel.BookID);
            xelKey.SetAttributeNode(b);

            XmlElement c = doc.CreateElement("书名");
            c.InnerText = _bookmodel.BookName;
            xelKey.AppendChild(c);

            XmlElement d = doc.CreateElement("作者");
            d.InnerText = _bookmodel.BookAuthor;
            xelKey.AppendChild(d);

            XmlElement e = doc.CreateElement("价格");
            e.InnerText = _bookmodel.BookPrice;
            xelKey.AppendChild(e);
            root.AppendChild(xelKey);
            doc.Save("Book.xml");

        }  //增加

        public void DeleteBookInfo(string a)
        {
            XElement xe = XElement.Load("Book.xml");
            IEnumerable<XElement> elements = from ele in xe.Elements("book")
                                             where ele.Attribute("编号").Value == a
                                             select ele;
            if (elements.Count() > 0)
            {
                elements.First().Remove();
            }
            xe.Save("Book.xml");
        }      //删除

        public void UpdateBookInfo(BookModel a)
        {
            XElement xe = XElement.Load("Book.xml");
            IEnumerable<XElement> element = from ele in xe.Elements("book")
                                            where ele.Attribute("编号").Value == Convert.ToString(a.BookID)
                                            select ele;
            if (element.Count() > 0)
            {
                XElement first = element.First();
                //设置新的属性
                first.SetAttributeValue("课程类型", a.BookType);
                first.SetAttributeValue("编号", a.BookID);
                //替换新的节点
                first.ReplaceNodes(
                       new XElement("书名", a.BookName),
                       new XElement("作者", a.BookAuthor),
                       new XElement("价格", a.BookPrice)
                      );
            }
            xe.Save("Book.xml");
        }   //更改

        public List<BookModel> QueryBookInfo(int intFalg,string c)
        {
            List<BookModel> bookList = new List<BookModel>();

            XElement xml = XElement.Load(strPath);

            var bookVar = xml.Descendants("book");   //默认查询所有图书  

            switch (intFalg) {
                case 1: //"根据编号查询"
                bookVar = xml.Descendants("book").Where(a => a.Attribute("编号").Value ==c); //c由UI端写入数据传到这儿
                break;

                case 2://"根据书名查询"
                bookVar = xml.Descendants("book").Where(a => a.Element("书名").Value == c);
                break;

                case 3://"根据作者查询"
                bookVar = xml.Descendants("book").Where(a => a.Element("作者").Value == c);
                break;
            }

            bookList = (from book in bookVar
                        select new BookModel
                        {
                            BookID = int.Parse(book.Attribute("编号").Value),
                            BookType = book.Attribute("课程类型").Value,
                            BookName = book.Element("书名").Value,
                            BookAuthor = book.Element("作者").Value,
                            BookPrice = book.Element("价格").Value,                        
                        }).ToList();
            return bookList;
        }  //查询

        //#region 序列化
        ////序列化实例Xml
        //public  bool SerializeXml<T>(string Txt, T obj)
        //{
        //    try
        //    {
        //        XmlSerializer xe = new XmlSerializer(typeof(Model.Person));
        //        using (Stream se = new FileStream(Txt, FileMode.Create, FileAccess.Write, FileShare.None))
        //        {
        //            xe.Serialize(se, obj);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine(ex.ToString());
        //        return false;
        //    }
        //    return true;
        //}
        ////反序列化
        //public static T DeserializeFromXml<T>(string Txt)
        //{
        //    using (Stream red = new FileStream(Txt, FileMode.Open, FileAccess.Read, FileShare.Read))
        //    {
        //        XmlSerializer xs = new XmlSerializer(typeof(T));
        //        red.Position = 0;
        //        T d = (T)xs.Deserialize(red);
        //        return d;
        //    }
        //}
        //#endregion 序列化

    }
}

