/**************************************************************************
@author  Jagriti
@version 1.0
Development Environment        :  MS Visual Studio .Net
Name of the File               :  ConnectionParams.cs
Creation/Modification History  :
                                  21-July-2002     Created

Overview:
This file defines the variables for connection parameters for database.
**************************************************************************/

using System;
namespace OracleTest
{

    public class ConnectionParams
    {
        //Parameters for database connection
        //Change the values to those applicable to your database
        //Replace with Connect String as TNSNames
        public static string Datasource = "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.10.254)(PORT=1521))(CONNECT_DATA=(SERVER = DEDICATED)(SERVICE_NAME=orcl)))";
        public static string Username = "user_whhdj";      //Username
        public static string Password = "123";      //Password
    }
}
