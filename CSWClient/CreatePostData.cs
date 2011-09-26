using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.IO;

namespace ArcMapAddin1
{
    class CreatePostData
    {
        private string strPostData;
        private PostDataCriteria pPostDataCriteria;

        public string PostData
        {
            get
            { return strPostData; }
        }

        public void CreatXmlDoc(PostDataCriteria pPostDaCri)
        {
            pPostDataCriteria = pPostDaCri;

            try
            {
                StringBuilder pBuilder = new StringBuilder();

                pBuilder.Append("<csw:GetRecords xmlns:csw='http://www.opengis.net/cat/csw/2.0.2' version='2.0.2' service='CSW' resultType='results' ");

                StartPosition(pBuilder); ///Set the start position for request

                MaxResults(pBuilder); ///Set max number of results shown in the list box

                pBuilder.Append(">");

                pBuilder.Append("<csw:Query typeNames='csw:Record' xmlns:ogc='http://www.opengis.net/ogc' xmlns:gml='http://www.opengis.net/gml'>");
                pBuilder.Append("<csw:ElementSetName>");
                pBuilder.Append("full");
                pBuilder.Append("</csw:ElementSetName>");
                pBuilder.Append("<csw:Constraint version='1.1.0'>");
                pBuilder.Append("<ogc:Filter>");

                pBuilder.Append("<ogc:And>");

                SearchText(pBuilder); ///Set search criterias, including search key word and search area

                if (pPostDaCri.IsLiveDataOnly) { SearchForLiveDataOnly(pBuilder); } ///Define if only search live data
                if (pPostDaCri.IsWmsOnly) { SearchForWmsOnly(pBuilder); } ///Define if only search wms services
                
                BoundingBox(pBuilder); ///Set bounding box

                pBuilder.Append("</ogc:And>");

                pBuilder.Append("</ogc:Filter>");
                pBuilder.Append("</csw:Constraint>");
                pBuilder.Append("</csw:Query>");
                pBuilder.Append("</csw:GetRecords>");

                strPostData = pBuilder.ToString();
  
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void StartPosition(StringBuilder pBuilder)
        {
            pBuilder.Append("startPosition=");
            pBuilder.Append("'" + pPostDataCriteria.StartPosition + "'");
            pBuilder.Append(" ");

        }

        private void SearchText(StringBuilder pBuilder)
        {
            pBuilder.Append("<ogc:PropertyIsLike wildCard='*' escape='\' singleChar='?'>");
            pBuilder.Append("<ogc:PropertyName>");

            pBuilder.Append(pPostDataCriteria.QueryName);
            
            pBuilder.Append("</ogc:PropertyName>");
            pBuilder.Append("<ogc:Literal>");

            pBuilder.Append(pPostDataCriteria.SearchText);

            pBuilder.Append("</ogc:Literal>");
            pBuilder.Append("</ogc:PropertyIsLike>"); 
        }

        private void MaxResults(StringBuilder pBuilder)
        {
            pBuilder.Append("maxRecords='15'");
        }

        private void BoundingBox(StringBuilder pBuilder)
        {
            pBuilder.Append("<ogc:BBOX>");
            pBuilder.Append("<ogc:PropertyName>");
            pBuilder.Append("ows:BoundingBox");
            pBuilder.Append("</ogc:PropertyName>");
            pBuilder.Append("<gml:Envelope>");
            pBuilder.Append("<gml:lowerCorner>");

            pBuilder.Append(pPostDataCriteria.Envelope.MinX.ToString() + " " + pPostDataCriteria.Envelope.MinY.ToString());    
            //pBuilder.Append("-118.3 32.1");
            pBuilder.Append("</gml:lowerCorner>");
            pBuilder.Append("<gml:upperCorner>");
            pBuilder.Append(pPostDataCriteria.Envelope.MaxX.ToString() + " " + pPostDataCriteria.Envelope.MaxY.ToString());
            //pBuilder.Append("-87.1 45.2");
            pBuilder.Append("</gml:upperCorner>");
            pBuilder.Append("</gml:Envelope>");
            pBuilder.Append("</ogc:BBOX>");            
        }

        private void SearchForWmsOnly(StringBuilder pBuilder)
        {
            pBuilder.Append("<ogc:PropertyIsEqualTo>");
            pBuilder.Append("<ogc:PropertyName>apiso:ServiceType</ogc:PropertyName>");
            pBuilder.Append("<ogc:Literal>wms</ogc:Literal>");
            pBuilder.Append("</ogc:PropertyIsEqualTo>");
        }

        private void SearchForLiveDataOnly(StringBuilder pBuilder)
        {
            pBuilder.Append("<ogc:PropertyIsEqualTo>");
            pBuilder.Append("<ogc:PropertyName>Type</ogc:PropertyName>");
            pBuilder.Append("<ogc:Literal>liveData</ogc:Literal>");
            pBuilder.Append("</ogc:PropertyIsEqualTo>");
        }

        
    }

}
