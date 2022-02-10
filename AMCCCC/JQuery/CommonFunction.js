var SplitChar = '$';

//FUNCTION TO BE OPENED ON F2 KEYPRESS
function Fetch(Type, event) {
    var arg = $(Type).attr('AutoCompleteFlag');
    var UType = $(Type).attr('UTYPE');
    var UId = $(Type).attr('UID');
    var Param = UType + SplitChar + UId;
    var e = event.which;
    if (e == 113) {
        $('.main-container').append("<div id='mydiv' style='border:2px solid #a6c9e2;background-color:#F6F6F6;border-radius:0px 0px 5px 5px;'></div>");
        $('.main-navigation').css("z-index", "0");
        $('#mydiv').load("../HELP/JQHelp.aspx?hlp=" + arg + "&Param=" + Param).dialog({
            autoOpen: true,
            position: 'center',
            title: "Help",
            width: 800,
            height: 500,
            modal: true,
            close: function (event, ui) {
                $(Type).val($('#mydiv').find("input[name=txtSelect]").val());
                $('#mydiv').remove();
                //$('body').removeClass('navigation-small');
                $('.main-navigation').css("z-index", "1000");
            },
            closeOnEscape: true,
            show: {
                effect: "drop",
                duration: 100
            },
            draggable: false,
            resizable: false
        });

    }
}


function CtrlAutoComplete(Ctrl, OptCtrl) {
    Param = null;
    Flag = null;
    var UType = $(Ctrl).attr('UTYPE');
    var UId = $(Ctrl).attr('UID');

    //Call Auto-Complete Method
    $(Ctrl).keyup(function () {

        Flag = $(this).attr('AutoCompleteFlag');
        if (OptCtrl == undefined) {
            Param = $(this).val() + SplitChar + UType + SplitChar + UId;
        }
        else {
            var BD = document.getElementById(OptCtrl);
            Param = $(BD).val() + $(this).val();
        }

        if (Param != '') {
            AutoCompleteText(Flag, Param);
        }
    });
}

function CtrlAutoComplete1(Ctrl, OptCtrl1, OptCtrl2) {

    Param = null;
    Flag = null;
    $(Ctrl).keyup(function () {

        Flag = $(this).attr('AutoCompleteFlag');
        if (OptCtrl1 == undefined && OptCtrl2 == undefined) {
            Param = $(this).val();
        }
        else if (OptCtrl1 != undefined && (document.getElementById(OptCtrl2).value == '' || document.getElementById(OptCtrl2).value == undefined)) {
            var BD = document.getElementById(OptCtrl1);
            Param = $(BD).val() + $(this).val();
        }
        else {
            var BD = document.getElementById(OptCtrl1);
            var SD = document.getElementById(OptCtrl2);
            Param = $(BD).val() + $(SD).val() + $(this).val();
        }

        if (Param != '') {
            AutoCompleteText(Flag, Param);
        }
    });

}


//Split Code-Description from "-"
function SplitCodeDesc(Ctrl, ChildCtrl) {
    if ($(Ctrl).val() != '') {

        var CH = document.getElementById(ChildCtrl);
        var BC = $(Ctrl).val();

        if (BC.split('-')[0] != 'No Record Found !!!') {
            $(Ctrl).val(BC.split('-')[0]);
            $(CH).val(BC.split('-')[1]);
        }
        else {
            $(Ctrl).val('');
            $(CH).val('-');
        }
    }

}


function SplitCodeDescMulti(Ctrl, ChildCtrl, SecCtrl, ThirdCtrl) {

    if ($(Ctrl).val() != '') {

        var CH = document.getElementById(ChildCtrl);
        var SEC = document.getElementById(SecCtrl);

        if (ThirdCtrl != undefined) {
            var TH = document.getElementById(ThirdCtrl);
        }

        var BC = $(Ctrl).val();

        if (BC.split('-')[0] != 'No Record Found !!!') {
            $(Ctrl).val(BC.split('-')[0]);
            $(CH).val(BC.split('-')[1]);
            $(SEC).val(BC.split('-')[2]);
            if (ThirdCtrl != undefined) {
                $(TH).val(BC.split('-')[3]);
            }

        }
        else {
            $(Ctrl).val('');
            $(CH).val('-');
            $(SEC).val('-');
            $(TH).val('-');

        }
    }
}


