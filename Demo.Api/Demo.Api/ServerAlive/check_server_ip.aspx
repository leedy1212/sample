<%@ Page language="c#" AutoEventWireup="false"%>
<%@Import Namespace="System.Net"%>

<html>
  <head>
    <title>Check_Server_IP</title>
  </head>
  <body>
	<%=System.Net.Dns.Resolve(Dns.GetHostName()).AddressList[0].ToString()%>
  </body>
</html>