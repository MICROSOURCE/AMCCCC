ChequeReturn = {
    'init': function () {
        //alert('Initialised');
        $('body').delegate("input", "keypress", function (e) {
            if (e.keyCode == 13) {

                var inputs = $(this).parents("form").eq(0).find(":input");
                var idx = inputs.index(this);

                if (idx == inputs.length - 1) {
                    inputs[0].select()
                } else {
                    inputs[idx + 1].focus(); //  handles submit buttons
                    //inputs[idx + 1].select();
                }
                return false;
            }
        });

        //EnterToTab.init(document.getElementById('form1'));
        $.fn.Fillcombo = function (data) {
            var el = this;
            var ent = {};
            ent["FLAG"] = data;
            var MyJson = InsertUpdate(ent, "../WebService.asmx/GetJsonforCombo");

            el.html("");
            $.each(JSON.parse(MyJson.d), function (i, v) {
                el.append("<option value='" + v.PM_CODE + "'>" + v.PM_DESC + "</option>");
            });
            el.find('option:first').prop('selected', true);
        }

        //Set Button Mode Value 
        $('#btnMODE').val("Add");

        //Hide Delete Button
        $('#btnSubmit').hide();

        $('.validationsummary').hide();
        $("#cmbCHQRET").Fillcombo("CHQRET");
      
    },
    'searchRCPT': function (trn_id) {

        var TOT_AMT;
        var Ent = {};
        Ent.TRN_ID = trn_id;
        var MyJson = InsertUpdate(Ent, "../WebService.asmx/GET_RCPT");
        var Mydata = JSON.parse(MyJson.d);
        if (Mydata[0] == undefined) {
            ShowMessage("I", "No Record Found For :" + trn_id);
            return false;
        }

        $.each(JSON.parse(MyJson.d), function (i, v) {
             
            if (v.PAY_MODE == "PAY001") {
                ShowMessage("I", "This Chalan No Paymode Is Cash :" + trn_id);
                return false
            }

            $('#txtRCPT_NO').val(v.RCPT_NO);
            $('#txtTR_DATE').datepicker("setDate", v.TR_DATE);
            $('#txtAPP_ID').val(v.TRN_REF_NO);
            $('#txt_APPLICANT_NAME').val(v.TAX_PAYER);
            $('#txt_TENAMENT_NO').val(v.TENAMENT_NO);
            $('#txtAMOUNT').val(v.AMOUNT);
            $('#txtPAYMODE').val(v.PAY_MODE);

            $('#txtREF_NO').val(v.CHQ_NO);
            $('#txtREF_DATE').datepicker("setDate", v.CHQ_DATE);
            $('#txtREF_AMOUNT').val(v.CHQ_AMOUNT);
            $('#txtREF_MICR').val(v.CHQ_MICR);

            $('#txtTRN_ID').attr('disabled', true);
            $('#txtAPP_ID').attr('disabled', true);


            $('#btnSubmit').show();
            //Mode Change 
            //$('#btnMODE').val("Add");

        });
    },
    'YearlyDet': function (trn_id) {
        var Ent = {};
        ow
        Ent.FLAG = 'GET_RCPTDET';
        Ent.PARAM = trn_id;
        Ent.PARAM1 = null;

        var MyJson = InsertUpdate(Ent, "../WebService.asmx/GET_ONSCRN_RPT");
        var Mydata = JSON.parse(MyJson.d);
        if (Mydata[0] == undefined)
        { return false; }

        $('#tblyearwisedues> tbody').html("");
        $('#tblyearwisedues> tfoot').html("");

        var TAX = 0;
        var INT = 0;
        var TOT = 0;

        $.each(JSON.parse(MyJson.d), function (i, v) {

            $('#tblyearwisedues> tbody:last').append("<tr><td>" + v.FIN_YEAR
                        + "</td><td>" + v.YEAR_PART
                        + "</td><td>" + v.TAX_ENAME
                        + "</td><td>" + v.TAX_AMT
                        + "</td><td>" + v.INT_AMT
                        + "</td><td>" + v.TOTAL
                        + "</td></tr>");
            TAX = Number(TAX) + Number(v.TAX_AMT);
            INT = Number(INT) + Number(v.INT_AMT);
            TOT = Number(TOT) + Number(v.TOTAL);
        });

        $('#tblyearwisedues> tfoot:last').append("<tr class='alert-warning fontbold' ><td colspan='3'>Sub Total"
                        + "</td><td class='subtotal'> " + TAX + "</td><td class='subtotal'> " + INT + "</td><td class='subtotal'> " + TOT + "</td></tr>");
        $('#tblyearwisedues tr td:nth-child(1)').css("width", "50");
        $('#tblyearwisedues tr td:nth-child(2)').css("width", "50");
        $('#tblyearwisedues tr td:nth-child(2)').addClass("center");
        $('#tblyearwisedues tr td:nth-child(3)').addClass("leftalign");
        $('#tblyearwisedues tr td:nth-child(4)').addClass("rightalign");
        $('#tblyearwisedues tr td:nth-child(5)').addClass("rightalign");
        $('#tblyearwisedues tr td:nth-child(6)').addClass("rightalign");

        $('#tblyearwisedues tr:last td').addClass("rightalign");


        //$("#tblyearwisedues td").css({ "text-align": "right" });
        return false;
    },
    'Save': function () {
        var Ent = {};
        Ent.TRN_ID = $('#txtTRN_ID').val();
        Ent.PROP_ID = $('#txtAPP_ID').val();
        Ent.TENAMENT_NO = $('#txt_TENAMENT_NO').val();
        Ent.CAN_AMT = $('#txtREF_AMOUNT').val();
        Ent.CAN_REASON_CODE = $('#cmbCHQRET option:selected').val();

        var MyJson = InsertUpdate(Ent, "../WebService.asmx/RETURN_CHEQUE");

        if (MyJson.d.substr(0, 3) == "100") {
            //Textbox Clear
            ClearAll();
            //End

            ShowMessage('S', MyJson.d);
        }
        else {
            ShowMessage("E", MyJson.d)
        }
    }
}