//User Defined Function Which Bind DropDown
function AutoCompleteText(Flag, Param) {

    //Call WebMethod
    $(".autosuggest").autocomplete(
    {
        source: function (request, response) {
            $.ajax(
            {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../WebService.asmx/FetchAutoCompleteList',
                data: "{Flag:'" + Flag + "',Param:'" + Param + "'}",
                dataType: "json",
                cache: false,
                success: function (data) {
                    if (data.d[0] != undefined) {
                        response(data.d);
                    }
                },
                error: function (result) {

                    alert($.parseJSON(result.responseText).Message);
                }
            });
        }
    });
}

//Prevent BackSpace Key in Read-Only Textbox
function PreventBackSpaceKey() {
    var keyCode = (event.which) ? event.which : event.keyCode;
    if ((keyCode == 8) || (keyCode == 46))
        event.returnValue = false;
}


//Clear Controls Value from Page
function ClearAll() {

    //Clear All Textbox Value
    $('input[type=text]').each(function () {
        $(this).val('');
        $('.autosuggest').prop('disabled', false);
        $('.autosuggest').focus();
    });

    //Clear Multiline Textbox
    $('textarea').each(function () {
        $(this).val('');

    });

    //Clear Gridview
    $("#GRID").html("");

    $('.grid').css('display', 'none');

    $('.dropdown').prop('disabled', false);
    //Clear Validation Summary
    if (typeof (Page_ValidationSummaries) != "undefined") { //hide the validation summaries
        for (sums = 0; sums < Page_ValidationSummaries.length; sums++) {
            summary = Page_ValidationSummaries[sums];
            summary.style.display = "none";
        }
    }

    $('input[type=radio]').prop('checked', false);

    //Set Index Zero of All DropDownList
    $('select').each(function () {
        $(this).prop('selectedIndex', 0);
    });

    //Set Hideen Field Mode Insert When Reset Button Press
    $('input[id$=HidMode]').val('I');

    //Clear Validation Message If Generated
    $('.Validation').css('visibility', 'hidden');

    //Visible Delete Button
    $('.Delete').css('display', 'none');

    $('#btnDelete').hide();


    $('input[type=radio]').prop('checked', false);

    //hide table rows
    $('.tr').hide();

    //Validation Div Remove
    $("#errMsg div").remove();

    //Set Button Mode Value 
    $('#btnMODE').val("Add");

    //Master Page Label Clear
    $('#lblLST_USER').text('Created user');
    $('#lblLST_DATE').text('Created Date');
    $('#lblLST_IP').text('Created Ip Address');
}



//Function Auto-Post Back Data
function ChangeDropDown(Flag, Id) {
    var JSonStr = null;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: '../WebService.asmx/GetData',
        data: "{Flag:'" + Flag + "',Param:'" + Id + "'}",
        dataType: "json",
        async: false,
        success: function (data) {
            JSonStr = data;
        },
        error: function (result) {
            MyStr = $.parseJSON(result.responseText).Message;
        }
    });
    return JSonStr;
}

//Function Display Data By Id
function DisplayDataById(Id) {
    var JSonStr = null;
    $.ajax(
            {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../CommonWebService.asmx/DisplayDataById',
                data: "{Param:'" + Id + "'}",
                dataType: "json",
                async: false,
                success: function (data) {
                    JSonStr = data;
                },
                error: function (result) {
                    MyStr = $.parseJSON(result.responseText).Message;
                }
            });
    return JSonStr;
}

//Function Display Data By Id
function DisplayDataByCatCode(CODE) {
    var JSonStr = null;
    $.ajax(
            {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: '../CommonWebService.asmx/FetchPercent',
                data: "{Param:'" + CODE + "'}",
                dataType: "json",
                async: false,
                success: function (data) {
                    JSonStr = data;
                },
                error: function (result) {
                    MyStr = $.parseJSON(result.responseText).Message;
                }
            });
    return JSonStr;
}



