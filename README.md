## API documentation

`ArcGISAddinDWin` : 

The dockable window components (e.g. combobox, listbox ...) are defined in this class

* Click 'Search' button:
  - begin search
	- trigger `btnSearch_Click` function
* Click 'Add' button:
	- add the layer onto ArcMap 
 	- trigger `btnAdd_Click` function
* Click 'Metadata' button:
	- display metadata info for the selected record
	- trigger `btnMetaDoc_Click` function

`CSWSearch` :  send search request and get response
  
	Uri cswUri = new Uri(strCatalogUrl);
	HttpWebRequest cswRequest = (HttpWebRequest)WebRequest.Create(cswUri);
	...
	HttpWebResponse cswResponse = (HttpWebResponse)cswRequest.GetResponse();	

`PostDataCriteria` : define what kinds of info should be provided for request   
`CreatePostData` : generate a string for POST request   

	CreatePostData pPostData = new CreatePostData();
	pPostData.CreatXmlDoc(pPostDaCri);
	strPostDa = pPostData.PostData;

`ParseCswResponse` : parse the response and return a list of service names

	ParseCswResponse cPCswRp = new ParseCswResponse();
	cPCswRp.ResponseTxt = strResponseTxt;
	cPCswRp.ParseResponse(indexSelectedCatalog);

`GetCapabilitiesTest` : validate services using fgdc validator `http://registry.fgdc.gov/statuschecker/post.php`

	private Boolean TestUrl(string url)
	{
	    GetCapabilitiesTest cTest = new GetCapabilitiesTest();
	    return cTest.IsWms(url);
	}	

`ServiceOpener` : add the wms/ArcGIS Rest layer into the map

	private ServiceOpener cSvcOpener = new ServiceOpener();
	...
	cSvcOpener.OpenWMS(strServiceLink);
	cSvcOpener.OpenAGS(strServiceLink);

`FormViewMetadata` : display the metadata info for the selected item

	FormViewMetadata pFrmViewMetadata = new FormViewMetadata();
	pFrmViewMetadata.Text = lboxResults.SelectedItem.ToString();
	...
	switch (cboCatalog.SelectedIndex)
	{
	    case 0:
	        pFrmViewMetadata.OpenMetadataDoc(...);
	        pFrmViewMetadata.Show();
	        ...
		...
	}
