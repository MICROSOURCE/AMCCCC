<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="NewChangeRequestComplaint.aspx.cs" Inherits="AMCCCC.PropertyTax.NewChangeRequestComplaint" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <style type="text/css">
        .panel-default > .panel-heading {
            color: #333;
            background-color: #a3bada;
            border-color: #ddd;
        }


        .col-centered {
            float: none;
            margin: 0 auto;
        }
    </style>

    <div class="row">
        <div class="col-sm-12">
            <div class="page-header">
                <h5>
                    <span id="lblFORM_DESC"></span>
                    <asp:Button ID="btnMODE" runat="server" CssClass="btn btn-teal btn-xs pull-right" disabled="disabled" />
                </h5>
            </div>
        </div>
    </div>
    <div class="row" id="maindiv">
        <ul class="nav nav-tabs">
            <li class="nav-item"><a class="nav-link active" aria-current="page" href="#">Change Request For Property Tax</a>              </li>
        </ul>


        <div class="row">
            <div class="col-sm-12">


                <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title ">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse1" aria-controls="collapse1" style="text-decoration: none;">Complaint Details
           <span class="glyphicon glyphicon-minus" aria-hidden="true" style="float: right; border: 1px solid black; border-radius: 3px; background: white; padding: 1px;"></span>
                                </a>

                            </h4>
                        </div>
                        <div id="collapse1" class="panel-collapse collapse in">
                            <div class="panel-body">


                                <form>
                                    <div class="form-group row">
                                        <label for="coca" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Complain Category
                                        </label>
                                        <div class="col-sm-3">
                                            <select class="form-control" aria-label=".form-select-sm example">
                                                <option selected>Select</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </select>
                                        </div>
                                        <label for="cono" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Complain Number
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" readonly class="form-control" id="cono">
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Tenement Number
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="tne">
                                        </div>
                                        <label for="crd" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Complain Registration Date
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="date" id="crd" class="form-control" name="crd">
                                        </div>
                                    </div>

                                </form>

                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Addiational Details
            <span class="glyphicon glyphicon-minus" aria-hidden="true" style="float: right; border: 1px solid black; border-radius: 3px; background: white; padding: 1px;"></span>
                                </a>
                            </h4>
                        </div>
                        <div id="collapse2" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <form>
                                    <div class="form-group row">
                                        <label for="zone" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Zone
                                        </label>
                                        <div class="col-sm-3">
                                            <select class="form-control" aria-label=".form-select-sm example">
                                                <option selected>Select</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </select>
                                        </div>
                                        <label for="ward" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Ward
                                        </label>
                                        <div class="col-sm-3">
                                            <select class="form-control" aria-label=".form-select-sm example">
                                                <option selected>Select</option>
                                                <option value="1">One</option>
                                                <option value="2">Two</option>
                                                <option value="3">Three</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label for="pne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Permission Number
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="pne">
                                        </div>
                                        <label for="pde" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Permission Date
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="date" id="crd" class="form-control" name="pde">
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>



                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse3" in>Applicant Details            <span class="glyphicon glyphicon-minus" aria-hidden="true" style="float: right; border: 1px solid black; border-radius: 3px; background: white; padding: 1px;"></span></a>
                            </h4>
                        </div>
                        <div id="collapse3" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <form>
                                    <div class="form-group row">
                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Applicant Name
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="tne">
                                        </div>



                                        <label for="cono" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Mobile Number
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" readonly class="form-control" id="cono">
                                        </div>
                                    </div>

                                    <div class="row" style="background-color: #C7E0FE;">
                                        <label for="tne" class="col-sm-12 col-form-label">
                                            Application Address
                                        </label>
                                    </div>


                                    <div class="form-group row">
                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            House No
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="tne">
                                        </div>


                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Street
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="tne">
                                        </div>

                                    </div>

                                    <div class="form-group row">
                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            LandMark
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="tne">
                                        </div>


                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Area
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="tne">
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="coca" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Country
                                        </label>
                                        <div class="col-sm-3">
                                            <select class="form-control" aria-label=".form-select-sm example">
                                                <option>Select</option>
                                                <option value="1" selected>India</option>
                                                <option value="2">Dubai</option>
                                                <option value="3">Singapure</option>
                                            </select>
                                        </div>


                                        <label for="coca" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            State
                                        </label>
                                        <div class="col-sm-3">
                                            <select class="form-control" aria-label=".form-select-sm example">
                                                <option>Select</option>
                                                <option value="1" selected>Gujarat</option>
                                                <option value="2">Maharashtra</option>
                                                <option value="3">Kerala</option>
                                            </select>
                                        </div>
                                    </div>


                                    <div class="form-group row">
                                        <label for="coca" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            District
                                        </label>
                                        <div class="col-sm-3">
                                            <select class="form-control" aria-label=".form-select-sm example">
                                                <option>Select</option>
                                                <option value="1" selected>Ahemdabad</option>
                                                <option value="2">Surat</option>
                                                <option value="3">Rajkot</option>
                                            </select>
                                        </div>


                                        <label for="coca" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            City
                                        </label>
                                        <div class="col-sm-3">
                                            <select class="form-control" aria-label=".form-select-sm example">
                                                <option>Select</option>
                                                <option value="1" selected>Ahemdabad</option>
                                                <option value="2">Surat</option>
                                                <option value="3">Rajkot</option>
                                            </select>
                                        </div>
                                    </div>


                                    <div class="form-group row">
                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Pin
                                        </label>
                                        <div class="col-sm-3">
                                            <input type="text" class="form-control" id="tne">
                                        </div>
                                    </div>

                                    <div class="form-group row">
                                        <label for="tne" class="col-sm-3 col-form-label" style="margin-top: 7px">
                                            Remarks
                                        </label>
                                        <div class="col-sm-9 form-group">
                                            <textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
                                        </div>
                                    </div>

                                </form>

                            </div>
                        </div>
                    </div>



                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">Attach Documents </a>
                            </h4>
                        </div>
                        <div id="collapse4" class="panel-collapse collapse in">
                            <div class="panel-body">
                                <h6 style="color: red">Note: Maximum</h6>
                                <h6>To Delete uploaded attachement click on &nbsp;&nbsp;<span class="glyphicon glyphicon-remove" style="color: red;"></span></h6>


                                <div class="container my-3 bg-light">
                                    <div class="col-md-12 text-center">
                                        <button type="button" class="btn" style="background-color: #C7E0FE; border: 1px solid black; border-radius: 0px; padding: 2px">Checklist</button>
                                        <button type="button" class="btn" style="background-color: #C7E0FE; border: 1px solid black; border-radius: 0px; padding: 2px">File Name</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12 text-center">
                    <button type="button" class="btn" style="background: linear-gradient(to bottom, #1685A1 0%, #1685A1 100%); border-radius: 3px; padding: 2px 12px; color: #D9FCFE; font-weight: 700">Save</button>
                    <button type="button" class="btn" style="background: linear-gradient(to bottom, #1685A1 0%, #1685A1 100%); border-radius: 3px; padding: 2px 12px; color: #D9FCFE; font-weight: 700">Close</button>
                </div>

                <div class="col-md-12" style="background-color: #D3E0F1; padding: 9px">
                    <p>Field marked with <i style="color: red">*</i> mandatory. | All amounts are in INR. | All the dates are in DD/MM/YYYY format</p>
                </div>





            </div>
        </div>

    </div>



</asp:Content>