function ValidNum(arg, obj) {

    //getting key code of pressed key
    var keycode = (event.which) ? event.which : event.keyCode;
    var txtVal = obj.value;
    if (arg == 'Y') {
        //comparing pressed keycodes
        if (!(keycode == 8 || keycode == 46) && (keycode < 48 || keycode > 57)) {
            return false;
        }
        else {

            //  return false if . is pressed secondtime
            if ((txtVal.indexOf(".") >= 0) && keycode == 46) {
                return false;
            }
            else {
                return true;
            }
        }
    }
    else if (arg == 'N') {
        if (!(keycode == 8) && (keycode < 48 || keycode > 57)) {
            return false;
        }
        else {
            return true;
        }
    }
    else { }
}

// Function to validate alphabets, allows only alphabets
function ValidAlpha(obj) {
    var keyCode = (event.which) ? event.which : event.keyCode;
    if ((keyCode < 65 || keyCode > 122)) {
        return false;
    }
    else { return true; }
}


//Function to allow only alpha numeric to textbox
function validatealphanumeric(Obj, key) {

    var keycode = (key.which) ? key.which : key.keyCode
    var phn = document.getElementById('txtChar');
    //comparing pressed keycodes
    if (!(keycode == 8) && (keycode < 48 || keycode > 57) && (keycode < 97 || keycode > 122)) {
        return false;
    }
    else {
        return true;
    }
}

////Convert Enter Key pressed event inside Textbox to Tab key.
//function EnterToTab() {
//    if (event.keyCode == 13) {
//        event.keyCode = 9;
//    }
//}

function EnterToTab(field, event) {
    if (event.which == 13 /* IE9/Firefox/Chrome/Opera/Safari */ || event.keyCode == 13 /* IE8 and earlier */) {
        for (i = 0; i < field.form.elements.length; i++) {
            if (field.form.elements[i].tabIndex == field.tabIndex + 1) {
                field.form.elements[i].focus();
                if (field.form.elements[i].type == "text") {
                    field.form.elements[i].select();
                    break;
                }
            }
        }
        return false;
    }
    return true;
}

//Delete Confirm Message
function delconfirm() {
    return confirm('Are you Sure you want to delete?');
}


function setddlmouse(ddl) {
    ddl.style.position = 'absolute';
    ddl.style.width = 'auto';
}

function setddlblur(ddl) {
    ddl.style.position = 'static';
    ddl.style.width = '120px';

}

//// Date Time Picker For Bootstrap
function Datepicker() {

    $('.date-picker').datepicker({
        autoclose: true,
        format: 'dd-M-yyyy'
    });
}

document.onkeydown = function () {

    switch (event.keyCode) {
        case 116: //F5 
            event.returnValue = false;
            event.keyCode = 0;
            //window.status = 'Refresh is disabled'; 
            alert('Please Dont Refresh Any Page Of  Application')
            return false;
        case 0: //r  
            event.returnValue = false;
            event.keyCode = 0;
            alert('Please Dont Refresh Any Page In Application')
            return false;

    }

    if (event.keyCode == 8 && event.srcElement.tagName.toUpperCase() != 'INPUT' && event.srcElement.tagName.toUpperCase() != 'TEXTAREA' && event.srcElement.readOnly == true) {

        alert('Please Dont Press BackSpace Key')
        return false;
    }
    if (event.keyCode == 8 && event.srcElement.readOnly == true) {
        alert('Textbox Is Read Only So Please Dont Press BackSpace Key')
        return false;
    }
    if (event.keyCode == 13 && event.srcElement.type.toUpperCase() != 'SUBMIT' && event.srcElement.type.toUpperCase() != 'BUTTON') {
        event.keyCode = 9;
    }

}


//Function WaterMark 
function WaterMark(Ctrl, Text) {

    //Set Text On Page Load
    $(Ctrl).val(Text).addClass('watermark');

    //Set Text On Lost focus If No Text Inside Textbox
    $(Ctrl).blur(function () {
        if ($(this).val().length == 0) {
            $(this).val(Text).addClass('watermark')
        };
    });

    //Remove WaterMarkText on Focus Event
    $(Ctrl).focus(function () {
        if (($(this).val().length != 0) && ($(this).val() == Text)) {
            $(this).val('').removeClass('watermark')
        };
    });
}
//Function WaterMark 
function WaterMark(Ctrl) {
    var Text = $(Ctrl).attr('WaterMark');
    $('.WaterMark').watermark('HELLO');
}

