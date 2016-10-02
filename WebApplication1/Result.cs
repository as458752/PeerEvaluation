using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PeerEvaluation
{
    [Serializable]
    [XmlRoot("Objects")]
    public class Result : ICollection
    {
        [XmlArray("Items")]
        public Part[] parts;

        public Part this[int index]
        {
            get { return (Part)parts[index]; }
        }

        public int Count
        {
            get
            {
                return parts.Length;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Array array, int index)
        {
            parts.CopyTo(array, index);
        }

        public IEnumerator GetEnumerator()
        {
            return parts.GetEnumerator();
        }

        public void Add(Part newItems)
        {
            if (this.parts == null)
            {
                this.parts = new Part[1];
            }
            else
            {
                Array.Resize(ref this.parts, this.parts.Length + 1);
            }
            this.parts[this.parts.GetUpperBound(0)] = newItems;

        }
    }
    public class Part
    {
        [XmlAttribute("score")]
        public string score;
        [XmlAttribute("answer")]
        public string answer;
    }
}