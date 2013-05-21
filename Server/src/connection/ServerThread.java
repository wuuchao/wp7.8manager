package connection;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

public class ServerThread extends Thread{
	private Socket _socket = null;
	DataOutputStream _dataOutputStream = null;
	DataInputStream _dataInputStream = null;
	
	public void run() {
		try {
			_dataInputStream.readUTF();
//			_dataOutputStream.writeUTF("connected Server");
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}finally{
			if (!_socket.isClosed()) {
				try {
					_socket.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
			}
		}
	}
	
	public ServerThread(Socket _socket){
		this._socket = _socket;
		try {
			_dataOutputStream = new DataOutputStream(_socket.getOutputStream());

			_dataInputStream = new DataInputStream(_socket.getInputStream());
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
