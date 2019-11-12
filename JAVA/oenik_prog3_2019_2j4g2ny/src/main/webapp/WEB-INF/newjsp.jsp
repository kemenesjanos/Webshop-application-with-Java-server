<%-- 
    Document   : newjsp
    Created on : 2019. nov. 12., 17:12:53
    Author     : admin
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <%
            if (request.getParameter("price") == null) {
                    out.println("Hibás paraméter!");
            } else {
                ServletContext context = getServletContext();
                RequestDispatcher rd = context.getRequestDispatcher("/InputHandler");
                rd.forward(request, response);
            }
            %>
    </body>
</html>
