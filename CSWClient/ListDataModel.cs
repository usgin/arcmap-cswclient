using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcMapAddin1
{
    class ListDataModel
    {
        private string strMetadataId;
        private string strTitle;
        private string strSvrUrl;
        private string strAbstract;
        private string strSvicType;

        public string MetadataId
        {
            set
            { strMetadataId = value; }
            get
            { return strMetadataId; }
        }

        public string Title
        {
            set
            { strTitle = value; }
            get
            { return strTitle; }
        }

        public string Abstract
        {
            set
            { strAbstract = value; }
            get
            { return strAbstract; }
        }

        public string SvrUrl
        {
            set
            { strSvrUrl = value; }
            get
            { return strSvrUrl; }
        }

        public string SvicType
        {
            set
            { strSvicType = value; }
            get
            { return strSvicType; }
        }

    }
}
