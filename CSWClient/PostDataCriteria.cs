using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcMapAddin1
{
    class PostDataCriteria
    {
        private string _maxRecords;
        private string _searchText;
        private Boolean _isLiveDataAndMapOnly;
        private Envelope _envelope;

        public string MaxRecords
        {
            set { _maxRecords = value; }
            get { return _maxRecords; }
        }

        public string SearchText
        {
            set { _searchText = value; }
            get { return _searchText; }
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
