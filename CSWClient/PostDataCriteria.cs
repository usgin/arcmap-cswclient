using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcMapAddin1
{
    class PostDataCriteria
    {
        private string _maxRecords;
        private string _serviceType;
        private string _queryName;
        private string _searchText;
        private string _abstract;
        private Boolean _isLiveDataAndMapOnly;
        private Envelope _envelope;

        public string MaxRecords
        {
            set { _maxRecords = value; }
            get { return _maxRecords; }
        }

        public string ServiceType
        {
            set { _serviceType = value; }
            get { return _serviceType; }
        }

        public string QueryName
        {
            set { _queryName = value; }
            get { return _queryName; }
        }

        public string SearchText
        {
            set { _searchText = value; }
            get { return _searchText; }
        }

        public string Abstract
        {
            set { _abstract = value; }
            get { return _abstract; }
        }

        public Boolean IsLiveDataAndMapOnly
        {
            set { _isLiveDataAndMapOnly = value; }
            get { return _isLiveDataAndMapOnly; }
        }

        public Envelope Envelope
        {
            set { _envelope = value; }
            get { return _envelope; }
        }

    }
}
