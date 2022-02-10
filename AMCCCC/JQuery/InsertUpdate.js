//Function Auto-Post Back Data
function InsertUpdate(Ent, Url) {
    var JSonStr = null;
    $.ajax(
            {
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(Ent),
                dataType: "json",
                type: "POST",
                url: Url,
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
function DataById(Flag, Id, Url) {
    var JSonStr = null;
    $.ajax(
            {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: Url,
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
function DeleteById(Flag, Id, UserID, IP, Url) {
    var JSonStr = null;
    $.ajax(
            {
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: Url,
                data: "{Flag:'" + Flag + "',Param:'" + Id + "',USER_ID:'" + UserID + "',IP:'" + IP + "'}",
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

