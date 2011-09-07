using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcMapAddin1
{
    class ListDataModel
    {
        private string strMetadataUrl;
        private string strTitle;

        public string MetadataUrl
        {
            set
            { strMetadataUrl = value; }
            get
            { return strMetadataUrl; }
        }

        public string Title
        {
            set
            { strTitle = value; }
            get
            { return strTitle; }
        }
    }
}
