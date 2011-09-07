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

                pBuilder.Append("<csw:GetRecords xmlns:csw='http://www.opengis.net/cat/csw/2.0.2' version='2.0.2' service='CSW' resultType='results' startPosition='1' maxRecords='10'>");
                pBuilder.Append("<csw:Query typeNames='csw:Record' xmlns:ogc='http://www.opengis.net/ogc' xmlns:gml='http://www.opengis.net/gml'>");
                pBuilder.Append("<csw:ElementSetName>");
                pBuilder.Append("brief");
                pBuilder.Append("</csw:ElementSetName>");
                pBuilder.Append("<csw:Constraint version='1.1.0'>");
                pBuilder.Append("<ogc:Filter>");

                pBuilder.Append("<ogc:And>");

                SearchText(pBuilder);

                pBuilder.Append("<ogc:BBOX>");
                pBuilder.Append("<ogc:PropertyName>");
                pBuilder.Append("ows:BoundingBox");
                pBuilder.Append("</ogc:PropertyName>");
                pBuilder.Append("<gml:Envelope>");
                pBuilder.Append("<gml:lowerCorner>");
                pBuilder.Append("-118.3 32.1");
                pBuilder.Append("</gml:lowerCorner>");
                pBuilder.Append("<gml:upperCorner>");
                pBuilder.Append("-87.1 45.2");
                pBuilder.Append("</gml:upperCorner>");
                pBuilder.Append("</gml:Envelope>");
                pBuilder.Append("</ogc:BBOX>");

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

        private void SearchText(StringBuilder pBuilder)
        {
            pBuilder.Append("<ogc:PropertyIsLike wildCard='*' escape='\' singleChar='?'>");
            pBuilder.Append("<ogc:PropertyName>");
            pBuilder.Append("AnyText");
            pBuilder.Append("</ogc:PropertyName>");
            pBuilder.Append("<ogc:Literal>");

            pBuilder.Append(pPostDataCriteria.SearchText);

            pBuilder.Append("</ogc:Literal>");
            pBuilder.Append("</ogc:PropertyIsLike>"); 
        }

        
    }

}
