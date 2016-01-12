<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Auditorios, App_Web_yfflyer_" title="CENTRO CULTURAL BRITÁNICO - Quiénes somos" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 410px">
        <tr>
            <td align="left" style="height: 40px">
                <asp:Label ID="lblDireccionSede" runat="server" CssClass="titulo" Text="¿Sabías que en el Británico encontrarás un Centro Cultural de vanguardia?"
                    Width="100%"></asp:Label><br />
                <hr style="width: 100%" />
                &nbsp;</td>
        </tr>
        <tr>
            <td class="cuadroTextoContenido" style="width: 440px; height: 256px;" align="center" valign="top">
                <asp:Panel ID="pContenido" runat="server" CssClass="cuadroTextoContenido" Height="50px"
                    HorizontalAlign="Justify" Width="100%">
                        Tenemos para ti más de lo que imaginas: más música, más teatro, más conferencias.
                            Desde su creación en 1987, el Centro Cultural ha desarrollado una fructífera y variada
                            vida cultural, convirtiéndonos de esta manera en un espacio de vanguardia e intercambio
                            de las culturas Peruano Británica.
                    <p>
                        &nbsp;</p>
                    <p>
                       Nuestra sede principal se encuentra en el distrito de Miraflores, aunque
                            para comodidad de nuestro público tenemos un nuevo ingreso por Malecón
                            Balta 740, además del ya habitual a través del Jr. Bellavista 531. Aquí encontrarás
                            el tradicional Teatro Británico, la galería de arte John Harriman y el cálido auditorio;
                            todos íntegramente remodelados con tecnología de última generación.
                    </p>
                    <p >
                        &nbsp;</p>
                    <p>
                       Asimismo, contamos con auditorios descentralizados, por medio de los cuales
                            presentamos actividades de diferentes géneros en los distritos de San Borja, Surco,
                            San Miguel, San Martín de Porres. En este último tenemos una nueva y moderna sala
                            de exposiciones. Cabe mencionar, también, que dentro de nuestra política de gestión
                            cultural descentralizadora nos dedicamos a difundir y fomentar las artes plásticas
                            y escénicas, las letras, la música y ahora la ciencia y la tecnología.</p>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 440px; height: 12px;">
            </td>
        </tr>
    </table>
</asp:Content>

