<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BotonesEdicionLista.ascx.cs"
    Inherits="Controles_BotonesEdicionLista" %>
<table cellpadding="0" cellspacing="0" width="300px">
    <tr>
        <td style="width: 300px">        
            <table cellpadding="0" border="0" cellspacing="0" >
                <tr>
                    <td >
                        
                        <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Buscar_A.jpg"
                            OnClick="btnBuscar_Click" ToolTip="Buscar"  
                            TabIndex="1" />
                        
                        
                    </td><%--Height="30px" Width="90px" --%>
                    <td >
                        <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Nuevo_A.jpg"
                             OnClick="btnAgregar_Click" ToolTip="Nuevo" 
                            CausesValidation="False" TabIndex="2" />
                    </td><%--Height="30px" Width="90px"--%>
                    <td >
                        <asp:ImageButton ID="btnImprimir" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Imprimir_A.jpg"
                             OnClick="btnImprimir_Click" ToolTip="Imprimir" 
                            CausesValidation="False" TabIndex="3" />
                    </td><%--Height="30px" Width="90px"--%>
                    <td >
                        <asp:ImageButton ID="btnExportar" runat="server" Visible="false" ImageUrl="~/Comun/Imagenes/Botones/Exportar_A.jpg"
                            OnClick="btnExportar_Click" ToolTip="Exportar" 
                            CausesValidation="False" TabIndex="4" />
                    </td><%--Height="30px" Width="90px" --%>
                    
                    <td >
                        <asp:ImageButton ID="btnRegresar"  ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg"
                            runat="server" OnClick="btnRegresar_Click" ToolTip="Regresar" 
                            TabIndex="5" />
                    </td><%--Height="30px" Width="90px" --%>
                    <td >
                        &nbsp;
                    </td>
                </tr>
            </table>
        
        </td>
    </tr>
</table>
