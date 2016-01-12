<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUsuario.ascx.cs" Inherits="Comun_Controles_ucUsuario" %>
<fieldset style="width: 870px">
    <legend>Datos del usuario</legend>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label>
            </td>
            <td>
                <asp:HiddenField ID="HF_CodUsuarioSAC" runat="server" />
                <asp:Label ID="TextBoxNombresApellidos" runat="server" Width="368px"
                    ReadOnly="True" ForeColor="#000066" Font-Bold="False"></asp:Label>
            </td>
            <td rowspan="4" align="center">
                <asp:Image ID="f_ImageUsuarioSAC" runat="server" Height="143px" Width="145px" ImageUrl="~/User.png" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblTipoPersona" runat="server" Text ="Tipo de usuario:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="labelTipoPersona" runat="server" ForeColor="#000066"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelSAC" runat="server" Text="Centro:"></asp:Label>
            </td>
            <td>
                <asp:Label ID="TextBoxCodSAC" runat="server" Width="25px" ReadOnly="True" Visible="False"></asp:Label>
                <asp:Label ID="TextBoxNomSAC" runat="server" Width="250px" ReadOnly="True"
                    ForeColor="#000066" Font-Bold="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                
                            <asp:GridView ID="gvvwCursosUsuarioSAC" runat="server" Width="550px" AutoGenerateColumns="False"
                                AllowPaging="True" EmptyDataText="No existen cursos registrados"
                                OnPageIndexChanging="gvvwCursosUsuarioSAC_PageIndexChanging" PageSize="5">
                                <Columns>
                                    <asp:BoundField DataField="SubSistema" HeaderText="Sub Sistema" />
                                    <asp:BoundField DataField="Ciclo" HeaderText="CICLO" />
                                    <asp:BoundField DataField="Cursos" HeaderText="CURSOS" Visible="false" />
                                    <asp:BoundField DataField="Horario" HeaderText="HORARIO" />
                                    <asp:BoundField DataField="FechaInicioCiclo" HeaderText="FECHA INICIO" 
                                                    DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FechaFinalCiclo" HeaderText="FECHA FIN"  
                                                    DataFormatString="{0:dd/MM/yyyy}">
                                                    <HeaderStyle Width="80px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>                
                                    <asp:BoundField DataField="EstadoDeCurso" HeaderText="ESTADO DE CURSO" />
                                </Columns>
                            </asp:GridView>
              
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvMovimientos" runat="server" Width="850px" AutoGenerateColumns="False"
                    AllowPaging="True" EmptyDataText="No existen movimientos registrados del usuario"
                    OnRowDataBound="gvMovimientos_RowDataBound" OnPageIndexChanging="gvMovimientos_PageIndexChanging"
                    PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="sCodSacNombre" HeaderText="CENTRO" ItemStyle-Width="60px">
                            <ItemStyle Width="150px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO EJEMPLAR" />
                        <asp:BoundField DataField="sCodEjemplarCodigoItem" HeaderText="CÓDIGO ITEM" />
                        <asp:BoundField DataField="sCodEjemplarNombreTitulo" HeaderText="TÍTULO"  
                            ItemStyle-Width="250px">
<ItemStyle Width="250px"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="sCodArguPrestamoEnNombre" HeaderText="PRÉSTAMO EN" />
                        <asp:BoundField DataField="sEstadoRegistro" HeaderText="TIPO DE MOVIMIENTO" />
                        <asp:BoundField DataField="dFechaPrestamo" HeaderText="PRÉSTAMO" />
                        <asp:BoundField DataField="dFechaDevolucionEstimada" HeaderText="DEVOLUCIÓN ESTIMADA" />
                        <asp:BoundField DataField="dFechaDevolucionReal" HeaderText="DEVOLUCIÓN REAL" />
                        <asp:BoundField HeaderText="TIPO PRÉSTAMO">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</fieldset>
