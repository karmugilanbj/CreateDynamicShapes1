<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateDynamicShapes.aspx.cs" Inherits="CreateDynamicShapes.CreateDynamicShapes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create Dynamic Shapes</title>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        var canvas;
        var ctx;
       function drawRectangle(width,height) {
            /*InitializeCanvas();*/
            canvas = document.getElementById('canvas');
            ctx = canvas.getContext("2d");
            ctx.fillStyle = '#3AEEFC';
            ctx.rect(500,250, width, height);
            ctx.fillRect(500, 250, width, height);
            ctx.stroke();
        }
        function drawCircle(radius) {
          //Draw a circle
            canvas = document.getElementById('canvas');
            ctx = canvas.getContext("2d");
            ctx.arc(500, 250, radius, 0, 2 * Math.PI, false);
            ctx.fillStyle = '#3AEEFC';
            ctx.fill();
            ctx.stroke();
        }
         function drawOval(radius) {
          //Draw an oval
            canvas = document.getElementById('canvas');
            ctx = canvas.getContext("2d");
            var xCenter = parseInt(canvas.width/2);
            var yCenter = parseInt(canvas.height/2);
            ctx.translate(xCenter, yCenter);
            ctx.scale(2, 1);
            ctx.arc(50, 50, radius, 0, 2 * Math.PI, false);
            ctx.fillStyle = '#3AEEFC';
            ctx.fill();
            ctx.restore(); 
            ctx.stroke();

        }
        function drawPolygon(sides, radius) {
            canvas = document.getElementById('canvas');
            ctx = canvas.getContext("2d");
            var noofsides = parseInt(sides);
            var pradius = parseInt(radius);
            // Get our canvas center point to center the polygon
            var xCenter = parseInt(canvas.width/2);
            var yCenter = parseInt(canvas.height / 2);
            
            ctx.beginPath();
            // Map the first vertice to start with
            var xPos = xCenter + pradius * Math.cos(2 * Math.PI * 0 / noofsides);
            var yPos = yCenter + pradius * Math.sin(2 * Math.PI * 0 / noofsides);
            ctx.moveTo(xPos, yPos);
            // Loop through the vertices and map the lines
            for (i = 1; i <= noofsides; i++) {
                // Determine the coordinates of the next vertex
                xPos = xCenter + pradius * Math.cos(2 * Math.PI * i / noofsides);
                yPos = yCenter + pradius * Math.sin(2 * Math.PI * i / noofsides);
                // Set line to the next vertex
                ctx.lineTo(xPos, yPos);
            }
            ctx.fillStyle = '#3AEEFC';
            ctx.fill();
            ctx.stroke();

        }

        function drawParallelogram(width) {
            canvas = document.getElementById('canvas');
            ctx = canvas.getContext("2d");
            var x1, x2, x3, y3, x0, y0;
            x0 = 100;
            y0 = 100;
            //var width = 10; //choose your parallelogram width
            x1 = x0 + width;
            y1 = y0;

            x2 = x3 + width;
            y2 = y3;
            ctx.beginPath();
            ctx.moveTo(x0,y0);
            ctx.lineTo(x1,y1);
            ctx.lineTo(x2,y2);
            ctx.lineTo(x3,y3);
            ctx.closePath();
            ctx.fillStyle = '#3AEEFC';
            ctx.fill();
            ctx.stroke();
        }

        function drawEquilateral(side) {
            canvas = document.getElementById('canvas');
            ctx = canvas.getContext("2d");
            //equilateral triangle
            var h = side * (Math.sqrt(3) / 2);
            //ctx.strokeStyle = "#ff0000";
            var xCenter = parseInt(canvas.width/2);
            var yCenter = parseInt(canvas.height/2);
            ctx.save();
            ctx.translate(xCenter,yCenter);
            ctx.beginPath();
            ctx.moveTo(0, -h / 2);
            ctx.lineTo(-side / 2, h / 2);
            ctx.lineTo(side / 2, h / 2);
            ctx.lineTo(0, -h / 2);
            ctx.fillStyle = '#3AEEFC';
            ctx.fill(); 
            ctx.stroke();
            //ctx.closePath();
            //ctx.save();
        }

    </script>
</head>
<body>
    <form id="frmDynamicShapes" runat="server">
        <div>
            <img style="border:0px" src="Shapes.png" height="200px" width="100%" alt=""/> 
        </div>
        <div>
            <br />
        </div>
        <div>
            <table>
                <tr>
                    <td>
                    <asp:Label runat="server" Font-Size="Medium">Draw a</asp:Label> 
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlShapes" runat="server" OnSelectedIndexChanged="ddlShapes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                     <td>
                    <asp:Label runat="server" ID="lblwith" Visible="false">with a</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblMeasurement" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblOf" runat="server" Visible="false">of</asp:Label>
                    </td>
                    <td>
                    <asp:TextBox ID="txtMeasureMent1" runat="server" Visible="false"></asp:TextBox>
                    </td>
                    <td>
                    <asp:Label runat="server" ID="lblAnd" Visible="false">and</asp:Label>
                    </td>
                    <td>
                    <asp:Label ID="lblMeasurement2" runat="server" Visible="false"></asp:Label>
                       
                    </td>
                    <td>
                    <asp:TextBox ID="txtMeasureMent2" runat="server" Visible="false"></asp:TextBox>
                    </td>
                 </tr>
                 <tr>
                    <td>
                    <asp:Button ID="btnGenerate" runat="server" Text="Generate Shape" OnClick="btnGenerate_Click">
                    </asp:Button>
                   </td>
                </tr>
             </table>
            <table>
                <tr>
                    <td>
                        <canvas id="canvas" width="500" height="500"></canvas>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
