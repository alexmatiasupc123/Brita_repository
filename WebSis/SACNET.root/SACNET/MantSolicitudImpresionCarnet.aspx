<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="MantSolicitudImpresionCarnet.aspx.cs" Inherits="MantSolicitudImpresionCarnet" meta:resourcekey="PageResource1" %>

<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<%@ Register src="Comun/Controles/ucTextBoxFecha.ascx" tagname="ucTextBoxFecha" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 201px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" 
        Text="Mantenimiento: Solicitud de Carné" 
        meta:resourcekey="lblTituloPaginaResource1"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="panelBotones">
                <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
            </div>
            <div class="panelleyenda">
                <asp:ImageButton ID="ButtonBuscarPago" runat="server" 
                    ImageUrl="~/Comun/Imagenes/Botones/BusPago_A.png" 
                    ToolTip="Buscar documento de pago" Visible="False" meta:resourcekey="ButtonBuscarPagoResource1" 
                    />
                <asp:ImageButton ID="ButtonParaImprimir" runat="server" 
                    ImageUrl="~/Comun/Imagenes/Botones/SolImp_A.png" 
                    ToolTip="Solicitar impresión de carné" Visible="False" 
                    OnClick="ButtonParaImprimir_Click" 
                    meta:resourcekey="ButtonParaImprimirResource1"/>
            </div>
            <div class="panelGria">
                <table>
                    <tr>
                        <td>
                            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                        </td>
                    </tr>
                </table>
                <br />
                <fieldset style="width: 870px">
                    <legend>Datos del usuario</legend>
                    <table width="850px">
                        <tr>
                            <td width="200">
                                <asp:Label ID="Label1" runat="server" Text="Código:" 
                                    meta:resourcekey="Label1Resource1"></asp:Label>
                            </td>
                            <td width="250">
                                <table>
                                    <tr>
                                        <td  style="vertical-align:bottom">
                                            <asp:TextBox ID="f_txtCodigoUsuarioSAC" runat="server" MaxLength="10"  
                                            onkeypress="return filterInput(1, event)" Width="129px" Font-Bold="False" 
                                            ForeColor="#000066" meta:resourcekey="f_txtCodigoUsuarioSACResource1"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ButtonBuscarUsuarioSAC"  runat="server" 
                                            ImageUrl="~/Comun/Imagenes/Botones/RecDatos_A.png" ToolTip="Buscar usuario SAC" 
                                            OnClick="ButtonBuscarUsuarioSAC_Click" Height="29px" Width="103px" 
                                                meta:resourcekey="ButtonBuscarUsuarioSACResource1"/>
                                        </td>
                                    </tr>
                                </table>
                                
                                
                            </td>
                            <td rowspan="6" style="width: 300px" width="400">
                                    <table style="width:300px">
                                        <tr>
                                            <td style="text-align: center;" valign="top" width="180">
                                                
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Label ID="Label30" runat="server" Text="Correo Electrónico:" 
                                                                meta:resourcekey="Label30Resource1"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="f_txtCorreoElectronico" runat="server" ForeColor="#000066" 
                                                                Width="180px" meta:resourcekey="f_txtCorreoElectronicoResource1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                            </td>
                                            <td style="text-align: center;" width="170">
                                                
                                                <table style="width:170px; float:right;">
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <asp:Image ID="f_ImageUsuarioSAC" runat="server" Height="150px" 
                                                                ImageUrl="~/User.png" Width="130px" 
                                                                meta:resourcekey="f_ImageUsuarioSACResource1" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <asp:CheckBox ID="f_CheckBoxTieneFoto" runat="server" Text="Fotografia :" 
                                                                TextAlign="Left" meta:resourcekey="f_CheckBoxTieneFotoResource1" 
                                                                Enabled="False" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="200">
                                <asp:Label ID="Label3" runat="server" Text="Nombres:" 
                                    meta:resourcekey="Label3Resource1"></asp:Label>
                            </td>
                            <td width="250">
                                <asp:Label ID="f_txtNombres" runat="server" Width="200px" Font-Bold="False"
                                    ForeColor="#000066" meta:resourcekey="f_txtNombresResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200">
                                <asp:Label ID="Label8" runat="server" Text="Apellidos:" 
                                    meta:resourcekey="Label8Resource1"></asp:Label>
                            </td>
                            <td width="250">
                                <asp:Label ID="f_txtApellidos" runat="server" Width="200px" Font-Bold="False"
                                    ForeColor="#000066" meta:resourcekey="f_txtApellidosResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200">
                                <asp:Label ID="Label6" runat="server" Text="Usuario pertenece al Centro:" 
                                    meta:resourcekey="Label6Resource1"></asp:Label>
                            </td>
                            <td width="250">
                                <asp:Label ID="f_txtSAC" runat="server" Width="199px" Font-Bold="False"
                                    ForeColor="#000066" meta:resourcekey="f_txtSACResource1"></asp:Label>
                                <asp:TextBox ID="f_txtSACID" runat="server" Width="15px" Enabled="False" 
                                    Visible="False" meta:resourcekey="f_txtSACIDResource1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="200">
                               <asp:Label ID="Label13" runat="server" Text="Carné solicitado en el SAC:" 
                                    meta:resourcekey="Label13Resource1"></asp:Label>
                            </td>
                            <td width="250">
                                 <asp:Label ID="f_labelsCodLocalSACSolicita" runat="server" Font-Bold="False" 
                                    Width="134px" ForeColor="#000066" 
                                     meta:resourcekey="f_labelsCodLocalSACSolicitaResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200">
                                <asp:Label ID="Label28" runat="server" Text="Carné emitidos:" 
                                    meta:resourcekey="Label28Resource1"></asp:Label>
                            </td>
                            <td width="250">
                                <asp:Label ID="f_labelnTotalEmitidas" runat="server" Height="16px" 
                                    Width="134px" Font-Bold="False" ForeColor="#000066" 
                                    meta:resourcekey="f_labelnTotalEmitidasResource1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <asp:Panel ID="pnlPagoDuplicado" runat="server" Visible="False" 
                    meta:resourcekey="pnlPagoDuplicadoResource1">
                    <fieldset style="width: 870px">
                    <legend style="font-weight: bold">Pago por duplicado de carné</legend>
                    
                        <table width="840px">
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Duplicado:" 
                                    meta:resourcekey="Label12Resource1"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:CheckBox ID="f_CheckBoxbDuplicado" runat="server" Enabled="False" 
                                    meta:resourcekey="f_CheckBoxbDuplicadoResource1"></asp:CheckBox>
                            </td>
                             <td>
                                <asp:Label ID="Label5" runat="server" Text="Documento de pago:" 
                                     meta:resourcekey="Label5Resource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="f_labelsTipoDocNumero" runat="server" Height="16px" 
                                    Width="134px" ForeColor="#000066" 
                                    meta:resourcekey="f_labelsTipoDocNumeroResource1"></asp:Label>
                                <asp:Label ID="f_labelsTipoDocumento" runat="server" BorderStyle="None" 
                                    ForeColor="#000066" Visible="False" 
                                    meta:resourcekey="f_labelsTipoDocumentoResource1"></asp:Label>
                                <asp:Label ID="f_labelsNumeroDocumento" runat="server" BorderStyle="None"  
                                    ForeColor="#000066" Visible="False" 
                                    meta:resourcekey="f_labelsNumeroDocumentoResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Generado por:" 
                                    meta:resourcekey="Label11Resource1"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:Label ID="f_LabelsUsuario" runat="server" BorderStyle="None" Height="16px" 
                                    Width="134px" ForeColor="#000066" 
                                    meta:resourcekey="f_LabelsUsuarioResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Centro:" 
                                    meta:resourcekey="Label14Resource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="f_LabelsEstablecimientoCodigo" runat="server" BorderStyle="None" Height="16px"
                                    ForeColor="#000066" Width="20px" 
                                    meta:resourcekey="f_LabelsEstablecimientoCodigoResource1"></asp:Label>
                                <asp:Label ID="f_LabelsEstablecimientoCodigoNombre" runat="server"
                                        BorderStyle="None" Height="16px" Width="134px" ForeColor="#000066" 
                                    meta:resourcekey="f_LabelsEstablecimientoCodigoNombreResource1"></asp:Label>
                            </td>
                        </tr>
                     </table>
                </fieldset></asp:Panel>
                <fieldset style="width: 870px">
                    <legend style="font-weight: bold">Datos de la solicitud de carné</legend>
                    <table width="840px">
                        <tr style="height:22px">
                            <td style="width: 200px">
                                <asp:Label ID="Label2" runat="server" Text="Fecha de solicitud:" 
                                    meta:resourcekey="Label2Resource1"></asp:Label>
                            </td>
                            <td style="width: 250px" class="style1">
                                <uc4:ucTextBoxFecha ID="f_TextBoxFechaSolicitud" runat="server" Enabled="True" />
                            </td>
                            <td style="width: 200px">
                                <asp:Label ID="Label27" runat="server" Text="Nº de solicitud:" 
                                    meta:resourcekey="Label27Resource1"></asp:Label>
                            </td>
                            <td style="width: 250px">
                                <asp:Label ID="f_labelsCodSolicitud" runat="server" BorderStyle="None" Height="16px"
                                    Width="134px" Font-Bold="False" ForeColor="#000066" 
                                    meta:resourcekey="f_labelsCodSolicitudResource1"></asp:Label>
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr style="height:22px">

                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Estado:" 
                                    meta:resourcekey="Label9Resource1"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="f_DropDownListEstadoSolicitud" runat="server" 
                                    Width="140px" meta:resourcekey="f_DropDownListEstadoSolicitudResource1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                        <tr style="height:25px">
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Solicitado por:" 
                                    meta:resourcekey="Label7Resource1"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:Label ID="f_labelsUsuarioSolicitaImpresion" runat="server" Width="134px" BorderStyle="None"
                                    Height="16px" ForeColor="#000066" 
                                    meta:resourcekey="f_labelsUsuarioSolicitaImpresionResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="Fecha de solicitado:" 
                                    meta:resourcekey="Label10Resource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="f_labeldFechaSolicitaImpresion" runat="server" BorderStyle="None"
                                    Height="16px" Width="134px" ForeColor="#000066" 
                                    meta:resourcekey="f_labeldFechaSolicitaImpresionResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height:25px">
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Impreso por:" 
                                    meta:resourcekey="Label16Resource1"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:Label ID="f_labelsUsuarioImpresion" runat="server" BorderStyle="None" Height="16px"
                                    Width="134px" ForeColor="#000066" 
                                    meta:resourcekey="f_labelsUsuarioImpresionResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="Fecha de impresión:" 
                                    meta:resourcekey="Label18Resource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="f_labeldFechaImpresion" runat="server" BorderStyle="None" Height="16px"
                                    Width="134px" ForeColor="#000066" 
                                    meta:resourcekey="f_labeldFechaImpresionResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height:25px">
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="Recibido en el SAC por:" 
                                    meta:resourcekey="Label20Resource1"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:Label ID="f_labelsUsuarioEntregaSAC" runat="server" BorderStyle="None" Height="16px"
                                    Width="134px" ForeColor="#000066" 
                                    meta:resourcekey="f_labelsUsuarioEntregaSACResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Fecha de recibido en el SAC:" 
                                    meta:resourcekey="Label22Resource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="f_labeldFechaEntregaSAC" runat="server" Width="134px" BorderStyle="None"
                                    Height="16px" ForeColor="#000066" 
                                    meta:resourcekey="f_labeldFechaEntregaSACResource1"></asp:Label>
                            </td>
                        </tr>
                        <tr style="height:25px">
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="Entregado al usuario por:" 
                                    meta:resourcekey="Label24Resource1"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:Label ID="f_labelsUsuarioEntregaUsuario" runat="server" Width="134px" BorderStyle="None"
                                    Height="16px" ForeColor="#000066" 
                                    meta:resourcekey="f_labelsUsuarioEntregaUsuarioResource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label26" runat="server" Text="Fecha de entrega al usuario:" 
                                    meta:resourcekey="Label26Resource1"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="f_labeldFechaEntregaUsuario" runat="server" Width="134px" BorderStyle="None"
                                    Height="16px" ForeColor="#000066" 
                                    meta:resourcekey="f_labeldFechaEntregaUsuarioResource1"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <table>
                    <tr>
                        <td>
                            <uc3:Auditoria ID="Auditoria1" runat="server" />
                            <asp:HiddenField ID="HF_CodSolicitud" runat="server" />
                            <asp:HiddenField ID="HF_CodUsuarioSAC" runat="server" />
                            <asp:HiddenField ID="HF_Evento" runat="server" />
                            <asp:HiddenField ID="HF_Ver" runat="server" />
                            <asp:HiddenField ID="HF_Matricul" runat="server" />
                            <asp:HiddenField ID="HF_Proceso" runat="server" />
                            <asp:HiddenField ID="HF_EstadoCarnet" runat="server" />
                            <asp:HiddenField ID="hfParameters" runat="server" />
                            
                        </td>
                    </tr>
                </table>
            </div>
            
                      <input id="ctl01"  runat=server type="text" 
                onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$ctl01\',\'\')', 0)" 
                onkeypress="if (WebForm_TextBoxKeyHandler(event) == false) return false;"  
                class="cssTextBox" style="visibility:hidden;display:none;"/>
            <asp:HiddenField ID="HiddenField1" runat="server" />


            
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"        
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>--%>
    
      <script type="text/javascript">


        function ActualizarPanel(parameter) {
   
        document.getElementById("<%=HiddenField1.ClientID%>").value= parameter;
        <%  Session["PameterMntDoc"] = HiddenField1.Value; %>
      
           
            Update('<%=ctl01.ClientID%>', parameter);
        };


        function Update(HiddenBoxID, parameter) {
            var HiddenBox = $get(HiddenBoxID);
            if (typeof (parameter) == "undefined") {
                parameter = "RANDOMPARAM" + Math.random();
            };
            if (HiddenBox.value == parameter) {
                parameter = parameter + "RANDOMPARAM" + Math.random();
           };
            HiddenBox.value = parameter;
            var MyCommand = String(HiddenBox.onchange).replace('function anonymous()\n{\n', '');
         //   MyCommand = MyCommand.replace('\n}', '');
            MyCommand = MyCommand.replace('function onchange(event) {\njavascript:\n', '');
            eval(MyCommand);
        };
         
    </script>

    
</asp:Content>
