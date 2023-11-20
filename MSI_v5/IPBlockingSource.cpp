public void Init(HttpApplication context)
 {
     context.BeginRequest += new EventHandler(Application_BeginRequest);
 }

 private void Application_BeginRequest(object source, EventArgs e)
 {
     HttpContext context = ((HttpApplication)source).Context;
     context.Response.StatusCode = 403;  // (Forbidden)

 }