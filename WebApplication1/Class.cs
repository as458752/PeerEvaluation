using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeerEvaluation
{
    public class Class
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private bool infoAvailable;

        public bool InfoAvailable
        {
            get { return infoAvailable; }
            set { infoAvailable = value; }
        }

        private string creatorID;

        public string CreatorID
        {
            get { return creatorID; }
            set { creatorID = value; }
        }

        public Class(string name, string creatorID, bool infoAvailable)
        {
            this.name = name;
            this.creatorID = creatorID;
            this.infoAvailable = infoAvailable;
        }

        

    }
}