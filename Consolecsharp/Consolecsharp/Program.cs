using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Threading;

namespace Consolecsharp
{
    [Serializable]
    public class Person
    {
        private string name;
        public string Sex;
        public int Age = 22;
        public Course[] Courses;

        [XmlAttribute("name")]
        public string Name { get => name; set => name = value; }

        public Person()
        {
        }
        public Person(string Name)
        {
            this.Name = Name;
            Sex = "男";
        }
    }

    [Serializable]
    public class Course
    {
        public string Name;
        //[XmlIgnore]
        public string Description;
        public Course()
        {
        }
        public Course(string name, string description)
        {
            Name = name;
            Description = description;
        }
        static public void XMLSerialize()
        {
            Person c = new Person("HJY");
            c.Courses = new Course[2];
            c.Courses[0] = new Course("英语", "交流工具");
            c.Courses[1] = new Course("数学", "自然科学");
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            Stream stream = new FileStream(@"D:\TEST.XML", FileMode.Create, FileAccess.Write, FileShare.Read);
            xs.Serialize(stream, c);
            stream.Close();
        }
        public void XMLDeserialize()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            Stream stream = new FileStream(@"D:\TEST.XML", FileMode.Open, FileAccess.Read, FileShare.Read);
            Person p = xs.Deserialize(stream) as Person;
            Console.Write(p.Name);
            Console.Write(p.Age.ToString());
            Console.Write(p.Courses[0].Name);
            Console.Write(p.Courses[0].Description);
            Console.Write(p.Courses[1].Name);
            Console.Write(p.Courses[1].Description);
            stream.Close();
        }
        static void Main(string[] args)
        {
            //XMLSerialize();
            //log MyLog = new log(1);
            //using (FileStream file = new FileStream(@"D:\Out.Xml", FileMode.Create, FileAccess.Write))
            //{
            //    XmlSerializer Serializer = new XmlSerializer(typeof(log));
            //    Serializer.Serialize(file, MyLog);
            //}  
            using (FileStream file = new FileStream(@"C:\Users\kingsoft\Desktop\Repo\result.xml", FileMode.OpenOrCreate, FileAccess.Read))
            {
                log MyLog;
                XmlSerializer Serializer = new XmlSerializer(typeof(log));
                MyLog = (log)Serializer.Deserialize(file);
                foreach (logentry i in MyLog.Logentrie)
                    Console.Write("\nRevision:" + i.Revision + "\n作者:" + i.author + "\n时间:" + i.date + "\n消息:" + i.msg + "\n路径:" + i.paths.path[0].value);
                using (FileStream fileout = new FileStream(@"D:\Out.Xml", FileMode.Create, FileAccess.Write))
                {
                    Serializer.Serialize(fileout, MyLog);
                }
            }
            Console.ReadKey();
        }

    }
    // Signature specifies Task<TResult>  


    //    [Serializable]
    //public class MyData
    //{
    //    public string Name="hjy";
    //    public string url="baidu";
    //    public int Num=22;
    //};
    //[Serializable]
    //public struct n
    //{
    //    public string name;
    //    public string score;
    //}
    //public  delegate void MessageHandler(string message);
    //public class test1
    //{
    //    public event MessageHandler messagerarrived;
    //    public test1()
    //    {

    //    }
    //    public void showmsg()
    //    {
    //        if (messagerarrived != null)
    //            messagerarrived("消息来了");
    //    }

    //}
    //class test2
    //{
    //    public void display_message(string m) => Console.WriteLine(m);

    //}
    //class Program
    //{

    //    //enum orientation : byte
    //    //{
    //    //    a,
    //    //    b,
    //    //    c,
    //    //    d
    //    //}
    //    public static Program p = new Program();
    //    public  void play()
    //    {
    //        Console.WriteLine("###");
    //    }

    //    static void Main(string[] args)
    //    {

    //        test1 x = new test1();
    //        test2 x2 = new test2();
    //        x.messagerarrived += new MessageHandler(x2.display_message);
    //        test1 x3 = new test1();
    //        x.showmsg();

    //        var myarray = new[] {4 , 3 , 2 };
    //        foreach(var num in myarray)
    //        {
    //            Console.WriteLine(num);
    //        }
    //        string st=string.Empty;
    //        int[] arr = new int[3];
    //        Array[] arr2 = new Array[3];
    //        if(arr2[0]==null)
    //        {
    //            Console.WriteLine($"arr2 is null");
    //        }
    //        if (st == string.Empty)
    //            Console.WriteLine("null");
    //        // Console.WriteLine(iii);
    //        Console.ReadKey();
    //       // Console.WriteLine(st.Length);




    //List<n> myDataList = new List<n>();
    //int j;
    //n[] nn = new n[3];
    //for (j = 0; j < 3; j++)
    //{
    //    nn[j].name = j.ToString();
    //    nn[j].score = Convert.ToString(((3 - j) * 10));
    //}
    //for (j = 0; j < 3; j++)
    //{
    //    myDataList.Add(nn[j]);
    //}

    //MyData mydate = new MyData();

    //try
    //{
    //    XmlSerializer writer = new XmlSerializer(myDataList.GetType());
    //    FileStream file = new FileStream(@"D:\DATA.XML",FileMode.Create,FileAccess.Write,FileShare.Write);
    //    writer.Serialize(file, myDataList);
    //    file.Close();
    //}
    //catch (Exception e)
    //{
    //    Console.WriteLine($"{e.Message},{e.Data}");
    //}

    //n nnn = new n();
    //int j;

    //List<n> list = new List<n>();
    //list.Add(nnn);

    //XmlSerializer myserializer = new XmlSerializer(list.GetType());
    //StreamWriter mywriter = new StreamWriter(@"D:\myxml.xml");
    //myserializer.Serialize(mywriter, list);
    //mywriter.Close();


    //var query = from item in nn orderby item.score select item;

    //foreach (var p in query)
    //{
    //    Console.WriteLine($"{ p.name}:{p.score}");
    //    //Console.WriteLine($"{p.name}:{p.score}");
    //}



    //Console.WriteLine($"{nn.name}:{nn.score}");
    //Console.WriteLine($"{args[0]}");
    //string[] mystring = new string[2] { "111", "222" };
    //foreach (string numb in mystring)
    //{
    //    Console.WriteLine($"数字是{numb}");
    //}

    //string str = "name;level";

    //string[] strs = str.Split(';');
    //foreach (string str2 in strs)
    //{
    //    Console.WriteLine(str2);
    //    Console.WriteLine($"{str2}");
    //}
    //int i;
    //string test;
    //for (i = 0; i < 2; i++)
    //{
    //    test = "line " + i.ToString();
    //    Console.WriteLine($"{test}");
    //}
    //Console.WriteLine($"{i}");
    //orientation o = orientation.a;
    //Console.WriteLine(o);
    //decimal f = 0.15145681351m;
    //Console.WriteLine(f.GetHashCode());
    //int ii = Convert.ToInt32(f);
    //Console.WriteLine(ii);
    //Console.WriteLine(Console.Read());
    //Console.ReadKey();







    //nn= ("1", "2", "2", "5", "3", "1" );
}
//    }
//}
