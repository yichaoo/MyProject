using System;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Data.Common;

using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OracleTest
{
    public partial class _Default : System.Web.UI.Page
    {

        //For database connection
        OracleConnection conn;

        //To fill DataSet and update Datasource
        private OracleDataAdapter productsAdapter;
        //For automatically generating Commands to make changes to Database through Dataset
        private OracleCommandBuilder productsCmdBuilder;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Connection Information	
                string connectionString =
                    //Username
                    "User Id=" + ConnectionParams.Username +
                    //Password
                    ";Password=" + ConnectionParams.Password +
                    //Replace with your datasource value (TNSNames)
                    ";Data Source=" + ConnectionParams.Datasource;
                //Connection to datasource, using connection parameters given above
                conn = new OracleConnection(connectionString);

                //Open database connection
                conn.Open();
                Response.Write("success");
            }
            // Catch exception when error in connecting to database occurs
            catch (Exception ex)
            {
                //Display error message
                // MessageBox.Show(ex.ToString());
                Response.Write(ex.Message);
            }
            populateProductsDataGrid();
            DataTable dt = BindWaterList();
        }

        public DataTable BindWaterList()
        {
            return JLcms.DBUtility.DbHelperOra.Query("select * from sw_list").Tables[0];
        }
        private void populateProductsDataGrid()
        {
            try
            {
                //Instantiate OracleDataAdapter to create DataSet
                //Fetch Product Details
                productsAdapter = new OracleDataAdapter("SELECT " +
                  "Product_ID ID, " +
                  "Product_Name Name, " +
                  "Product_Desc Description, " +
                  "Category, " +
                  "Price, " +
                  "Product_Status " +
                  " FROM Products", conn);

                //For automatically generating commands
                productsCmdBuilder = new OracleCommandBuilder(productsAdapter);

                //Creating Dataset
                DataSet productsDataSet = new DataSet("productsDataSet");

                //AddWithKey sets the Primary Key information to complete the 
                //schema information
                productsAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                //Fill the DataSet 
                productsAdapter.Fill(productsDataSet, "Products");



                //Binding DataSet to the DataGrid
                //   productsDataGrid.SetDataBinding(productsDataSet, "Products");

            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        //private Boolean getDBConnection()
        //{

        //}
    }
}