//FUNCTION FOR FILE UPLOAD CONTROL
function FileUpload(Finput, ImgCont, Bytes, ext) {
    var cnt = 0, i, fileSize, AllowFileSize, Extension, fname, temp, filerdr;
    //get file extension
    ext = ext.toString().toLowerCase();
    Extension = ext.split(',');

    //get file name
    temp = $(Finput).val();
    fname = temp.substring(temp.lastIndexOf('\\') + 1);
    fname = temp.substring(temp.lastIndexOf('.') + 1);
    fname = fname.toString().toLowerCase();
    // check for extension
    for (i = 0; i < Extension.length; i++) {
        if (Extension[i] != fname) {
            cnt++;
        }
        if (cnt == Extension.length) {
            alert("You Can Upload Files Only With Extension " + "(" + ext.replace(",", " or ") + ")");
            $(Finput).val('');
            return false;
        }
    }

    //caluclate allowed file size(according to parameter)
    AllowFileSize = Number(Bytes) * 1024;

    //fetch file size of uploaded image
    fileSize = Finput.files[0].size;

    filerdr = new FileReader();
    if (Finput.files && Finput.files[0]) {
        if (fileSize > AllowFileSize) {
            alert("Please Upload File Less Than Or Equal To " + Bytes + " Kb ");
            $(Finput).val('');
            return false;
        }
        else {
            filerdr.onload = function (e) {
                $(ImgCont).attr('src', e.target.result);
            }
            filerdr.readAsDataURL(Finput.files[0]);
        }

    }
}

//Checking For Future Date
function isFutureDate(checkDate) {

    var CurDate = new Date();
    var date = checkDate.value;

    CurDate = Date.parse(CurDate);
    date = Date.parse(date);

    if (date > CurDate) {
        alert("Future Date Is Not Allowed !");
        checkDate.value = '';
        $(checkDate).focus();
    }
}

//Checking For Future Date
function isPastDate(checkDate) {

    var CurDate = new Date();
    var date = checkDate.value;

    CurDate = Date.parse(CurDate);
    date = Date.parse(date);

    if (date < CurDate) {
        alert("Past Is Not Allowed !");
        checkDate.value = '';
        $(checkDate).focus();
    }
}

//Checking For Past Date In Property Assessment Form
function billdate(billdate, checkDate) {
    var CurDate;
    var date = checkDate.value;

    CurDate = Date.parse(billdate);
    date = Date.parse(date);

    if (date < CurDate) {
        alert("Past Date Is Not Allowed In Due Date!");
        checkDate.value = '';
        $(checkDate).focus();
    }

}

function GetDate(str) {
    var arr = str.split('-');
    var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
    var i = 1;
    for (i; i <= months.length; i++) {
        if (months[i] == arr[1]) {
            break;
        }
    }
    var formatddate = i + '/' + arr[0] + '/' + arr[2];
    return formatddate;
}
function compareDate(txt1, txt2, Message) {

    var RegDate, DetDate, Ddate, Rdate;
    RegDate = $(txt1).val();
    DetDate = $(txt2).val();
    Ddate = GetDate(DetDate);
    Rdate = GetDate(RegDate);
    if ((Date.parse(Ddate) > Date.parse(Rdate))) {
        alert(Message);
        $(txt2).val('');
        $(txt2).focus();
    }
}

// RETRIVE QUERY STRING VALUE
function GetParameterValues(param) {
    var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < url.length; i++) {
        var urlparam = url[i].split('=');
        if (urlparam[0] == param) {
            return urlparam[1].replace(/_/g, " ");
        }
    }
}
// FUNCTION TO ADD USER TYPE AND USER ID ATTRIBUTE TO TEXTBOX
function AddUserTypeNId(UserType, UserCode) {
    $('.autosuggest').attr('UTYPE', UserType);
    $('.autosuggest').attr('UID', UserCode);
}

