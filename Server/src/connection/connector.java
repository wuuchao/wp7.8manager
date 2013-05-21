package connection;
import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintStream;
import java.net.ServerSocket;
import java.net.Socket;

public class connector {
		private Socket _socket = null;
		private ServerSocket _serverSocket = null;
		private DataInputStream _dataInputStream = null;
		public connector(){}
		public String con(){
			String s =null;
			int port = 1111;
		try {
			_serverSocket = new ServerSocket(port);
			while(true) {
				_socket = _serverSocket.accept();
				_dataInputStream = new DataInputStream(_socket.getInputStream());
				
//				new ServerThread(_socket).start();
				s = _dataInputStream.readUTF();
			}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			s = e.toString();
		} finally {
			if(_socket != null)
			if (!_socket.isClosed()) {
				try {
					_socket.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
			if(_serverSocket != null)
			if (!_serverSocket.isClosed())
			{
				try {
					_serverSocket.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		}
		return s;
		}
}
