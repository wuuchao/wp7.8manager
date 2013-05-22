package mypack;

import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class charts extends HttpServlet {
	public void doPost(HttpServletRequest request,HttpServletResponse response)
    throws ServletException, IOException {
		String getData = request.getParameter("rank");
		String getName = request.getParameter("name");
		if(getData != null)
		{
			if (getName == null) getName = "ÎÞÃû";
			int intData =Integer.parseInt(getData); 
			for (int i = 0; i < 10; i++) {
				if(intData > dataStore.rank[i]) {
					for (int j = 8; j >= i; j--) {
						dataStore.rank[j+1] = dataStore.rank[j];
						dataStore.name[j+1] = dataStore.name[j];
					}
					dataStore.rank[i] = intData;
					dataStore.name[i] = getName;
					break;
				}
			}
		}
		response.setContentType("text/html;charset=UTF8");
		PrintWriter out = response.getWriter();
		for (int i = 0; i < 10; i++)
		  out.print(dataStore.name[i]+":"+dataStore.rank[i]+" ");
	}
	public void doGet(HttpServletRequest request,HttpServletResponse response)
    throws ServletException, IOException {
		doPost(request, response);
	}
}
