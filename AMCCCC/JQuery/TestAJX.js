function getHTTPObject() {
	var xmlhttp;
	if(window.XMLHttpRequest)
		xmlhttp = new XMLHttpRequest();
	else if(window.ActiveXObject )
		xmlhttp = new ActiveXObject( "Microsoft.XMLHTTP" );
	else {
		alert( "Your browser cannot perform the requested action. " +
			"Either your security settings are too high or your " +
			"browser is outdated. Try the newest version of " +
			"Internet Explorer or Mozilla Firefox." );
	}
	return xmlhttp;
}
// Create http object
var http = getHTTPObject();
var XmlReq;

function CreateXmlReq()
{
	try
	{
		XmlReq = new ActiveXObject("Msxml2.XMLHTTP");
	}
	catch(e)
	{
		try
		{
			XmlReq = new ActiveXObject("Microsoft.XMLHTTP");
		} 
		catch(oc)
		{
			XmlReq = null;
		}
	}
	if(!XmlReq && typeof XMLHttpRequest != "undefined") 
	{
		XmlReq = new XMLHttpRequest();
	}
}
//This fucntion is to send the choice into the AJAX Server page for processing
function FetchDGContents(SortField,SortType,hlp)
{
	//var selecteditem = document.Form1.ddlcity.value;
	//Starts displaying the Process Image table
	//imgtbl.style.visibility = 'visible';

    var vReqid=Math.random() * 1000;
    var requestUrl = "/WebPF/HELP/Help.aspx?req="+(vReqid)+"&searchstr="+SortField+"&hlp="+SortType+"&fldname="+hlp;
    /// <reference path="" />
	CreateXmlReq();
	
    if(XmlReq)
	{
        XmlReq.abort();
	    XmlReq.open("GET", requestUrl,  true);
	    XmlReq.send(null);
	    XmlReq.onreadystatechange = HandleResponse;
	}
}
function HandleResponse()
{
if(XmlReq.readyState == 4)
	{
		if(XmlReq.status == 200)
		{			
			// Before filling new contents into the DataGrid, clear the cotents by calling this function
			ClearTable();
			// Fill the cleared Datagrid with new XML Reponse
			FillTable(XmlReq.responseXML.documentElement);
			// Hides the Process Image Table after displaying the contents
			//imgtbl.style.visibility = 'hidden';
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
	}
}

//Fills the datagrid contents with the newly recieved Response content
function FillTable(scity)
{
	// Gets the response XML
	var auth = scity.getElementsByTagName('NewDataSet'); 
	// Gets the table type content present in the Response XML and gets the data into a variable tbl
	var tbl = document.getElementById('dgauthors').getElementsByTagName("tbody")[0];
			
	// Iterate through the table and add HTML Rows & contents into it.
	if (auth.context.childNodes.length>0)
	{
		for(var i=0;i<auth.context.childNodes(0).parentNode.childNodes.length;i++)
		{
			// Create a HTML Row
			var row = document.createElement("TR"); 
			
			// Set the style
			row.setAttribute("className","rowtext");
			row.onmouseover=function(){this.style.backgroundColor='beige';this.style.cursor='hand';}
			row.onmouseout=function(){this.style.backgroundColor='#FFF';this.style.cursor='';}
			//row.onClick="tableclick(this);"
			row.onclick=function(){tableclick(this);}
			//row.setAttribute("onClick","tableclick(this);");
			//row.setAttribute("bgColor","#ECECEC");
			
			// Iterate thorugh the columns of each row
			// 
			for(var j=0;j<auth.context.childNodes(i).childNodes.length;j++)
			{
				// Create a HTML DataColumn
				var cell = document.createElement("TD"); 
				// Store the cotents we got from Response XML into the column
				//cell.innerHTML = auth.context.childNodes(i).childNodes(j).text;
				
				if (auth.context.childNodes(i).childNodes(j)==null)
				{
				cell.innerHTML = ' ';
				}
				else
				{
				cell.innerHTML = auth.context.childNodes(i).childNodes(j).text;
				}
				
				// Append the new column into the current row
				row.appendChild(cell); 
			}
			// Append the current row into the HTML Table(i.e DataGrid)
			tbl.appendChild(row)
		}
	}
}

// Clearing the existing contents of the Datagrid
function ClearTable()
{
	var tbl = document.getElementById('dgauthors');//.getElementsByTagName("tbody")[0];
	var row = tbl.rows.length
	for (var i=row;i>1;i--)
	{
		//if (tbl.rows.length == 2){i = 1;}
		tbl.deleteRow(i-1);
		//if (tbl.rows.length == i) {i = 0;}
	}
}

function handleHttpGridResponse() {

	if (http.readyState == 4) {
		document.getElementById("testDiv").innerHTML = http.responseTEXT;
	}
}
		

function FillProduct(cid,cname) {
	var response ="Product.aspx?cid=" + cid + "&cname=" + cname;

	if(http) {
				http.open("POST", response, true)
				http.onreadystatechange = handleHttpPrdGridResponse;
 			}
			isWorking = true;
			http.send(null);
			return false;
}
function handleHttpPrdGridResponse() {

	if (http.readyState == 4) {
	document.getElementById("divPrd").innerHTML = http.responseTEXT;
	}
}
