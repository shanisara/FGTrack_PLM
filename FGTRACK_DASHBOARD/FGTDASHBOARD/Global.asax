﻿<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        // SQLite GlobalDB
        HTN.BITS.SQLITE.BLL.GlobalSqliteDB.Instance.Init();
        HTN.BITS.SQLITE.BLL.GlobalSqliteDB.Instance.Connect();

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
        HTN.BITS.SQLITE.BLL.GlobalSqliteDB.Instance.Disconenct();
        HTN.BITS.SQLITE.BLL.GlobalSqliteDB.Instance.Release();

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>