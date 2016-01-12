<%@ Control Language="C#"  AutoEventWireup="true" CodeFile="BotonesEdicionMantenimiento2.ascx.cs"
    Inherits="Controles_BotonEdicionMantenimiento2" %>
<table cellpadding="0" cellspacing="0" width="210px">
    <tr>
        <td style="width: 210px;">
            <table cellpadding="0" border="0" cellspacing="0" width="210px">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/news_activo.jpg"
                            Height="30px" Width="90px" OnClick="btnAgregar_Click" ToolTip="Nuevo" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/edit_activo.jpg"
                            Height="30px" Width="90px" OnClick="btnEditar_Click" ToolTip="Editar" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnGrabar" runat="server" Height="30px" ImageUrl="~/Comun/Imagenes/Botones/save_activo.jpg"
                            Width="90px" OnClick="btnGrabar_Click" ToolTip="Grabar" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnCancelar" runat="server" Height="30px" ImageUrl="~/Comun/Imagenes/Botones/cancelar_activo.jpg"
                            Width="90px" OnClick="btnCancelar_Click" ToolTip="Cancelar"/>
                    </td>
                    <td>
                    
                    </td>
                    <td>
                        <div style="display: none;">
                            <%--<cc1:ConfirmButtonExtender ID="btnCancelar_ConfirmButtonExtender" runat="server"
                                ConfirmText="¿Desea cancelar el mantenimiento?" Enabled="True" TargetControlID="btnCancelar">
                            </cc1:ConfirmButtonExtender>--%>
                           <%-- <cc1:ConfirmButtonExtender ID="btnRegresar_ConfirmButtonExtender" runat="server"
                                ConfirmText="¿ Desea cancelar el mantenimiento ?" Enabled="True" TargetControlID="btnRegresar">
                            </cc1:ConfirmButtonExtender>--%>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
