using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace CreateDynamicShapes
{
    public partial class CreateDynamicShapes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadShapes();
            }
            if(!IsPostBack)
            {

            }
        }

        private void LoadShapes()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("DataSource.xml"));
            ddlShapes.DataSource = ds;
            ddlShapes.DataTextField = "shapeName";
            ddlShapes.DataValueField = "shapeid"; 
            ddlShapes.DataBind();

            ListItem li = new ListItem("Select Shape", "-1");
            ddlShapes.Items.Insert(0, li);
        }

        private void PopulateControls()
        {

        }

        protected void ddlShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllTextFields();

            string selectedShape = ddlShapes.SelectedItem.Text;
            string tempMeasurementText = string.Empty;
            switch (selectedShape)
            {
                
                case "Square":
                case "Pentagon":
                case "Hexagon":
                case "Heptagon":
                case "Octagon":
                case "Equilateral Triangle":
                    lblwith.Visible = true;
                    lblMeasurement.Visible = true;
                    txtMeasureMent1.Visible = true;
                    lblMeasurement.Text = "side length of";
                    break;
                case "Scalene Triangle":
                case "Isoceles Triangle":
                case "Parallelogram":
                case "Rectangle":
                    lblwith.Visible = true;
                    lblAnd.Visible = true;
                    lblMeasurement.Visible = true;
                    txtMeasureMent1.Visible = true;
                    lblMeasurement2.Visible = true;
                    txtMeasureMent2.Visible = true;
                    lblMeasurement.Text = "width of";
                    lblMeasurement2.Text = "a height of";
                    break;
               
                case "Circle":
                case "Oval":
                    lblwith.Visible = true;
                    lblMeasurement.Visible = true;
                    txtMeasureMent1.Visible = true;
                    lblMeasurement.Text= "radius of";
                    break;
             
            }
        }
        private void HideAllTextFields()
        {
            lblMeasurement.Text = string.Empty;
            lblMeasurement2.Text = string.Empty;
            txtMeasureMent1.Text = string.Empty;
            txtMeasureMent2.Text = string.Empty;

            lblAnd.Visible = false;
            lblwith.Visible = false;
            lblMeasurement.Visible = false;
            txtMeasureMent1.Visible = false;
            lblMeasurement2.Visible = false;
            txtMeasureMent2.Visible = false;
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            int MeasureMent1 = 0;
            int MeasureMent2 = 0;
            var regex = @"^[0-9]+$";
            string selectedShape = ddlShapes.SelectedItem.Text;
            if (selectedShape == "Select Shape")
            {
                string script = "alert(\"Please Select a Shape\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
            Match match1 = Regex.Match(txtMeasureMent1.Text.Trim(), regex, RegexOptions.IgnoreCase);
            Match match2 = Regex.Match(txtMeasureMent2.Text.Trim(), regex, RegexOptions.IgnoreCase);

            if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()) && match1.Success)
            {
                MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
            }
            else
            {
                string refscript1 = "alert(\"Please Enter a Number\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", refscript1, true);
                return;
            }
            if (selectedShape=="Rectangle"|| selectedShape == "Scalene Triangle" || selectedShape == "Isoceles Triangle")
            { 
                if (!string.IsNullOrEmpty(txtMeasureMent2.Text.Trim()) && match2.Success)
                {
                    MeasureMent2 = Convert.ToInt32(txtMeasureMent2.Text.Trim());
                }
                else
                {
                    string refscript2 = "alert(\"Please Enter a Number\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", refscript2, true);
                    return;
                }
            }
            switch (selectedShape)
            {
                case "Rectangle":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()) && !string.IsNullOrEmpty(txtMeasureMent2.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawRectangle('" + MeasureMent1 + "','" + MeasureMent2 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                case "Square":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawRectangle('" + MeasureMent1 + "','" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;

                case "Pentagon":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawPolygon('" + 5 + "','" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                case "Hexagon":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawPolygon('" + 6 + "','" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                case "Heptagon":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawPolygon('" + 7 + "','" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                case "Octagon":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawPolygon('" + 8 + "','" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;

                case "Scalene Triangle":
                case "Isoceles Triangle":
                    break;
                case "Equilateral Triangle":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawEquilateral('" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                case "Parallelogram":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawParallelogram('" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                case "Circle":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawCircle('" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                case "Oval":
                    if (!string.IsNullOrEmpty(txtMeasureMent1.Text.Trim()))
                    {
                        MeasureMent1 = Convert.ToInt32(txtMeasureMent1.Text.Trim());
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawOval('" + MeasureMent1 + "');", true);
                    }
                    else
                    {
                        string script = "alert(\"Please enter a Value\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    break;
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Generate Shapes", "drawRectangle('" + 200 + "','" + 200 + "');", true);


            }
           

        }

        
    }
}