using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcMapAddin1
{
    class PageSwitchCriteria
    {
        private int _startPosition;
        private int _numPages;
        private int _currentPage;

        public int StartPosition
        {
            set { _startPosition = value; }
            get { return _startPosition; }
        }

        public int NumPages
        {
            set { _numPages = value; }
            get { return _numPages; }
        }

        public int CurrentPage
        {
            set { _currentPage = value; }
            get { return _currentPage; }
        }

    }
}
