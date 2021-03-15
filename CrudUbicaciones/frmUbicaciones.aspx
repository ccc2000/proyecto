<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmUbicaciones.aspx.cs" Inherits="CrudUbicaciones.frmUbicaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <script src="https://netdna.bootstrapcdn.com/bootstrap/3.0.3/js/bootstrap.min.js"></script>
    
    
    <!--Api Key-->
    <script type="text/javascript" src='https://maps.google.com/maps/api/js?sensor=false&libraries=places&key=AIzaSyC5keUIKugB2vzNgZ7dzrUu1TTE29NX9LA'></script>
    <script src="js/locationpicker.jquery.js"></script>
    <title>Control de Ubicaciones</title>
</head>
<body>
    <form id="form1" runat="server">
        
        
        <div class="container">
            <div class ="row">


              







                <div class ="col-md-4">
                         <!-- Solo esta linea escribir-->
                    <h1>Creacion o adicion de garantias</h1>

                    <div class="form-group">
                        <div id="ModalMapPreview" style="width:100% ; height:300px;"></div>
                    </div>

                    <!-- Latitud y longitud-->

                    <div class="form-group">

                         


                        <label for="exampleInpuntPassword">CI:</label>
                           <asp:TextBox ID="txtCi" CssClass="form-control" runat="server"></asp:TextBox>
                        <label for="exampleInpuntPassword">Nombre:</label>
                           <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>


                        <div class="form-group">
                            <label for="exampleInputEmail1">Ubicacion</label>
                            <asp:HiddenField ID="txtID" runat="server" />
                            <asp:TextBox ID="txtUbicacion" CssClass="form-control" runat="server"></asp:TextBox>
                       </div>


                        <label for="exampleInpuntPassword">Lat.:</label>
                           <asp:TextBox ID="txtLat" Text="-17.783851" CssClass="form-control" runat="server"></asp:TextBox>
                        <label for="exampleInpuntPassword">Long.:</label>
                           <asp:TextBox ID="txtLong" Text="-63.182580" CssClass="form-control" runat="server"></asp:TextBox> 

                    </div>

                    <!--Controles -->
                    <div class="form-group">
                        <asp:Button ID="btnAgregar" CssClass="btn btn-success" runat="server" Text="Agregar" UseSubmitBehavior="false" OnClick="AgregarRegistro" />
                        <asp:Button ID="btnModificar" CssClass="btn btn-warning" runat="server" Text="Modificar" UseSubmitBehavior="false" Enabled="false" OnClick="ModificarRegistro" />
                        <asp:Button ID="btnEliminar" CssClass="btn btn-danger" runat="server" Text="Eliminar" UseSubmitBehavior="false" Enabled="false" OnClick="EliminarRegistro" />
                        <asp:Button ID="btnLimpiar" CssClass="btn btn-default" runat="server" Text="Limpiar" UseSubmitBehavior="false" OnClick="Limpiar" />

                    </div>



                </div>




                <div class="col-md-8"></div>

                


                      <br />
                <!--Otra Linea 2 cortar y pegar-->
                 <!--Metodo Buscar-->
                <div class="form-group">  

                        <label for="exampleInputEmail1">Buscar:</label>
                        <asp:Textbox ID="txtBuscar" runat="server" />
                        <asp:Button ID="btnBuscar" runat="server" Text ="Buscar" Onclick="btnBuscar_Click" />
                 </div>
                <!--Hasta aqui-->
                       <h1>Ubicaciones</h1>

                 <div class="col-md-8">

                <asp:GridView ID="gvUbicaciones" runat="server" CssClass="table-responsive table table-border" OnRowCommand="SeleccionRegistro">
                    <Columns>
                        <asp:ButtonField CommandName="btnSeleccionar" Text="Seleccionar">
                        <ControlStyle CssClass="btn btn-info" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>

            </div>

                      <br />

            </div>
        
        </div>
     
    <script>

        $('#ModalMapPreview').locationpicker({
            radius: 0,
            location: {
                latitude: $('#<%=txtLat.ClientID%>').val(),
                longitude: $('#<%=txtLong.ClientID%>').val()
            },
            //Este script guarda las cordenadas del marker , para guardarlas en una base de datos
            inputBinding: {

                latitudeInput: $('#<%=txtLat.ClientID%>'),
                longitudeInput: $('#<%=txtLong.ClientID%>'),
                locationNameInput: $('#<%=txtUbicacion.ClientID%>')
            },
            enableAutocomplete: true,
        });
    </script>

        
    </form>
     
    </body>
</html>
