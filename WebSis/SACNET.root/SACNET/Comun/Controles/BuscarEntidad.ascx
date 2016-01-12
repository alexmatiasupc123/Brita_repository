<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BuscarEntidad.ascx.cs"
    Inherits="Controles_BuscarEntidad" %>
<%@ Register Src="MessageBox.ascx" TagName="MessageBox" TagPrefix="uc1" %>
<div style="width: 640px;">
    <div class="panelBucador">
        <fieldset style="width: 400px">
            <legend>Busqueda de Registros</legend>
            <table border="0" cellpadding="0" cellspacing="0">
              <tr>
                    <td>
                        Tipo de Entidad:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTipoEntidad" runat="server" Width="220px" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlTipoEntidad_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                     <td>
                         &nbsp; &nbsp;<asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Comun/Imagenes/Icons/btnBuscar.gif"
                            OnClick="ibtnBuscar_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCodPersona" runat="server" Text="Codigo:" Visible="False"></asp:Label>
                    </td>
                    <td>
                        
                        <asp:TextBox ID="txtCodPersona" runat="server" Width="200px" MaxLength="5" 
                            Visible="False"></asp:TextBox>
                    </td>                
                   
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                       <asp:Label ID="lblNombre" runat="server" Text="Nombre:" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" Width="200px" MaxLength="80" 
                            Visible="False"></asp:TextBox>
                    </td>
                    <td>
                       
                    </td>
                </tr>
              
            </table>
        </fieldset>
    </div>
    <div class="panelleyenda">
        <fieldset>
            <legend>
                <asp:Label ID="Label2" runat="server" Text="Leyenda"></asp:Label></legend>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Comun/Imagenes/Icons/SelecDocument.png"
                            Width="20px" />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Seleccionar Persona"></asp:Label>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div style="width: 600px; text-align:center; ">
        <asp:Label ID="lblError" runat="server" CssClass="cssPanelError" Width="180px" EnableTheming="False"></asp:Label>
    </div>
    <div class="panelGria">
        <asp:GridView ID="gvBuscar" runat="server" Width="640px" AutoGenerateColumns="False"
            AllowPaging="True" PageSize="20" OnPageIndexChanging="gvBuscar_PageIndexChanging"
            OnSelectedIndexChanged="gvBuscar_SelectedIndexChanged">
            <PagerSettings FirstPageText="" LastPageText="" Mode="NextPreviousFirstLast" NextPageImageUrl="~/Comun/Imagenes/Icons/next_normal.gif"
                NextPageText="" PreviousPageText="" FirstPageImageUrl="~/Comun/Imagenes/Icons/first_normal.gif"
                LastPageImageUrl="~/Comun/Imagenes/Icons/last_normal.gif" PageButtonCount="5"
                PreviousPageImageUrl="~/Comun/Imagenes/Icons/previous_normal.gif" />
            <Columns>
                <asp:BoundField DataField="Codi_persona" HeaderText="Codigo Persona" />
                <asp:BoundField DataField="CodArguTipoEntidadNombre" HeaderText="Tipo de Entidad" />
                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" />
                <asp:BoundField DataField="ApellidosPersona" HeaderText="Apellidos" />
                <asp:BoundField DataField="NombresPersona" HeaderText="Nombres" />
                <asp:CommandField ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/Comun/Imagenes/Icons/SelecDocument.png">
                </asp:CommandField>
            </Columns>
        </asp:GridView>
    </div>
</div>
