# ArcMap CSW Client

This AddIn for ArcMap allows the user to search several Catalog Services for the Web (CSW) from within ArcMap. Four catalogs can be searched:
  - **USGIN Catalog**
  - **OneGeology Portal**
  - **Data.gov Catalog**
  - **NGDS Catalog**

Metadata for found resources can be easily viewed from within the AddIn and resources published as Web Map Services (WMS) can be added directly to the working map.

### Installation
1. Find the file **CSWClient.esriAddIn** in the **CSWClient/bin/Debug** folder. (If using GitHub open the file and click the **Raw** button to download only this file.)
2. Save CSWClient.esriAddIn to your computer in a location of your choosing.
3. Double-click CSWClient.esriAddIn
4. Click **Install Add-In**
5. In ArcMap, click **Customize**
6. Select **Customize Mode…**
7. Select the **Commands** tab
8. Under **Add-In Controls** select the **CSW Client**
9. Drag the **CSW Client** button to a toolbar
10. Click Close

### Running
1. Click the **CSW Client** button on the toolbar
2. In the drop-down menu select the catalog that you would like to search:
  - **USGIN Catalog** (http://catalog.usgin.org/geoportal/csw/discovery?)
  - **OneGeology Portal** (http://onegeology-catalog.brgm.fr/geonetwork/srv/csw?)
  - **Data.gov Catalog** (http://catalog.data.gov/csw?)
  - **NGDS Catalog** (http://geothermaldata.org/csw?)
3. Enter a search term in the text box and select from the drop-down menu if you'd like to search for the term in **AnyText**, the **Title** or the **Abstract** of the CSW records.
4. Select additional options:
  - **WMS**: Search only for datasets that are web map services
  - **Live Data**: Search only for datasets that are live (USGIN Catalog only)
  - **Use Current Extent**: Search only for datasets whose bounding box overlaps the current extent of the map
5. Click the **Search** button
6. Results will appear in the box below. Only 15 results are displayed at a time. Use the arrows at the top of the box to see more results.
7. Click on a search result and its **Abstract** will appear below.
8. Click on the **Metadata** button and new window will pop-up with the metadata for the record.
9. Click on the **Add** button (if available) to add the dataset to the map.


### Development Setup
Prerequisties: **ArcObjects SDK** (from the ArcGIS installation disc) and **Visual Studio**

1. Clone this repository
2. Open the project by double-clicking **CSWClient.sln**
3. Configure a Debug session to open ArcMap automatically
 - In the **Solution Explorer** panel right click ncgmpToolbar
 - Under **Debug**, select **Start Action**, **Start external program**
 - Browse to the **ArcMap** executable
4. Run **Build**, **Clean Solution** (This will clear the **/bin/Debug** folder)
5. Click **Debug**, **Start Debugging** (This will build the **CSWClient.esriAddIn** in the **/bin/Debug** folder)

### API documentation

#### ArcGISAddinDWin Class 

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

#### CSWSearch Class
Send search request and get response
  
	Uri cswUri = new Uri(strCatalogUrl);
	HttpWebRequest cswRequest = (HttpWebRequest)WebRequest.Create(cswUri);
	...
	HttpWebResponse cswResponse = (HttpWebResponse)cswRequest.GetResponse();	

#### PostDataCriteria Class
Define what kinds of info should be provided for request  

#### CreatePostData Class
Generate a string for POST request   

	CreatePostData pPostData = new CreatePostData();
	pPostData.CreatXmlDoc(pPostDaCri);
	strPostDa = pPostData.PostData;

#### ParseCswResponse Class
Parse the response and return a list of service names

	ParseCswResponse cPCswRp = new ParseCswResponse();
	cPCswRp.ResponseTxt = strResponseTxt;
	cPCswRp.ParseResponse(indexSelectedCatalog);

#### GetCapabilitiesTest Class
Validate services using fgdc validator http://registry.fgdc.gov/statuschecker/post.php

	private Boolean TestUrl(string url)
	{
	    GetCapabilitiesTest cTest = new GetCapabilitiesTest();
	    return cTest.IsWms(url);
	}	

#### ServiceOpener Class
Add the wms/ArcGIS Rest layer into the map

	private ServiceOpener cSvcOpener = new ServiceOpener();
	...
	cSvcOpener.OpenWMS(strServiceLink);
	cSvcOpener.OpenAGS(strServiceLink);

#### FormViewMetadata Class
Display the metadata info for the selected item

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
