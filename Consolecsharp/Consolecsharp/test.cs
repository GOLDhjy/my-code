using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Consolecsharp
{
    [Serializable]
    public struct log
    {

        [XmlElement("logentry")]
        public List<logentry> Logentrie;
        //public log(Int32 i)
        //{
        //    Logentrie = new[] {
        //           new logentry("abc"),
        //           new logentry("xyz")
        //       };
        //}
    }
    [Serializable]
    public struct logentry
    {
        private string revision;

        [XmlElement("author")]
        public string author;
        [XmlElement("date")]
        public string date;
        [XmlElement("paths")]
        public paths paths;
        //public path[] Paths;
        [XmlElement("msg")]
        public string msg;
        [XmlAttribute("revision")]
        public string Revision { get => revision; set => revision = value; }

        //public logentry(string str)
        //{
        //    Author = str;
        //    Date = str;
        //    Msg = str;
        //    revision = str;
        //    Paths = new[] {
        //        new path("def"),
        //        new path("eee")
        //    };
        //}
    }
    [Serializable]
    public struct paths
    {
        [XmlElement("path")]
        public List<path> path;
    }
    [Serializable]
    public struct path
    {
        private string textmods;
        private string kind;
        private string action;
        private string propmods;
        [XmlText]
        public string value;
        [XmlAttribute("text-mods")]
        public string Textmods { get => this.textmods; set => this.textmods = value; }
        [XmlAttribute("kind")]
        public string Kind { get => this.kind; set => this.kind = value; }
        [XmlAttribute("action")]
        public string Action { get => this.action; set => this.action = value; }
        [XmlAttribute("prop-mods")]
        public string Propmods { get => this.propmods; set => this.propmods = value; }
        //public path(string str)
        //{
        //    textmods = str;
        //    kind = str;
        //    action = str;
        //    propmods = str;
        //    value = str;
        //}
    }
}
