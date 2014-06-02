using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geometry;

namespace ArcMapAddin1
{
    class PostDataCriteria
    {
        private string _startPosition;
        private string _maxRecords;
        private string _serviceType;
        private string _queryName;
        private string _searchText;
        private string _abstract;
        private Boolean _isLiveDataOnly;
        private Boolean _isWmsOnly;
        private Envelope _envelope;
        private Boolean _switchXY;

        public string StartPosition
        {
            set { _startPosition = value; }
            get { return _startPosition; }
        }
        
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

        public Boolean IsLiveDataOnly
        {
            set { _isLiveDataOnly = value; }
            get { return _isLiveDataOnly; }
        }

        public Envelope Envelope
        {
            set { _envelope = value; }
            get { return _envelope; }
        }

        public Boolean IsWmsOnly
        {
            set { _isWmsOnly = value; }
            get { return _isWmsOnly; }
        }

        public Boolean SwitchXY
        {
            set { _switchXY = value; }
            get { return _switchXY; }
        }

    }
}
