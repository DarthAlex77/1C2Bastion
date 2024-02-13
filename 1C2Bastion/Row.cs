using System.Collections.Generic;
using System.Xml.Serialization;

namespace _1C2Bastion
{
    [XmlRoot(ElementName = "Document")]
    public class Document
    {
        [XmlElement(ElementName = "ROW")]
        public List<Row> Rows { get; set; } = new List<Row>();
    }

    [XmlRoot(ElementName = "ROW")]
    public class Row
    {
        [XmlElement(ElementName = "PASSTYPE")]
        public string PassType { get; set; }

        [XmlElement(ElementName = "NAME")]
        public string Name { get; set; }

        [XmlElement(ElementName = "FIRSTNAME")]
        public string FirstName { get; set; }

        [XmlElement(ElementName = "SECONDNAME")]
        public string SecondName { get; set; }

        [XmlElement(ElementName = "TABLENO")]
        public string TableNo { get; set; }

        [XmlElement(ElementName = "WDEP2")]
        public string Department { get; set; }

        [XmlElement(ElementName = "POST")]
        public string Post { get; set; }

        [XmlElement(ElementName = "DOCTYPE")]
        public string DocType { get; set; }

        [XmlElement(ElementName = "DOCSER")]
        public string DocSer { get; set; }

        [XmlElement(ElementName = "DOCNO")]
        public string DocNo { get; set; }

        [XmlElement(ElementName = "DOCISSUEORGAN")]
        public string DocIssueOrgan { get; set; }

        [XmlElement(ElementName = "ADDRESS")]
        public string Address { get; set; }

        [XmlElement(ElementName = "BIRTHPLACE")]
        public string Birthplace { get; set; }

        [XmlElement(ElementName = "SITIZENSHIP")]
        public string Citizenship { get; set; }

        [XmlElement(ElementName = "SEX")]
        public string Sex { get; set; }

        [XmlElement(ElementName = "DOCISSUEDATE")]
        public string DocIssueDate { get; set; }

        [XmlElement(ElementName = "BIRTHDATE")]
        public string Birthdate { get; set; }
    }
}