//function To Add FormName and Desc
function FormDet(pdesc) {

    //var HEADER = GetParameterValues('FORMNAME');
    //var HEADERDESC = GetParameterValues('FORMDESC');

    //$('#lblFORM_NAME').text(HEADER);
    $('#lblFORM_DESC').text(pdesc);

}

//Master Page Message Box
function ShowMessage(TYPE, MESSAGE) {

    //Attribute Add For Message Box
    //$(ID).attr("href", "#static");
    //end
    if (MESSAGE.includes('100' || '999') == true) {
        MESSAGE = MESSAGE.split('-')[1];
    }

    //Message Box Class Add
    if (TYPE == "I") {
        $('#ICLASS').attr("Class", "clip-info-2");
        $('#lblICON').html(" Information Message");
        $('#MSG').attr("Class", "alert alert-info");
        $('#btnMSG').attr("Class", "btn btn-blue");
    }
    else if (TYPE == "S") {
        //Message Box Class Add
        $('#ICLASS').attr("Class", "clip-checkmark-circle-2");
        $('#lblICON').html(" Success Message");
        $('#MSG').attr("Class", "alert alert-success");
        $('#btnMSG').attr("Class", "btn btn-green");
        //
    }
    else if (TYPE == "E") {
        //Message Box Class Add
        $('#ICLASS').attr("Class", "clip-cancel-circle-2");
        $('#lblICON').html(" Error Message");
        $('#MSG').attr("Class", "alert alert-danger");
        $('#btnMSG').attr("Class", "btn btn-bricky");
        //
    }

    //Message Set at Lable in Message Box
    $('#lblmsg').html(MESSAGE);
    $('#static').modal('show');
    //

}

//For Master Page Rights
function MST_RIGHTS(TYPE) {

    var LST_USER = $('#lblLST_USER').text();

    var R_ADD = $('#chkR_ADD').is(':checked');
    var R_EDIT = $('#chkR_EDIT').is(':checked');
    var R_DEL = $('#chkR_DEL').is(':checked');
    var R_READ = $('#chkR_READ').is(':checked');
    var S_EDIT = $('#chkS_EDIT').is(':checked');
    var S_DEL = $('#chkS_DEL').is(':checked');

    //Rights Checking
    if (TYPE == 'U') {
        //Check All Update Data
        if (R_EDIT == false) {
            if (S_EDIT == true) {
                if (LST_USER != '<%=Session("USER_ID") %>') {
                    ShowMessage("I", "You Have No Permission To Update This Data");
                    return false
                }
            }
            else {
                ShowMessage("I", "You Have No Permission To Update Data");
                return false
            }
        }
    }
        //Check Addtion Rights
    else if (TYPE == 'A') {
        if (R_ADD == false) {
            ShowMessage("I", "You Have No Permission To Add Data");
            return false
        }
    }
        //Checking For Read Rights 
    else if (TYPE == 'R') {
        if (R_READ == false) {
            ShowMessage("I", "You Have No Permission For Read Data");
            return false
        }
    }

    else if (TYPE == 'D') {
        debugger
        //Check All Delete Data
        if (R_DEL == false) {
            if (S_DEL == true) {
                //if (LST_USER != '<%=Session("USER_ID") %>') {
                //    ShowMessage("I", "You Have No Permission To Delete This Data");
                //    return false
                //}
            }
            else {
                ShowMessage("I", "You Have No Permission To Self Delete Data");
                return false
            }
        }
    }
}
//FUNCTION TO VALIDATE NUMERIC FIELDS WITH DECIMAL POINTS
function ValidateNumeric(txtBox, Cvalue, Operator, message) {
    var EValue = $(txtBox).val();
    var CompVal = Cvalue;
    if (Operator == '>') {
        if (Number(EValue) > Number(CompVal)) {
            alert(message);
            $(txtBox).val('');
            $(txtBox).focus();
            return false;
        }
        else { return true; }
    }
    else if (Operator == '<') {
        if (Number(EValue) < Number(CompVal)) {
            return true;
        }
        else {
            alert(message);
            $(txtBox).val('');
            $(txtBox).focus();
            return false;
        }
    }
}


