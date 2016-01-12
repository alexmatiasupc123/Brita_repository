<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BotonesEdicionMantenimiento.ascx.cs"
    Inherits="Controles_BotonEdicionMantenimiento" %>
<table cellpadding="0" cellspacing="0" width="300px">
    <tr>
        <td style="width: 300px;">
            <table cellpadding="0" border="0" cellspacing="0" >
                <tr>
                    <td>
                        <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Nuevo_A.jpg"
                            OnClick="btnAgregar_Click" ToolTip="Nuevo" />
                    </td><%--Height="30px" Width="90px" --%>
                    <td>
                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Modificar_A.jpg"
                             OnClick="btnEditar_Click" ToolTip="Modificar" />
                    </td><%--Height="30px" Width="90px"--%>
                    <td>
                        <asp:ImageButton ID="btnGrabar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg"
                          OnClick="btnGrabar_Click" ToolTip="Guardar" />
                    </td><%--Height="30px"    Width="90px"--%>
                    <td>
                        <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Cancelar_A.jpg"
                          OnClick="btnCancelar_Click" ToolTip="Cancelar" />
                    </td><%-- Height="30px"   Width="90px"--%>
                    <td>
                        <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg"
                           OnClick="btnRegresar_Click" ToolTip="Regresar"/>
                    </td><%--Height="30px"   Width="90px"--%>
                    <td>
                        <div style="display: none;">
                           <cc1:ConfirmButtonExtender ID="btnCancelar_ConfirmButtonExtender" runat="server"
                                ConfirmText="¿Desea salir de esta opción?" Enabled="True" TargetControlID="btnCancelar">
                            </cc1:ConfirmButtonExtender>
                            <%-- <cc1:ConfirmButtonExtender ID="btnRegresar_ConfirmButtonExtender" runat="server"
                                ConfirmText="¿ Desea salir del mantenimiento ?" Enabled="True" TargetControlID="btnRegresar">
                            </cc1:ConfirmButtonExtender>--%>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
